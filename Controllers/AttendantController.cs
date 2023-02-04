using Microsoft.AspNetCore.Mvc;
using SMS_MVCDTO.Interfaces.Services;
using SMS_MVCDTO.Models.DTOs.AttendantDTOs;
using SMS_MVCDTO.Models.ViewModels;

namespace SMS_MVCDTO.Controllers
{
    public class AttendantController : Controller
    {
        private readonly IAttendantService _attendant;
        private readonly ITransactionService _transaction;
        private readonly IProductService _product;
        /// <summary>
        /// Change to siingle attendant
        /// </summary>
        /// <param name="attendant"></param>
        /// <param name="transaction"></param>
        /// <param name="product"></param>
        public AttendantController(IAttendantService attendant, ITransactionService transaction, IProductService product)
        {

            _attendant = attendant;
            _transaction = transaction;
            _product = product;
        }

        public IActionResult Index()
        {
            //var attendants = _attendant.GetAttendants();
            //ViewBag.ShowElement1 = true;
            var transactions = _transaction.GetAll();
            var products = _product.BelowReorderLevel();
            var productTransaction = new TransactionProductListsViewModel
            {
                Transaction = transactions,
                Product = products,
            };
            return View(productTransaction);
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
                    return RedirectToAction("Index", "SuperAdmin");
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
            if (staffId != null)
            {
                var user = _attendant.GetById(staffId);

                if (user != null)
                {
                    return View(user);
                }
                return NotFound();
            }

            return NotFound();
            //var user = _attendant.GetById(staffId);
            //return View(user);
        }

        //get a single admin by email
        public IActionResult GetByEmail(string email)
        {

            if (email != null)
            {
                var user = _attendant.GetByEmail(email);
                if (user != null)
                {
                    return View(user);
                }
                return NotFound();
            }
            return NotFound();

            //var user = _attendant.GetByEmail(email);
            //return View(user);
        }

        //get a single admin by email
        public IActionResult GetByName(string name)
        {
            if (name != null)
            {
                var user = _attendant.GetByName(name);
                if (user != null)
                {
                    return View(user);
                }
                return NotFound();
            }
            return NotFound();
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
