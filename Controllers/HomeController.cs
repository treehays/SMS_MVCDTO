using Microsoft.AspNetCore.Mvc;
using SMS_MVCDTO.Interfaces.Services;
using SMS_MVCDTO.Models;
using SMS_MVCDTO.Models.DTOs.UserDTOs;
using System.Diagnostics;

namespace SMS_MVCDTO.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _user;
        public HomeController(IUserService user, ILogger<HomeController> logger)
        {
            _user = user;
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.ShowElement1 = false;
            return View();
        }
        public IActionResult Signup ()
        {

            return View();
        }
        public IActionResult Login ()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login (LoginRequestModel loginDetails)
        {
            if (loginDetails == null)
            {
                return NotFound();
            }

            var user = _user.Login(loginDetails);
            if (user == null)
            {
                return BadRequest();
            }
            // ViewBag.ShowElement1 = true;
            TempData["success"] = "Login successful";
            return RedirectToAction(nameof(Index), "Attendant");
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
}