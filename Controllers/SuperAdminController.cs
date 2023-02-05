using Microsoft.AspNetCore.Mvc;
using SMS_MVCDTO.Interfaces.Services;
using SMS_MVCDTO.Models.DTOs.SuperAdminDTOs;
using SMS_MVCDTO.Models.ViewModels;
using System.Security.Claims;

namespace SMS_MVCDTO.Controllers
{
    public class SuperAdminController : Controller
    {
        private readonly ISuperAdminService _superAdmin;
        private readonly ITransactionService _transaction;
        private readonly IProductService _product;
        public SuperAdminController(ISuperAdminService superAdmin, ITransactionService transaction, IProductService product)
        {
            _superAdmin = superAdmin;
            _transaction = transaction;
            _product = product;
        }

        public IActionResult Index()
        {
            //var superAdmin = _superAdmin.GetSuperAdmins();
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
            var superAdmin = _superAdmin.GetSuperAdmins();
            return View(superAdmin);

        }
        //[Route("Example")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateSuperAdminRequestModel createSuperAdmin)
        {
            if (createSuperAdmin != null)
            {
                var existByEmail = _superAdmin.GetByEmail(createSuperAdmin.Email);
                if (existByEmail == null)
                {
                    _superAdmin.Create(createSuperAdmin);
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
            var superAdmin = _superAdmin.GetById(staffId);
            if (superAdmin == null)
            {
                return NotFound();
            }
            return View(superAdmin);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SuperAdminResponseModel updateSuperAdmin)
        {

            _superAdmin.Update(updateSuperAdmin);
            TempData["success"] = "Profile Updated Successfully.";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeletePreview(string staffId)
        {
            if (staffId != null)
            {
                var superAdmin = _superAdmin.GetById(staffId);

                if (superAdmin != null)
                {
                    return View(superAdmin);
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
                _superAdmin.Delete(staffId);
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }

        public IActionResult Details(string staffId)
        {
            if (staffId != null)
            {
                var superAdmin = _superAdmin.GetById(staffId);

                if (superAdmin != null)
                {
                    return View(superAdmin);
                }
                return NotFound();
            }

            return NotFound();
        }
    }
}
