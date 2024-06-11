using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

[Route("[action]")]
[ApiController]
public class StudentController : Controller
{
    IStudentProccesRepository spr;
    public StudentController(IStudentProccesRepository _spd)
    {
        spr = _spd;
    }

    [HttpGet]
    public IActionResult GetAllStudent()
    {
        return Ok(spr.getStudents());
    }
    [HttpGet]
    public IActionResult GetStudent(int id)
    {
        Student result = spr.getStudent(id);
        return result!=null ? Ok(result) : NotFound();
    }
    [HttpPost]
    public IActionResult AddStudent(NewStudent student)
    {
        spr.addStudent(student);
        return Ok();
    }
    [HttpDelete]
    public IActionResult DeleteStudent(int id)
    {
        bool result = spr.removeStudent(id);
        return result ? Ok("Done") : NotFound();
    }
    [HttpPut]
    public IActionResult UpdateStudent(UpdateStudent student)
    {
        bool result = spr.updateStudent(student);
        return result ? Ok("Done") : NotFound();
    }

}
