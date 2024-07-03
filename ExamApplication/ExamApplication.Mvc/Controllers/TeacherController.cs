using ExamApplication.Business.Models.Teachers;
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

    [HttpPost]
    public async Task<IActionResult> Create(SaveTeacherRequest request)
    {
        await _teacherService.CreateAsync(request);
        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    public async Task<IActionResult> CreateLessonGrade(int teacherId, SaveLessonGradeTeacherRequest request)
    {
        await _teacherService.CreateLessonGradeTeacherAsync(teacherId, request);
        return RedirectToAction("Index", "Home");
    }
}