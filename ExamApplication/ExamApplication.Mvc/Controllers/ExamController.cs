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
}