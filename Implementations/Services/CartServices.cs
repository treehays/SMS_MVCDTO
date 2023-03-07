using SMS_MVCDTO.Interfaces.Repositories;
using SMS_MVCDTO.Interfaces.Services;
using SMS_MVCDTO.Models.DTOs.CartDTOs;
using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Implementations.Services
{
    public class CartServices : ICartServices
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        public CartServices(ICartRepository cartRepository, IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }
        public CreateCartRequestModel Create(CreateCartRequestModel cart)
        {
            //string transactionId;
            //check if the customer have any unpaid product

            var productQuantity = _productRepository.GetById(cart.ProductId);
            if (productQuantity.Quantity < cart.Quantity)
            {
                return null;
            }
            var customer = _cartRepository.NotPaidExist(cart.CustomerId);

            var carts = new Cart
            {
                CustomerId = cart.CustomerId,
                Quantity = cart.Quantity,
                IsDeleted = false,
                IsPaid = false,
                Created = DateTime.Now,
                ProductId = cart.ProductId
                //TransactionId = (customer == null) ? Guid.NewGuid().ToString() : customer.TransactionId,
                //Price = productQuantity.SellingPrice,
                //ProductName = productQuantity.Name,
            };
            //will later allpw create to return bool if sucessful
            _cartRepository.Create(carts);
            productQuantity.Quantity -= cart.Quantity;
            _productRepository.Update(productQuantity);
            return cart;
        }

        public void Delete(string id)
        {
            var cart = _cartRepository.GetById(id);
            _cartRepository.Delete(cart);
        }

        public IEnumerable<CartResponseModel> GetAll()
        {
            var carts = _cartRepository.GetAll();
            var cartResponseModel = carts.Select(item => new CartResponseModel
            {
                Message = "Cart retrieved successfully",
                Status = true,
                Data = new CartDTO
                {
                    ProductId = item.ProductId,
                    CustomerId = item.CustomerId,
                    TransactionId = item.TransactionId,
                    Quantity = item.Quantity,
                    IsPaid = item.IsPaid,
                    Id = item.Id,
                }
            });
            return cartResponseModel;
        }


        public IEnumerable<CartResponseModel> GetAllPendingTransaction()
        {
            var carts = _cartRepository.GetAllPendingTransaction();
            var cartResponseModel = carts.Select(item => new CartResponseModel
            {
                Message = "Cart retrieved successfully",
                Status = true,
                Data = new CartDTO
                {
                    ProductId = item.ProductId,
                    CustomerId = item.CustomerId,
                    TransactionId = item.TransactionId,
                    Quantity = item.Quantity,
                    IsPaid = item.IsPaid,
                    Id = item.Id,
                }
            });
            return cartResponseModel;
        }

        public CartResponseModel GetById(string id)
        {
            var cart = _cartRepository.GetById(id);
            var cartResponseModel = new CartResponseModel
            {
                Message = "Cart retrieved successfully..",
                Status = true,
                Data = new CartDTO
                {
                    ProductId = cart.ProductId,
                    CustomerId = cart.CustomerId,
                    TransactionId = cart.TransactionId,
                    Quantity = cart.Quantity,
                    IsPaid = cart.IsPaid,
                    Id = cart.Id,
                }
            };
            return cartResponseModel;
        }

        public IEnumerable<CartResponseModel> GetByTransactionId(string transactionId)
        {
            var carts = _cartRepository.GetByTransactionId(transactionId);
            var cartsResponseModel = carts.Select(item => new CartResponseModel
            {
                Message = "Cart retrieved successfully",
                Status = true,
                Data = new CartDTO
                {
                    ProductId = item.ProductId,
                    CustomerId = item.CustomerId,
                    TransactionId = item.TransactionId,
                    Quantity = item.Quantity,
                    IsPaid = item.IsPaid,
                    Id = item.Id,
                }
            });
            return cartsResponseModel;
        }
        /// <summary>
        /// Getting all the list of order which has not been paid for
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>null if not fund and return list of carts</returns>
        public IEnumerable<CartResponseModel> NotPaidByCustomerId(string customerId)
        {
            var carts = _cartRepository.NotPaidByCustomerId(customerId);
            if (carts == null)
            {
                return null;
            }

            /*
            var listCartsResponseModel = new List<CartResponseModel>();
             * foreach (var item in carts)
            {
                var cartsResponseModel = new CartResponseModel
                {
                    Message = "Cart retrieved successfully",
                    Status = true,
                    Data = new CartDTO
                    {
                        ProductId = item.ProductId,
                        CustomermId = item.CustomermId,
                        TransactionId = item.TransactionId,
                        Quantity = item.Quantity,
                        IsPaid = item.IsPaid,
                        Id = item.Id,
                    }
                };
                listCartsResponseModel.Add(cartsResponseModel);
            }*/
            var listCartsResponseModel = carts.Select(item => new CartResponseModel
            {
                Message = "Cart retrieved successfully",
                Status = true,
                Data = new CartDTO
                {
                    ProductId = item.ProductId,
                    //ProductName = item.ProductName,
                    CustomerId = item.CustomerId,
                    TransactionId = item.TransactionId,
                    Quantity = item.Quantity,
                    IsPaid = item.IsPaid,
                    Id = item.Id,
                    Total = item.Quantity * item.Product.SellingPrice,
                    ProductPrice = item.Product.SellingPrice,
                }
            });
            return listCartsResponseModel;
        }

        public double GetCartTotal(string customerId)
        {
            var cartTotal = _cartRepository.GetCartTotal(customerId);
            return cartTotal;
        }


        //will be deleted later
        public CartResponseModel NotPaidExist(string customerId)
        {
            var cart = _cartRepository.NotPaidExist(customerId);
            var cartResponseModel = new CartResponseModel
            {
                Message = "Cart retrieved successfully",
                Status = true,
                Data = new CartDTO
                {
                    ProductId = cart.ProductId,
                    CustomerId = cart.CustomerId,
                    TransactionId = cart.TransactionId,
                    Quantity = cart.Quantity,
                    IsPaid = cart.IsPaid,
                    Id = cart.Id,
                }
            };
            return cartResponseModel;
        }

        //public string Update(int customerId)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<UpdateCartRequestModel> Update(string customerId)
        //{
        //    var carts = _cartRepository.NotPaidByCustomerId(customerId);
        //    if (carts == null)
        //    {
        //        return null;
        //    }

        //    foreach (var item in carts)

        //    {
        //        item.IsPaid = true;
        //        _cartRepository.Update(item);
        //    }


        //    var listCartsResponseModel = carts.Select(item => new UpdateCartRequestModel
        //    {
        //        TransactionId = item.TransactionId,
        //        Quantity = item.Quantity,
        //        IsPaid = item.IsPaid,

        //    });
        //    return listCartsResponseModel;

        //}

    }
}
