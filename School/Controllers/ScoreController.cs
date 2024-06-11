
using Microsoft.AspNetCore.Mvc;
[Route("[action]")]
[ApiController]
public class ScoreController : Controller
{
    IScoresProccesRepository spr;
    public ScoreController(IScoresProccesRepository _spr)
    {
        spr = _spr;
    }

    [HttpGet]
    public IActionResult GetScores(int StudentId)
    {
        List<Score> result = spr.getScores(StudentId);
        return result != null ? Ok(result) : NotFound();
    }
    [HttpPost]
    public IActionResult AddScore(NewScore score)
    {
        bool result = spr.addScore(score);
        return result ? Ok("done") : NotFound();
    }
    [HttpDelete]
    public IActionResult RemoveScore(int Id)
    {
        bool result = spr.removeScore(Id);
        return result ? Ok("done") : NotFound();
    }
    [HttpDelete]
    public IActionResult RemoveScores(int StudentId)
    {
        bool result = spr.removeScores(StudentId);
        return result ? Ok("done") : NotFound();
    }
    [HttpPut]
    public IActionResult UpdateScore(UpdateScore score)
    {
        bool result = spr.updateScores(score);
        return result ? Ok("done") : NotFound();
    }
}

