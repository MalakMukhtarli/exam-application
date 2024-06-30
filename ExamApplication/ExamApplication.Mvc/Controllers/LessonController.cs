using ExamApplication.Business.Services.Lessons;
using Microsoft.AspNetCore.Mvc;

namespace ExamApplication.Mvc.Controllers;

public class LessonController : Controller
{
    private readonly ILessonService _lessonService;

    public LessonController(ILessonService lessonService)
    {
        _lessonService = lessonService;
    }

    public async Task<IActionResult> Index()
    {
        var response = await _lessonService.GetAllAsync();
        
        return View(response);
    }
}