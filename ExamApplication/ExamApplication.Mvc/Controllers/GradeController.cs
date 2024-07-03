using ExamApplication.Business.Services.Grades;
using Microsoft.AspNetCore.Mvc;

namespace ExamApplication.Mvc.Controllers;

public class GradeController : Controller
{
    private readonly IGradeService _gradeService;

    public GradeController(IGradeService gradeService)
    {
        _gradeService = gradeService;
    }

    public async Task<IActionResult> Index()
    {
        var response = await _gradeService.GetAll();
        
        return View(response);
    }
}