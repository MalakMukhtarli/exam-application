using ExamApplication.Business.Services.Teachers;
using Microsoft.AspNetCore.Mvc;

namespace ExamApplication.Mvc.Controllers;

public class TeacherController : Controller
{
    private readonly ITeacherService _teacherService;

    public TeacherController(ITeacherService teacherService)
    {
        _teacherService = teacherService;
    }

    public async Task<IActionResult> Index()
    {
        var response = await _teacherService.GetAllAsync();
        
        return View(response);
    }
}