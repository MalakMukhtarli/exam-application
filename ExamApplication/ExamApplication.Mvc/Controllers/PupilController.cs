﻿using ExamApplication.Business.Services.Pupils;
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
}