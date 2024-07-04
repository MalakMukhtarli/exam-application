using System.Diagnostics;
using ExamApplication.Business.Services.Grades;
using ExamApplication.Business.Services.LessonGrades;
using ExamApplication.Business.Services.Teachers;
using ExamApplication.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using ExamApplication.Mvc.Models;

namespace ExamApplication.Mvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IGradeService _gradeService;
    private readonly ILessonGradeService _lessonGradeService;
    private readonly ITeacherService _teacherService;

    public HomeController(ILogger<HomeController> logger, IGradeService gradeService, ILessonGradeService lessonGradeService, ITeacherService teacherService)
    {
        _logger = logger;
        _gradeService = gradeService;
        _lessonGradeService = lessonGradeService;
        _teacherService = teacherService;
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.Grades = await _gradeService.GetAllAsync();
        ViewBag.LessonGrade = await _lessonGradeService.GetAllAsync();
        ViewBag.Teachers = await _teacherService.GetAllAsync();
        
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}