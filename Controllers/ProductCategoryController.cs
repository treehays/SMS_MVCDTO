using Microsoft.AspNetCore.Mvc;
using SMS_MVCDTO.Interfaces.Services;
using SMS_MVCDTO.Models.DTOs.ProductCategoriesDTOs;

namespace SMS_MVCDTO.Controllers
{
    public class ProductCategoryController : Controller
    {
        private readonly IProductCategoryService _productCategory;
        public ProductCategoryController(IProductCategoryService productCategory)
        {
            _productCategory = productCategory;
        }

        public IActionResult Index()
        {
            var categories = _productCategory.GetAll();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create (CreateProductCategoryRequestModel createProductCategory)
        {
            if (createProductCategory != null)
            {
                var isExit = _productCategory.GetById(createProductCategory.Name);
                if (isExit == null)
                {
                    _productCategory.Create(createProductCategory);
                    TempData["success"] = "Category Created Successfully.";
                    return RedirectToAction("Index");
                }
                TempData["failed"] = "Category already exist.";
                return View();
            }
          
                TempData["failed"] = "Failed. ";
                return View();
           
        }


        public IActionResult Edit (string categoryCode)
        {
            var productCategory = _productCategory.GetById(categoryCode);
            if (productCategory == null)
            {
                return NotFound();
            }
            return View(productCategory);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductCategoryResponseModel productCategory)
        {

            _productCategory.Update(productCategory);
            TempData["success"] = "Updated Successfully.";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete (string categoryCode)
        {
            if (categoryCode != null)
            {
                _productCategory.Delete(categoryCode);
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }

        public IActionResult DeletePreview (string categoryCode)
        {
            if (categoryCode != null)
            {
                var productCategory = _productCategory.GetById(categoryCode);

                if (productCategory != null)
                {
                    return View(productCategory);
                }
                return NotFound();
            }
            return NotFound();
        }
    }
}
