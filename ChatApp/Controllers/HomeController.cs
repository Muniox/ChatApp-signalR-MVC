using ChatApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ChatApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private const string UserKey = "USER_KEY";

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var userName = HttpContext.Session.GetString(UserKey);

        if (string.IsNullOrEmpty(userName))
        {
            return RedirectToAction(nameof(SignIn));
        }

        var vm = new IndexVm()
        {
            UserName = userName
        };

        return View(vm);
    }

    [HttpGet]
    public IActionResult SignIn()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SignIn(SignInWm vm)
    {
        if (!ModelState.IsValid)
        {
            return View(vm);
        }

        SignInUser(vm.UserName);

        return RedirectToAction(nameof(Index));
    }

    private void SignInUser(string vmUserName)
    {
        HttpContext.Session.SetString(key: UserKey, value: vmUserName);
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
