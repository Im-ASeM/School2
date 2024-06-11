public class StudentProccesRepository : IStudentProccesRepository
{
    Context db = new Context();
    ScoreProccesRepository spr = new ScoreProccesRepository();
    public void addStudent(NewStudent student)
    {
        Students add = new Students { Code = student.Code, Name = student.Name, ClassName = student.ClassName, isPass = true };
        db.StudentsTbl.Add(add);
        db.SaveChanges();
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
            Student result = new Student { Id = chose.Id, Name = chose.Name, ClassName = chose.ClassName, Code = chose.Code ,Score = spr.getScores(chose.Id)};
            results.Add(result);
        }
        return results;
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

    public bool updateStudent(UpdateStudent student)
    {
        Students update = db.StudentsTbl.Find(student.Id);
        if (update == null) { return false; }
        update.Name = student.Name;
        update.Code = student.Code;
        update.ClassName = student.ClassName;
        db.StudentsTbl.Update(update);
        db.SaveChanges();
        return true;
    }
}

