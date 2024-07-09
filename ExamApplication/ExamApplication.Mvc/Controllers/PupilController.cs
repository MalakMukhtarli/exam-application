using ExamApplication.Business.Models.Pupils;
using ExamApplication.Business.Services.Pupils;
using Microsoft.AspNetCore.Mvc;

namespace ExamApplication.Mvc.Controllers;

public class PupilController : Controller
{
    private readonly IPupilService _pupilService;

    public PupilController(IPupilService pupilService)
    {
        _pupilService = pupilService;
    }

    public async Task<IActionResult> Index()
    {
        var response = await _pupilService.GetAll();
        return View(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(SavePupilRequest request)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            return Json(new { success = false, errors });
        }
        
        await _pupilService.Create(request);
        return Json(new { success = true, redirectUrl = Url.Action("Index", "Home") });
    }
}