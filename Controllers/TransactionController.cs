using Microsoft.AspNetCore.Mvc;
using SMS_MVCDTO.Interfaces.Repositories;
using SMS_MVCDTO.Interfaces.Services;
using SMS_MVCDTO.Models.DTOs.TransactionDTOs;
using SMS_MVCDTO.Models.Entities;
using System.Security.Claims;

namespace SMS_MVCDTO.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transaction;
        private readonly IProductService _product;
        private readonly ICartServices _cartService;
        private readonly ICustomerRepository _customer;

        public TransactionController(ITransactionService transaction, IProductService product, ICartServices cartServices, ICustomerRepository customer)
        {
            _transaction = transaction;
            _product = product;
            _cartService = cartServices;
            _customer = customer;
        }

        public IActionResult Index(int id)
        {
            if (id != 0)
            {
                var transactions = _transaction.GetAll();
                return View(transactions);
            }
            else
            {
                var transactions = _transaction.GetAllOrderByDate();
                return View(transactions);
            }

        }


        public IActionResult Dashboard()
        {
            var transactions = _transaction.GetAll();
            return View(transactions);
        }





        public IActionResult Create(int id)
        {
            var cart = _cartService.NotPaidByCustomerId(id);
            //var cart = _cartService.GetByTransactionId(transactionId);

            var cartTotal = cart.Sum(x => (x.Data.Total));
            var customer = _customer.GetById(id);
            var craeteTransact = new CreateTransactionRequestModel
            {
                TotalAmount = cartTotal,
                CustomeName = $"{customer.User.FirstName} {customer.User.LastName}",
                AttendanId = int.Parse(User?.FindFirst(ClaimTypes.NameIdentifier).Value),
                CustomerId = id,
            };
            return View(craeteTransact);
        }


        /// <summary>
        /// "createTransaction" contains only customerId and cashtender
        /// </summary>
        /// <param name="createTransaction"></param>
        /// <returns></returns>

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateTransactionRequestModel createTransaction)
        {
            if (createTransaction == null)
            {
                TempData["failed"] = "failed.";
                return View();
            }
            createTransaction.AttendanId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            _transaction.Create(createTransaction);
            TempData["success"] = "Created Successfully.";
            return RedirectToAction("Index");
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

        public IActionResult Details(string referenceNo)
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

        public IActionResult GetByName(string name)
        {
            if (name != null)
            {
                var transaction = _transaction.GetTransactionByCustomerName(name);
                if (transaction != null)
                {
                    return View(transaction);
                }
                return NotFound();
            }
            return NotFound();
        }

        public IActionResult GetByAttendant(string staffId)
        {
            if (staffId != null)
            {
                var transaction = _transaction.GetByStaffId(staffId);
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
