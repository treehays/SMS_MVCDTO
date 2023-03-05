﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SMS_MVCDTO.Interfaces.Services;
using SMS_MVCDTO.Models;
using SMS_MVCDTO.Models.DTOs.UserDTOs;
using System.Diagnostics;
using System.Security.Claims;

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
            //ViewBag.ShowElement1 = true;
            return View();
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



        public IActionResult Signup()
        {

            return View();
        }
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginRequestModel loginDetails)
        {
            /**********************************************/
            //checking if the l=TagHelperServicesExtensions details is null
            if (loginDetails == null)
            {
                TempData["failed"] = "Login Failed...";
                return View();
            }


            var user = _user.Login(loginDetails);

            if (user == null)
            {
                TempData["failed"] = "Login Failed...";
                return View();
            }
            byte[] imageData = user.Data.ProfilePicture;

            /*
                        ViewBag.Image = "data:image/jpeg;base64," + Convert.ToBase64String(imageData);
                        ViewData["ImageData"] = imageData;
            */



            var roles = new List<string>();
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role, user.Data.RoleId.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, user.Data.StaffId),
                    new Claim(ClaimTypes.Name, user.Data.Name),
                    new Claim(ClaimTypes.Email, user.Data.Email),
                    new Claim(ClaimTypes.PrimarySid, user.Data.Id.ToString()),
                };

            var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authenticationProperties = new AuthenticationProperties();
            var principal = new ClaimsPrincipal(claimIdentity);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authenticationProperties);

            if (user.Data.RoleId == 3)
            {
                // ViewBag.ShowElement1 = true;
                TempData["success"] = "Login successful";
                return RedirectToAction(nameof(Index), "Attendant");

            }
            else if (user.Data.RoleId == 1)
            {
                // ViewBag.ShowElement1 = true;
                TempData["success"] = "Login successful";
                return RedirectToAction(nameof(Index), "SuperAdmin");

            }
            else if (user.Data.RoleId == 4)
            {
                // ViewBag.ShowElement1 = true;
                TempData["success"] = "Login successful";
                return RedirectToAction(nameof(Index), "Customer");

            }
            else if (user.Data.RoleId == 2)
            {
                // ViewBag.ShowElement1 = true;
                TempData["success"] = "Login successful";
                return RedirectToAction(nameof(Index), "SalesManager");

            }
            else
            {
                // ViewBag.ShowElement1 = true;
                TempData["success"] = "Your Account has not been activated.";
                return RedirectToAction(nameof(Index), "Home");

            }


        }
        public IActionResult Logout()
        {
            //HttpContext.Session.Clear();
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }

    }
}