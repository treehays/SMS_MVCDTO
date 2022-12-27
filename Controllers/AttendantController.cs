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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateAttendantRequestModel createAttendant)
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

        public IActionResult Edit(string staffId)
        {
            var attendant = _attendant.GetById(staffId);
            if (attendant == null)
            {
                return NotFound();
            }
            return View(attendant);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AttendantResponseModel updateAttendant)
        {
            //var matricNumber = HttpContext.Session.GetString("MatricNumber");
            //var candidate = _candidateService.GetCandidateByMatricNumber(matricNumber);
            //var attendant = _attendant.GetById(updateAttendant.StaffId);
            //if (attendant == null)
            //{
            //    return NotFound($"Attendant does not Exist");
            //}

            _attendant.Update(updateAttendant);
            TempData["success"] = "Profile Updated Successfully.";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeletePreview(string staffId)
        {
            if (staffId != null)
            {
                var attendant = _attendant.GetById(staffId);

                if (attendant != null)
                {
                    return View(attendant);
                }
                return NotFound();
            }

            return NotFound();
        }

        //[ValidateAntiForgeryToken]
        //[HttpPost, ActionName("Delete")]
        public IActionResult Delete(string staffId)
        {
            if (staffId != null)
            {
                _attendant.Delete(staffId);
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }

        public IActionResult Detail(string staffId)
        {

            return View();
        }
    }
}










// public IActionResult CreateAttendant()
//{
//    //var elections = _electionService.GetElections();
//    //ViewData["Elections"] = new SelectList(elections.Data, "Id", "Name");
//    //var positions = _positionService.GetPositions();
//    //ViewData["Positions"] = new SelectList(positions.Data, "Id", "Name");

//    return View();
//}
