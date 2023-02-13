using Microsoft.AspNetCore.Mvc;
using SMS_MVCDTO.Interfaces.Services;
using SMS_MVCDTO.Models.Entities;
using SMS_MVCDTO.Models.ViewModels;
using System.Security.Claims;

namespace SMS_MVCDTO.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartServices _cart;
        private readonly IProductService _product;
        public CartController(ICartServices cart, IProductService product)
        {
            _cart = cart;
            _product = product;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(string barCode)
        {
            var product = _product.GetById(barCode);
            if (product == null)
            {
                //return View("Error");
                return NotFound();
            }

            var loggedinUser = User?.FindFirst(ClaimTypes.NameIdentifier);

            string attendant;
            if (loggedinUser == null)
            {
                attendant = "ATT001";
            }
            else
            {
                attendant = User?.FindFirst(ClaimTypes.NameIdentifier).Value;
                var b = User.FindFirstValue("NameIdentifier");
            }
            /*
                        var activeAttendantId = new CreateCartRequestModel
                        {
                            AttendantId = attendant,
                        };
            */


            var productTransact = new AddToCartProductViewModel
            {
                Product = product,
                //Transaction = activeAttendantId,
            };

            return View(productTransact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AddToCartProductViewModel cartProduct)
        {

            var cart = cartProduct.CartRequestModel;

            if (cart == null)
            {
                TempData["failed"] = "failed.";
                return View();
            }
            cart.ProductId = cartProduct.Product.Data.Barcode;
            var cartsCreated = _cart.Create(cart);
            if (cartsCreated == null)
            {
                TempData["failed"] = "Failed to add product to cart .";
                return View();
            }
            TempData["success"] = "Product added to cart Successfully.";
            return RedirectToAction("Index", "Product");
        }

        /*
                public IActionResult GetByTransactionId (string transactionId)
                {
                    var cart = _cart.GetByTransactionId(transactionId);
                    var cartTotal = cart.Sum(x => x.Data.Total);
                    var cartCartTotal = new CartTotalViewModel
                    {
                        CartTotal = cartTotal,
                        ListOfCartProduccts = cart,
                        //CartId = cartId.Data.TransactionId,
                    };
                    //there should be a form under this page tha accept cash tender and customer id from route(transaction ) this will create transaction

                    return View(cartCartTotal);
                }
        */

        public IActionResult ViewCustomerCart(string customerId)
        {
            var cartId = _cart.NotPaidExist(customerId);
            if (cartId == null)
            {
                return NotFound();
            }
            var cart = _cart.NotPaidByCustomerId(customerId);
            var cartTotal = cart.Sum(x => x.Data.Total);
            var cartCartTotal = new CartTotalViewModel
            {
                CartTotal = cartTotal,
                ListOfCartProduccts = cart,
                CartId = cartId.Data.TransactionId,
            };
            //there should be a form under this page tha accept cash tender and customer id from route(transaction ) this will create transaction

            return View(cartCartTotal);
        }

        public IActionResult GetAllPendingTransaction()
        {
            var carts = _cart.GetAllPendingTransaction();
            return View(carts);
        }

    }
}
