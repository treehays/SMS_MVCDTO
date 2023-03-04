using Microsoft.AspNetCore.Mvc;
using SMS_MVCDTO.Interfaces.Services;
using SMS_MVCDTO.Models.ViewModels;

namespace SMS_MVCDTO.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _product;
        private readonly IProductCategoryService _category;
        public ProductController(IProductService product, IProductCategoryService category)
        {
            _product = product;
            _category = category;
        }

        public IActionResult Index()
        {
            var product = _product.GetAll();
            return View(product);
        }

        public IActionResult BelowReorderLevel()
        {
            var product = _product.BelowReorderLevel();
            return View(product);
        }

        public IActionResult Dashboard()
        {
            var product = _product.GetAll();
            return View(product);
        }

        public IActionResult Create()
        {
            var categories = _category.GetAll().ToList();
            var viewModel = new NewProductViewModel
            {
                PCategory = categories
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(NewProductViewModel product)
        {

            // if (product != null)
            // {
            var existByName = _product.GetByBarCode(product.CreateProduct.Barcode);
            if (existByName != null)
            {
                TempData["failed"] = "Product already exist..";
                return View(product);
            }

            _product.Create(product.CreateProduct);
            TempData["success"] = "Created Successfully.";
            return RedirectToAction("Dashboard", "Attendant");

            /*  if (Request.Form.Files.Count > 0)
                  {
                      IFormFile file = Request.Form.Files.FirstOrDefault();
                      using (var dataStream = new MemoryStream())
                      {
                          await file.CopyToAsync(dataStream);
                          product.CreateProduct.PicturePath = dataStream.ToArray();
                      }
                      //_product.Create(product.CreateProduct);
                      //TempData["success"] = "Created Successfully.";
                      ////return RedirectToAction("Index");
                      //return RedirectToAction("Dashboard", "Attendant");
                  }*/
            //return RedirectToAction("Index");
            //TempData["failed"] = "already exist.";
            //return View();
            //_product.Create(product.CreateProduct);
            //TempData["success"] = "Created Successfully.";
            //return RedirectToAction("Index");
            //return RedirectToAction("Dashboard", "Attendant");
            //}
            //TempData["failed"] = "failed.";
            //return View(product);

            //     TempData["failed"] = "failed.";
            //     return View(product);
            // }
        }

        public IActionResult Edit(int id)
        {

            var product = _product.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            var categories = _category.GetAll().ToList();
            var viewModel = new NewProductViewModel
            {
                UpdateProduct = product,
                PCategory = categories,
            };
            return View(viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(NewProductViewModel product)
        {
            if (product != null)
            {
                _product.Update(product.UpdateProduct);
                TempData["success"] = "product updated Successfully.";
                return RedirectToAction(nameof(Index));
            }
            TempData["failed"] = "failed.";
            return View(product);
        }


        public IActionResult DeletePreview(int id)
        {
            if (id != 0)
            {
                var product = _product.GetById(id);
                if (product != null)
                {
                    return View(product);
                }
                return NotFound();
            }

            return NotFound();
        }

        public IActionResult Delete(int id)
        {
            if (id != 0)
            {
                _product.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }

        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var product = _product.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public IActionResult DetailsBarCode(string barCode)
        {
            if (barCode == null)
            {
                return NotFound();
            }

            var product = _product.GetByBarCode(barCode);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        public IActionResult GetById(int id)
        {
            if (id != 0)
            {
                var product = _product.GetById(id);
                if (product != null)
                {
                    return View(product);
                }
                return NotFound();
            }
            return NotFound();
        }

        public IActionResult GetByName(string name)
        {
            if (name != null)
            {
                var product = _product.GetByName(name);
                if (product != null)
                {
                    return View(product);
                }
                return NotFound();
            }
            return NotFound();
        }
    }
}
