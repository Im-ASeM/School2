using Microsoft.AspNetCore.Mvc;

[Route("[Action]")]
[ApiController]
public class Login:Controller
{
    IStudentProccesRepository spd;
    public Login(IStudentProccesRepository _spd)
    {
        spd = _spd;
    }


    [HttpPost]
    public IActionResult login (string username, string password)
    {
        return Ok(spd.login(username, password));
    }
}
