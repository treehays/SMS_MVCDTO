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
        public TransactionService(ITransactionRepository transaction, IProductRepository product, ICustomerRepository customer)
        {
            _transaction = transaction;
            _product = product;
            _customer = customer;
        }

        public CreateTransactionRequestModel Create(CreateTransactionRequestModel transaction)
        {
            var customers = _customer.GetById(transaction.CustomerId);
            var product = _product.GetById(transaction.BarCode);
            if (product == null)
            {
                return null;
            }
            var transactio = new Transaction
            {
                ReferenceNo = Guid.NewGuid().ToString().Remove(10).Replace("-", ""),
                CustomerId = transaction.CustomerId,
                AttendantId = transaction.AttendantId,
                ProductId = transaction.BarCode,
                Quantity = transaction.Quantity,
                TotalAmount = product.SellingPrice * transaction.Quantity,
                Created = DateTime.Now,
                CustomerName = $"{customers.FirstName} {customers.LastName}"
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
            var transactions = _transaction.GetAll();
            var transactionResponse = new List<TransactionResponseModel>();
            foreach (var transaction in transactions)
            {
                var transactio = new TransactionResponseModel
                {
                    Message = "Transaction retrieved successfully",
                    Status = true,
                    Data = new TransactionDTOs
                    {
                        ReferenceNo = transaction.ReferenceNo,
                        CustomerId = transaction.CustomerId,
                        AttendantId = transaction.AttendantId,
                        BarCode = transaction.ProductId,
                        Quantity = transaction.Quantity,
                        TotalAmount = transaction.TotalAmount,
                        Created = transaction.Created,
                        CustomerName = transaction.CustomerName,
                    }
                };
                transactionResponse.Add(transactio);
            }
            return transactionResponse;
        }

        public IEnumerable<TransactionResponseModel> GetAllOrderByDate()
        {
            var transactions = _transaction.GetAllOrderByDate();
            var transactionResponse = new List<TransactionResponseModel>();
            foreach (var transaction in transactions)
            {
                var transactio = new TransactionResponseModel
                {
                    Message = "Transaction retrieved successfully",
                    Status = true,
                    Data = new TransactionDTOs
                    {
                        ReferenceNo = transaction.ReferenceNo,
                        CustomerId = transaction.CustomerId,
                        AttendantId = transaction.AttendantId,
                        BarCode = transaction.ProductId,
                        Quantity = transaction.Quantity,
                        TotalAmount = transaction.TotalAmount,
                        Created = transaction.Created,
                        CustomerName = transaction.CustomerName,
                    }
                };
                transactionResponse.Add(transactio);
            }
            return transactionResponse;
        }

        public IEnumerable<TransactionResponseModel> GetByDate(DateTime dateTime)
        {
            var transactions = _transaction.GetByDate(dateTime);
            var transactionResponse = new List<TransactionResponseModel>();
            foreach (var transaction in transactions)
            {
                var transactio = new TransactionResponseModel
                {
                    Message = "Transaction retrieved successfully",
                    Status = true,
                    Data = new TransactionDTOs
                    {
                        ReferenceNo = transaction.ReferenceNo,
                        CustomerId = transaction.CustomerId,
                        AttendantId = transaction.AttendantId,
                        BarCode = transaction.ProductId,
                        Quantity = transaction.Quantity,
                        TotalAmount = transaction.TotalAmount,
                        Created = transaction.Created,
                        CustomerName = transaction.CustomerName,
                    }
                };
                transactionResponse.Add(transactio);
            }
            return transactionResponse;
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
                    BarCode = transaction.ProductId,
                    Quantity = transaction.Quantity,
                    TotalAmount = transaction.TotalAmount,
                    Created = transaction.Created,
                    CustomerName = transaction.CustomerName,
                }
            };
            return transactio;
        }

        public IEnumerable<TransactionResponseModel> GetByStaffId(string staffId)
        {
            var transactions = _transaction.GetByStaffId(staffId);
            var transactionResponse = new List<TransactionResponseModel>();
            foreach (var transaction in transactions)
            {
                var transactio = new TransactionResponseModel
                {
                    Message = "Transaction retrieved successfully",
                    Status = true,
                    Data = new TransactionDTOs
                    {
                        ReferenceNo = transaction.ReferenceNo,
                        CustomerId = transaction.CustomerId,
                        AttendantId = transaction.AttendantId,
                        BarCode = transaction.ProductId,
                        Quantity = transaction.Quantity,
                        TotalAmount = transaction.TotalAmount,
                        Created = transaction.Created,
                        CustomerName = transaction.CustomerName,
                    }
                };
                transactionResponse.Add(transactio);
            }
            return transactionResponse;
        }

        public IEnumerable<TransactionResponseModel> GetTransactionByCustomerName(string customerName)
        {
            var transactions = _transaction.GetTransactionByCustomerName(customerName);
            var transactionResponse = new List<TransactionResponseModel>();
            foreach (var transaction in transactions)
            {
                var transactio = new TransactionResponseModel
                {
                    Message = "Transaction retrieved successfully",
                    Status = true,
                    Data = new TransactionDTOs
                    {
                        ReferenceNo = transaction.ReferenceNo,
                        CustomerId = transaction.CustomerId,
                        AttendantId = transaction.AttendantId,
                        BarCode = transaction.ProductId,
                        Quantity = transaction.Quantity,
                        TotalAmount = transaction.TotalAmount,
                        Created = transaction.Created,
                        CustomerName = transaction.CustomerName,
                    }
                };
                transactionResponse.Add(transactio);
            }
            return transactionResponse;
        }

        //public IEnumerable<TransactionResponseModel> DownloadExcel()
        //{
        //    throw new NotImplementedException();
        //}
    }

}