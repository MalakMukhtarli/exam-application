using ExamApplication.Api.Routes;
using ExamApplication.Business.Models.Grades;
using ExamApplication.Business.Services.Grades;
using Microsoft.AspNetCore.Mvc;

namespace ExamApplication.Api.Controllers.V1;

[ApiController]
[Route("[controller]")]
public class GradeController : ControllerBase
{
    [HttpGet(ApiRoutes.Grade.GetAll)]
    public async Task<IActionResult> GetAll([FromServices] IGradeService service)
    {
        var data = await service.GetAllAsync();
        return Ok(data);
    } 
    
    [HttpPost(ApiRoutes.Grade.Create)]
    public async Task<IActionResult> Create([FromRoute] byte grade, [FromServices] IGradeService service)
    {
        var data = await service.CreateAsync(grade);
        return Ok(data);
    } 
    
    [HttpGet(ApiRoutes.Grade.Get)]
    public async Task<IActionResult> Get([FromRoute] int gradeId, [FromServices] IGradeService service)
    {
        var data = await service.GetByIdAsync(gradeId);
        return Ok(data);
    }
    
    [HttpPut(ApiRoutes.Grade.Update)]
    public async Task<IActionResult> Update([FromRoute] int gradeId, [FromBody] UpdateGradeRequest request, [FromServices] IGradeService service)
    {
        var data = await service.UpdateAsync(gradeId, request);
        return Ok(data);
    } 
    
    [HttpDelete(ApiRoutes.Grade.Delete)]
    public async Task<IActionResult> Delete([FromRoute] int gradeId, [FromServices] IGradeService service)
    {
        await service.DeleteAsync(gradeId);
        return Ok();
    } 

}