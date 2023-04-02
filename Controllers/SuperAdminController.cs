using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using SMS_MVCDTO.Interfaces.Services;
using SMS_MVCDTO.Models.DTOs.SuperAdminDTOs;
using SMS_MVCDTO.Models.ViewModels;

namespace SMS_MVCDTO.Controllers
{
    //[Authorize(Roles = "SuperAdmin")]
    public class SuperAdminController : Controller
    {
        private readonly ISuperAdminService _superAdmin;
        private readonly ITransactionService _transaction;
        private readonly IProductService _product;
        private readonly IWebHostEnvironment _hostEnvironment;
        public SuperAdminController(ISuperAdminService superAdmin, ITransactionService transaction, IProductService product, IWebHostEnvironment hostEnvironment)
        {
            _superAdmin = superAdmin;
            _transaction = transaction;
            _product = product;
            _hostEnvironment = hostEnvironment;
        }

        // [Authorize(Roles = "SuperAdmin")]
        public IActionResult Index()
        {
            TempData["TheKey"] = "Welcome";
            //var superAdmin = _superAdmin.GetSuperAdmins();
            var transactions = _transaction.GetAll();
            ViewBag.Title = transactions;
            var products = _product.BelowReorderLevel();
            var productTransaction = new TransactionProductListsViewModel
            {
                Transaction = transactions,
                Product = products,
            };

            return View(productTransaction);
        }

        // [Authorize(Roles = "SuperAdmin")]
        public IActionResult Dashboard()
        {
            var superAdmin = _superAdmin.GetSuperAdmins();
            return View(superAdmin);

        }

        // [Authorize(Roles = "null")]
        public IActionResult Create()
        {
            return View();
        }

        // [Authorize(Roles = "null")]
        public IActionResult Creates()
        {
            return View();
        }


        public async Task<IActionResult> Creates(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file was uploaded.");
            }

            var uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return View();
        }


        // [Authorize(Roles = "null")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateSuperAdminRequestModel createSuperAdmin)
        {
            if (ModelState.IsValid)
            {
                var emailExist = _superAdmin.EmailExist(createSuperAdmin.Email);
                if (!emailExist)
                {
                    //adding profile picture
                    if (Request.Form.Files.Count > 0)
                    {
                        IFormFile file = Request.Form.Files.FirstOrDefault();
                        using (var dataStream = new MemoryStream())
                        {
                            await file.CopyToAsync(dataStream);
                            createSuperAdmin.ProfilePicture = dataStream.ToArray();
                        }
                        _superAdmin.Create(createSuperAdmin);
                        TempData["success"] = "Account created succesfully.";
                        return RedirectToAction(nameof(Index), "Home");
                    }
                    _superAdmin.Create(createSuperAdmin);
                    TempData["success"] = "Account created succesfully.";
                    return RedirectToAction(nameof(Index), "Home");

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

        // [Authorize(Roles = "SuperAdmin")]
        public IActionResult Edit(string staffId)
        {
            var superAdmin = _superAdmin.GetById(staffId);
            if (superAdmin == null)
            {
                return View();
            }
            return View(superAdmin);
        }


        //[Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SuperAdminResponseModel updateSuperAdmin)
        {
            if (updateSuperAdmin == null)
            {
                TempData["failed"] = "Fill all required field.";
                return View();
            }
            if (Request.Form.Files.Count > 0)
            {
                IFormFile file = Request.Form.Files.FirstOrDefault();
                using (var dataStream = new MemoryStream())
                {
                    await file.CopyToAsync(dataStream);
                    updateSuperAdmin.Data.ProfilePicture = dataStream.ToArray();
                }
                _superAdmin.Update(updateSuperAdmin);
                TempData["success"] = "Profile Updated Successfully.";
                return RedirectToAction(nameof(Index), "Home");
            }
            _superAdmin.Update(updateSuperAdmin);
            TempData["success"] = "Profile Updated Successfully.";
            return RedirectToAction(nameof(Index), "Home");
        }

        //if (updateSuperAdmin == null)
        //{
        //    TempData["failed"] = "Fill all required field.";
        //    return View();
        //}
        //_superAdmin.Update(updateSuperAdmin);
        //TempData["success"] = "Profile Updated Successfully.";
        //return RedirectToAction(nameof(Index), "Home");

        // [Authorize(Roles = "null")]
        public IActionResult DeletePreview(string staffId)
        {
            if (staffId != null)
            {
                var superAdmin = _superAdmin.GetById(staffId);

                if (superAdmin != null)
                {
                    return View(superAdmin);
                }
                return View();
            }

            return View();
        }

        //[ValidateAntiForgeryToken]
        //[HttpPost, ActionName("Delete")]

        // [Authorize(Roles = "SuperAdmin")]
        public IActionResult Delete(string staffId)
        {
            if (staffId != null)
            {
                _superAdmin.Delete(staffId);
                TempData["failed"] = "Deleted Successfully";
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }


        // [Authorize(Roles = "SuperAdmin")]
        public IActionResult Details(string staffId)
        {
            if (staffId != null)
            {
                var superAdmin = _superAdmin.GetById(staffId);

                if (superAdmin != null)
                {
                    return View(superAdmin);
                }
                return View();
            }

            return View();
        }
    }
}
