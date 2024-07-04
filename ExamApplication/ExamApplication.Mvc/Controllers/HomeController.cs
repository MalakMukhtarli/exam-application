using System.Diagnostics;
using ExamApplication.Business.Services.Grades;
using ExamApplication.Business.Services.LessonGrades;
using ExamApplication.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using ExamApplication.Mvc.Models;

namespace ExamApplication.Mvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IGradeService _gradeService;
    private readonly ILessonGradeService _lessonGradeService;

    public HomeController(ILogger<HomeController> logger, IGradeService gradeService, ILessonGradeService lessonGradeService)
    {
        _logger = logger;
        _gradeService = gradeService;
        _lessonGradeService = lessonGradeService;
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.Grades = await _gradeService.GetAllAsync();
        ViewBag.LessonGrade = await _lessonGradeService.GetAllAsync();
        
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