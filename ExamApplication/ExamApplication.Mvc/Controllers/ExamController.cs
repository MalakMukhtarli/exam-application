using ExamApplication.Business.Models.Exams;
using ExamApplication.Business.Models.PupilExams;
using ExamApplication.Business.Services.Exams;
using Microsoft.AspNetCore.Mvc;

namespace ExamApplication.Mvc.Controllers;

public class ExamController : Controller
{
    private readonly IExamService _examService;

    public ExamController(IExamService examService)
    {
        _examService = examService;
    }

    public async Task<IActionResult> Index()
    {
        var response = await _examService.GetAll();
        return View(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(SaveExamRequest request)
    {
        await _examService.Create(request);
        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    public async Task<IActionResult> CreateMark(UpdatePupilExamRequest request)
    {
        await _examService.UpdatePupilExam(request);
        return RedirectToAction("Index", "Home");
    }
}