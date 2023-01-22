using Microsoft.AspNetCore.Mvc;
using SMS_MVCDTO.Interfaces.Services;
using SMS_MVCDTO.Models.DTOs.AttendantDTOs;
using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Controllers
{
    //[HideDiv]
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
            //ViewBag.ShowElement1 = true;
            return View(attendants);
        }

         public IActionResult Dashboard()
        {
            var attendants = _attendant.GetAttendants();
            //ViewBag.ShowElement1 = true;
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

        public IActionResult Details(string staffId)
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

        //get  single  by stff id
        public IActionResult GetByStaffId(string staffId)
        {
            var user = _attendant.GetById(staffId);
            return View(user);
        }

        //get a single admin by email
        public IActionResult GetByEmail(string email)
        {
            var user = _attendant.GetByEmail(email);
            return View(user);
        }
        
        //get a single admin by email
        public IActionResult GetByName (string name)
        {
            var user = _attendant.GetByName(name);
            return View(user);
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
