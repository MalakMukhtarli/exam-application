using ExamApplication.Business.Models.Lessons;
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

    [HttpPost]
    public async Task<IActionResult> Create(SaveLessonRequest request)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            return Json(new { success = false, errors });
        }

        await _lessonService.CreateAsync(request);
        return Json(new { success = true, redirectUrl = Url.Action("Index", "Home") });
    }
}