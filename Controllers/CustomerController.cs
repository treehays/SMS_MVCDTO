using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SMS_MVCDTO.Interfaces.Services;
using SMS_MVCDTO.Models.DTOs.CustomerDTOs;

namespace SMS_MVCDTO.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customer;
        public CustomerController(ICustomerService customer)
        {
            _customer = customer;
        }

        public IActionResult Index()
        {
            var customers = _customer.GetCustomers();
            return View(customers);
        }

        //[Authorize(Roles = "Attendant")]

        public IActionResult Dashboard()
        {
            var customers = _customer.GetCustomers();
            return View(customers);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateCustomerRequestModel createCustomer)
        {
            if (createCustomer != null)
            {
                var existByEmail = _customer.GetByEmail(createCustomer.Email);
                if (existByEmail == null)
                {
                    _customer.Create(createCustomer);
                    TempData["success"] = "Customer Created Successfully.";
                    return RedirectToAction("Index");
                }
                TempData["failed"] = "Email already exist.";
                return View();
            }
            TempData["failed"] = "Registration failed because of incomplete details.";
            return View();
        }

        public IActionResult Edit(int id)
        {
            var customer = _customer.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CustomerResponseModel editCustomer)
        {
            _customer.Update(editCustomer);
            TempData["success"] = "profile updated Successfully.";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeletePreview(int id)
        {
            if (id != 0)
            {
                var customer = _customer.GetById(id);
                if (customer != null)
                {
                    return View(customer);
                }
                return NotFound();
            }

            return NotFound();
        }

        public IActionResult Delete(int id)
        {
            if (id != 0)
            {
                _customer.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }

        public IActionResult Details(int id)
        {
            if (id != 0)
            {
                var customer = _customer.GetById(id);
                if (customer != null)
                {
                    return View(customer);
                }
                return NotFound();
            }
            return NotFound();
        }
    }
}
