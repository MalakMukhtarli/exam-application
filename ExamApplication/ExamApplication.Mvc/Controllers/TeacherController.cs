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
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            return Json(new { success = false, errors });
        }
        
        await _teacherService.CreateAsync(request);
        return Json(new { success = true, redirectUrl = Url.Action("Index", "Home") });
    }

    [HttpPost]
    public async Task<IActionResult> CreateLessonGrade(int teacherId, SaveLessonGradeTeacherRequest request)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            return Json(new { success = false, errors });
        }
        
        await _teacherService.CreateLessonGradeTeacherAsync(teacherId, request);
        return Json(new { success = true, redirectUrl = Url.Action("Index", "Home") });
    }
}