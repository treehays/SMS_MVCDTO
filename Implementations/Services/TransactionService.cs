using SMS_MVCDTO.Interfaces.Repositories;
using SMS_MVCDTO.Interfaces.Services;
using SMS_MVCDTO.Models.DTOs.TransactionDTOs;
using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Implementations.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transaction;
        private readonly IProductRepository _product;
        private readonly ICustomerRepository _customer;
        private readonly ICartRepository _cart;
        private readonly IAttendantRepository _attendant;

        public TransactionService(ITransactionRepository transaction, IProductRepository product, ICustomerRepository customer, ICartRepository cart)
        {
            _transaction = transaction;
            _product = product;
            _customer = customer;
            _cart = cart;
        }

        public CreateTransactionRequestModel Create(CreateTransactionRequestModel transaction)
        {


            var cart = _cart.NotPaidByCustomerId(transaction.CustomerId);
            if (cart == null)
            {
                return null;
            }
            var cartTotal = cart.Sum(x => (x.Quantity * x.Price));


            var customers = _customer.GetById(transaction.CustomerId);
            var attendant = _attendant.GetById(transaction.CustomerId);

            var transactio = new Transaction
            {
                ReferenceNo = Guid.NewGuid().ToString().Remove(10).Replace("-", "").ToUpper(),
                CustomerId = transaction.CustomerId,
                AttendantId = transaction.AttendantId,
                CartId = transaction.CartId,
                //AttendantName = attendant.FirstName,
                //Quantity = transaction.Quantity,
                TotalAmount = cartTotal,
                Created = DateTime.Now,
                //CustomerName = $"{customers.FirstName.ToUpper()}  {customers.LastName}"
            };
            _transaction.Create(transactio);

            return transaction;
        }

        public void Delete(string refNumber)
        {
            var transaction = _transaction.GetById(refNumber);
            _transaction.Delete(transaction);
        }

        public IEnumerable<TransactionResponseModel> GetAll()
        {
            var transaction = _transaction.GetAll();
            var transactions = transaction.Select(item => new TransactionResponseModel
            {
                Message = "Transaction retrieved successfully",
                Status = true,
                Data = new TransactionDTOs
                {
                    ReferenceNo = item.ReferenceNo,
                    CustomerId = item.CustomerId,
                    AttendantId = item.AttendantId,
                    //BarCode = item.ProductId,
                    //Quantity = item.Quantity,
                    TotalAmount = item.TotalAmount,
                    Created = item.Created.Date,
                    //CustomerName = item.CustomerName,
                }

            }).ToList();
            return transactions;
        }


        public IEnumerable<TransactionResponseModel> GetAllOrderByDate()
        {
            var transaction = _transaction.GetAllOrderByDate();
            var transactions = transaction.Select(item => new TransactionResponseModel
            {
                Message = "Transaction retrieved successfully",
                Status = true,
                Data = new TransactionDTOs
                {
                    ReferenceNo = item.ReferenceNo,
                    CustomerId = item.CustomerId,
                    AttendantId = item.AttendantId,
                    //BarCode = item.ProductId,
                    //Quantity = item.Quantity,
                    TotalAmount = item.TotalAmount,
                    Created = item.Created.Date,
                    //CustomerName = item.CustomerName,
                }

            }).ToList();
            return transactions;
        }

        public IEnumerable<TransactionResponseModel> GetByDate(DateTime dateTime)
        {
            var transaction = _transaction.GetByDate(dateTime);
            var transactions = transaction.Select(item => new TransactionResponseModel
            {
                Message = "Transaction retrieved successfully",
                Status = true,
                Data = new TransactionDTOs
                {
                    ReferenceNo = item.ReferenceNo,
                    CustomerId = item.CustomerId,
                    AttendantId = item.AttendantId,
                    //BarCode = item.ProductId,
                    //Quantity = item.Quantity,
                    TotalAmount = item.TotalAmount,
                    Created = item.Created.Date,
                    //CustomerName = item.CustomerName,
                }

            }).ToList();
            return transactions;
        }

        public TransactionResponseModel GetById(string refNumber)
        {
            var transaction = _transaction.GetById(refNumber);
            var transactio = new TransactionResponseModel
            {
                Message = "Transaction retrieved successfully",
                Status = true,
                Data = new TransactionDTOs
                {
                    ReferenceNo = transaction.ReferenceNo,
                    CustomerId = transaction.CustomerId,
                    AttendantId = transaction.AttendantId,
                    //BarCode = transaction.ProductId,
                    //Quantity = transaction.Quantity,
                    TotalAmount = transaction.TotalAmount,
                    Created = transaction.Created.Date,
                    //CustomerName = transaction.CustomerName,
                }
            };
            return transactio;
        }

        public IEnumerable<TransactionResponseModel> GetByStaffId(string staffId)
        {
            var transaction = _transaction.GetByStaffId(staffId);
            var transactions = transaction.Select(item => new TransactionResponseModel
            {
                Message = "Transaction retrieved successfully",
                Status = true,
                Data = new TransactionDTOs
                {
                    ReferenceNo = item.ReferenceNo,
                    CustomerId = item.CustomerId,
                    AttendantId = item.AttendantId,
                    //BarCode = item.ProductId,
                    //Quantity = item.Quantity,
                    TotalAmount = item.TotalAmount,
                    Created = item.Created.Date,
                    //CustomerName = item.CustomerName,
                }

            }).ToList();
            return transactions;
        }

        public IEnumerable<TransactionResponseModel> GetTransactionByCustomerName(string customerName)
        {
            var transaction = _transaction.GetTransactionByCustomerName(customerName);
            var transactions = transaction.Select(item => new TransactionResponseModel
            {
                Message = "Transaction retrieved successfully",
                Status = true,
                Data = new TransactionDTOs
                {
                    ReferenceNo = item.ReferenceNo,
                    CustomerId = item.CustomerId,
                    AttendantId = item.AttendantId,
                    //BarCode = item.ProductId,
                    //Quantity = item.Quantity,
                    TotalAmount = item.TotalAmount,
                    Created = item.Created.Date,
                    //CustomerName = item.CustomerName,
                }

            }).ToList();
            return transactions;
        }

        //public IEnumerable<TransactionResponseModel> DownloadExcel()
        //{
        //    throw new NotImplementedException();
        //}
    }

}