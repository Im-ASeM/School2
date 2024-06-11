using BCrypt.Net;
using Microsoft.EntityFrameworkCore;

public class StudentProccesRepository : IStudentProccesRepository
{
    Context db = new Context();
    ScoreProccesRepository spr = new ScoreProccesRepository();
    string paper = "salam man ASeM hastam 321";
    public bool addStudent(NewStudent student)
    {
        if (db.StudentsTbl.Any(x => x.Code == student.Code))
        {
            return false;
        }
        string x = BCrypt.Net.BCrypt.HashPassword(student.Password + paper + student.Code);
        Students add = new Students { Code = student.Code, Name = student.Name, password = x, ClassName = student.ClassName, isPass = true };
        db.StudentsTbl.Add(add);
        db.SaveChanges();
        return true;
    }

    public Student getStudent(int Id)
    {
        Students chose = db.StudentsTbl.Find(Id);
        if (chose == null)
        {
            return null;
        }
        Student result = new Student
        {
            Id = chose.Id,
            Name = chose.Name,
            ClassName = chose.ClassName,
            Code = chose.Code,
            Score = spr.getScores(Id)
        };
        return result;
        //List<Score> scores = new List<Score>();
        //foreach(Scores item in db.ScoresTbl.ToList())
        //{
        //    if (item.StudentId == Id)
        //    {
        //        Score score = new Score { Id = item.StudentId, Name = item.Name,StudentId = item.StudentId ,Point=item.Point};
        //        scores.Add(score);
        //    }
        //}
        //result.Score=scores;
    }

    public List<Student> getStudents()
    {
        List<Student> results = new List<Student>();
        foreach (Students chose in db.StudentsTbl.ToList())
        {
            Student result = new Student { Id = chose.Id, Name = chose.Name, ClassName = chose.ClassName, Code = chose.Code, Score = spr.getScores(chose.Id) };
            results.Add(result);
        }
        return results;
    }

    public string login(string username, string password)
    {
        Students loginTry = db.StudentsTbl.Where(x=>x.Code == username).FirstOrDefault();
        if(loginTry==null)
        {
            return "user Not fount";
        }
        else if(BCrypt.Net.BCrypt.Verify(password+paper+username,loginTry.password))
        {
            return "login sucssesful";
        }
        else
        {
            return "invalid password";
        }

    }

    public bool removeStudent(int Id)
    {
        Students remove = db.StudentsTbl.Find(Id);
        if (remove == null) { return false; }
        spr.removeScores(Id);
        db.StudentsTbl.Remove(remove);
        db.SaveChanges();
        return true;
    }

    public string updateStudent(UpdateStudent student)
    {
        Students update = db.StudentsTbl.Find(student.Id);
        if (update == null)
        {
            return "invalid Id";
        }
        else if (update.Code != student.Code)
        {
            return "invalid username";
        }
        else if (!BCrypt.Net.BCrypt.Verify(student.OldPassword + paper + student.Code , update.password))
        {
            return "invalid Password";
        }
        else
        {
            update.Name = student.Name;
            update.Code = student.Code;
            update.password = BCrypt.Net.BCrypt.HashPassword(student.NewPassword + paper + student.Code);
            update.ClassName = student.ClassName;
            db.StudentsTbl.Update(update);
            db.SaveChanges();
            return "Done";
        }
    }
}

