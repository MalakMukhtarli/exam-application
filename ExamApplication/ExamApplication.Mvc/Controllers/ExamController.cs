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
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            return Json(new { success = false, errors });
        }
        
        await _examService.Create(request);
        return Json(new { success = true, redirectUrl = Url.Action("Index", "Home") });
    }

    [HttpPost]
    public async Task<IActionResult> CreateMark(UpdatePupilExamRequest request)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            return Json(new { success = false, errors });
        }
        
        await _examService.UpdatePupilExam(request);
        return Json(new { success = true, redirectUrl = Url.Action("Index", "Home") });
    }

    [HttpGet]
    public async Task<JsonResult> GetAllPupilsByExamId(int examId)
    {
        var pupils = await _examService.GetAllPupilsByExamId(examId);
        return Json(pupils);
    }
}