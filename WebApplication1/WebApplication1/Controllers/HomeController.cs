using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    //[HttpPost]
    //public  IActionResult Create(string skills)
    //{
    //    Skill skill= new Skill()
    //    {
    //        Skills = JsonSerializer.Deserialize<string[]>(skills)
    //    };

    //    return View(skills);
    //} 

    [HttpPost]
    public IActionResult Create(string skills, Skill skillinput)
    {
        Skill skill = new Skill()
        {
            SkillsArray = JsonSerializer.Deserialize<string[]>(skills),
            Title= skillinput.Title,   
            Experience= skillinput.Experience
          
        };

        return View(skill);
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