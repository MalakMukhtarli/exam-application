using System.Diagnostics;
using ExamApplication.Business.Services.Exams;
using ExamApplication.Business.Services.Grades;
using ExamApplication.Business.Services.LessonGrades;
using ExamApplication.Business.Services.Pupils;
using ExamApplication.Business.Services.Teachers;
using Microsoft.AspNetCore.Mvc;
using ExamApplication.Mvc.Models;
using ExamApplication.Mvc.ViewModels;

namespace ExamApplication.Mvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IGradeService _gradeService;
    private readonly ILessonGradeService _lessonGradeService;
    private readonly ITeacherService _teacherService;
    private readonly IExamService _examService;
    private readonly IPupilService _pupilService;

    public HomeController(ILogger<HomeController> logger, 
        IGradeService gradeService, 
        ILessonGradeService lessonGradeService, 
        ITeacherService teacherService, IExamService examService, IPupilService pupilService)
    {
        _logger = logger;
        _gradeService = gradeService;
        _lessonGradeService = lessonGradeService;
        _teacherService = teacherService;
        _examService = examService;
        _pupilService = pupilService;
    }

    public async Task<IActionResult> Index()
    {
        var result = new HomeViewModel
        {
            Data = new GetAllDataViewModel
            {
                Grades = await _gradeService.GetAllAsync(),
                LessonGrades = await _lessonGradeService.GetAllAsync(),
                Teachers = await _teacherService.GetAllForSelectAsync(),
                Exams = await _examService.GetAllForSelect()
            }
        };
        return View(result);
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