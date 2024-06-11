public interface IScoresProccesRepository
{
    bool addScore(NewScore score);
    bool removeScore(int Id);
    bool removeScores(int StudentId);
    bool updateScores(UpdateScore score);
    List<Score> getScores(int StudentId);
}

