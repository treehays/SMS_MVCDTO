using Microsoft.AspNetCore.Mvc;
using SMS_MVCDTO.Interfaces.Services;
using SMS_MVCDTO.Models.DTOs.TransactionDTOs;
using SMS_MVCDTO.ViewModels;

namespace SMS_MVCDTO.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transaction;
        private readonly IProductService _product;
        public TransactionController(ITransactionService transaction, IProductService product)
        {
            _transaction = transaction;
            _product = product;
        }

        public IActionResult Index()
        {
            var transactions = _transaction.GetAll();
            return View(transactions);
        }


        public IActionResult Create(string barCode)
        {
            var product = _product.GetById(barCode);
            
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateTransactionRequestModel transaction)
        {
            if (transaction != null)
            {
                _transaction.Create(transaction);
                TempData["success"] = "Created Successfully.";
                return RedirectToAction("Index");
            }
            TempData["failed"] = "failed.";
            return View();
        }

        public IActionResult DeletePreview(string referenceNo)
        {
            if (referenceNo != null)
            {
                var transaction = _transaction.GetById(referenceNo);
                if (transaction != null)
                {
                    return View(transaction);
                }
                return NotFound();
            }

            return NotFound();
        }

        public IActionResult Delete(string referenceNo)
        {
            if (referenceNo != null)
            {
                _transaction.Delete(referenceNo);
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }

        public IActionResult Details (string referenceNo)
        {
            if (referenceNo != null)
            {
                var transaction = _transaction.GetById(referenceNo);
                if (transaction != null)
                {
                    return View(transaction);
                }
                return NotFound();
            }
            return NotFound();
        }
    }


}
