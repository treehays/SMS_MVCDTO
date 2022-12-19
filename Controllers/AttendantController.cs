using Microsoft.AspNetCore.Mvc;
using SMS_MVCDTO.DTOs.AttendantDTOs;
using SMS_MVCDTO.Interfaces.Services;

namespace SMS_MVCDTO.Controllers
{
    public class AttendantController : Controller
    {
        private readonly IAttendantService _attendant;
        public AttendantController(IAttendantService attendant)
        {
            _attendant = attendant;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateAttendant()
        {
            return View();
        }

        public IActionResult CreateAttendant(CreateAttendantRequestModel createAttendant)
        {
            if (createAttendant != null)
            {
                var existByEmail = _attendant.GetByEmail(createAttendant.Email);
                if (existByEmail != null)
                {
                    _attendant.Create(createAttendant);
                    TempData["success"] = "Registration Successful.    ";
                    return RedirectToAction("Index");
                }
                TempData["failed"] = "Email already Exist.";
                return View();
            }
            else
            {
                TempData["failed"] = "Incomplete details, Registration Failed";
                return View();
            }
        }
    }
}
