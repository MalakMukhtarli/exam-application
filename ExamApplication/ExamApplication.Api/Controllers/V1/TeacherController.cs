using ExamApplication.Api.Routes;
using ExamApplication.Business.Models.Teachers;
using ExamApplication.Business.Services.Teachers;
using Microsoft.AspNetCore.Mvc;

namespace ExamApplication.Api.Controllers.V1;

[ApiController]
[Route("[controller]")]
public class TeacherController : ControllerBase
{
    [HttpGet(ApiRoutes.Teacher.GetAll)]
    public async Task<IActionResult> GetAll([FromServices] ITeacherService service)
    {
        var data = await service.GetAllAsync();
        return Ok(data);
    }

    [HttpPost(ApiRoutes.Teacher.Create)]
    public async Task<IActionResult> Create([FromBody] SaveTeacherRequest request,
        [FromServices] ITeacherService service)
    {
        var data = await service.CreateAsync(request);
        return Ok(data);
    }

    [HttpPost(ApiRoutes.Teacher.CreateLessonGrade)]
    public async Task<IActionResult> CreateLessonGradeTeacher([FromRoute] int teacherId,
        [FromBody] SaveLessonGradeTeacherRequest requests, [FromServices] ITeacherService service)
    {
        await service.CreateLessonGradeTeacherAsync(teacherId, requests);
        return Ok();
    }

    [HttpGet(ApiRoutes.Teacher.Get)]
    public async Task<IActionResult> Get([FromRoute] int teacherId, [FromServices] ITeacherService service)
    {
        var data = await service.GetByIdAsync(teacherId);
        return Ok(data);
    }

    [HttpPut(ApiRoutes.Teacher.Update)]
    public async Task<IActionResult> Update([FromRoute] int teacherId, [FromBody] List<UpdateTeacherRequest> requests,
        [FromServices] ITeacherService service)
    {
        var data = await service.UpdateAsync(teacherId, requests);
        return Ok(data);
    }

    [HttpDelete(ApiRoutes.Teacher.Delete)]
    public async Task<IActionResult> Delete([FromRoute] int teacherId, [FromServices] ITeacherService service)
    {
        await service.DeleteAsync(teacherId);
        return Ok();
    }
}