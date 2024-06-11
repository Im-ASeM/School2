
public class ScoreProccesRepository : IScoresProccesRepository
{
    Context db = new Context();
    public bool addScore(NewScore score)
    {
        Students student = db.StudentsTbl.Find(score.StudentId);
        if (student == null)
        {
            return false;
        }
        Scores add = new Scores { StudentId = student.Id, Name = score.Name, Point = score.Point, isPass = score.isPass };
        db.ScoresTbl.Add(add);
        db.SaveChanges();
        return true;
    }

    public List<Score> getScores(int StudentId)
    {
        List<Score> scores = new List<Score>();
        foreach (Scores item in db.ScoresTbl.ToList())
        {
            if (item.StudentId == StudentId)
            {
                Score score = new Score { Id = item.Id, Name = item.Name, StudentId = item.StudentId, Point = item.Point };
                scores.Add(score);
            }
        }
        return scores;
    }

    public bool removeScore(int Id)
    {
        Scores remove = db.ScoresTbl.Find(Id);
        if (remove == null) { return false; }
        db.ScoresTbl.Remove(remove);
        db.SaveChanges();
        return true;
    }
    public bool removeScores(int StudentId)
    {
        foreach (Scores item in db.ScoresTbl.ToList())
        {
            if (item.StudentId == StudentId)
            {
                db.ScoresTbl.Remove(item);
            }
        }
        db.SaveChanges() ;
        return true;
    }

    public bool updateScores(UpdateScore score)
    {
        Scores update = db.ScoresTbl.Find(score.Id);
        if (update == null) { return false; }

        update.Name = score.Name;
        update.StudentId = score.StudentId;
        update.Point = score.Point;
        update.isPass = score.isPass;
        db.ScoresTbl.Update(update);
        db.SaveChanges();
        return true;
    }
}

