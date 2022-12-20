using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SMS_MVCDTO.DTOs.AttendantDTOs;
using SMS_MVCDTO.Interfaces.Services;
using System.ComponentModel.Design;

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
            var attendants = _attendant.GetAttendants();
            return View(attendants);
        }

        public IActionResult CreateAttendant()
        {
            //var elections = _electionService.GetElections();
            //ViewData["Elections"] = new SelectList(elections.Data, "Id", "Name");
            //var positions = _positionService.GetPositions();
            //ViewData["Positions"] = new SelectList(positions.Data, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAttendant(CreateAttendantRequestModel createAttendant)
        {
            if (createAttendant != null)
            {
                var existByEmail = _attendant.GetByEmail(createAttendant.Email);
                if (existByEmail == null)
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
