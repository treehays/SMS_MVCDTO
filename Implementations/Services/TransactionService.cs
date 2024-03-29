﻿using SMS_MVCDTO.Implementations.Repositories;
using SMS_MVCDTO.Interfaces.Repositories;
using SMS_MVCDTO.Interfaces.Services;
using SMS_MVCDTO.Models.DTOs.TransactionDTOs;
using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Implementations.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICartRepository _cartRepository;

        public TransactionService(ITransactionRepository transactionRepository, IProductRepository productRepository, ICustomerRepository customerRepository, ICartRepository cartRepository)
        {
            _transactionRepository = transactionRepository;
            _productRepository = productRepository;
            _customerRepository = customerRepository;
            _cartRepository = cartRepository;
        }

        public CreateTransactionRequestModel Create(CreateTransactionRequestModel transaction)
        {


            var cart = _cartRepository.NotPaidByCustomerId(transaction.CustomerId);
            if (cart == null)
            {
                return null;
            }
            var cartTotal = cart.Sum(x => (x.Quantity * x.Product.SellingPrice));


            var customers = _customerRepository.GetById(transaction.CustomerId);

            var transactio = new Transaction
            {
                CustomerId = transaction.CustomerId,
                AttendantId = transaction.AttendanId,
                AmountPaid = transaction.CashTender,
                ReferenceNo = Guid.NewGuid().ToString().Remove(10).Replace("-", "").ToUpper(),
                //CartId = transaction.CartId,
                TotalAmount = cartTotal,
                Created = DateTime.Now,
            };
            _transactionRepository.Create(transactio);
            _cartRepository.Update(transaction.CustomerId);
            return transaction;
        }

        public void Delete(string refNumber)
        {
            var transaction = _transactionRepository.GetById(refNumber);
            _transactionRepository.Delete(transaction);
        }

        public IEnumerable<TransactionResponseModel> GetAll()
        {
            var transaction = _transactionRepository.GetAll();
            var transactions = transaction.Select(item => new TransactionResponseModel
            {
                Message = "Transaction retrieved successfully",
                Status = true,
                Data = new TransactionDTOs
                {
                    ReferenceNo = item.ReferenceNo,
                    CustomerId = item.CustomerId,
                    AttendantId = item.AttendantId,
                    TotalAmount = item.TotalAmount,
                    Created = item.Created.Date,
                }

            }).ToList();
            return transactions;
        }


        public IEnumerable<TransactionResponseModel> GetAllOrderByDate()
        {
            var transaction = _transactionRepository.GetAllOrderByDate();
            var transactions = transaction.Select(item => new TransactionResponseModel
            {
                Message = "Transaction retrieved successfully",
                Status = true,
                Data = new TransactionDTOs
                {
                    ReferenceNo = item.ReferenceNo,
                    CustomerId = item.CustomerId,
                    AttendantId = item.AttendantId,
                    TotalAmount = item.TotalAmount,
                    Created = item.Created.Date,
                }

            }).ToList();
            return transactions;
        }

        public IEnumerable<TransactionResponseModel> GetByDate(DateTime dateTime)
        {
            var transaction = _transactionRepository.GetByDate(dateTime);
            var transactions = transaction.Select(item => new TransactionResponseModel
            {
                Message = "Transaction retrieved successfully",
                Status = true,
                Data = new TransactionDTOs
                {
                    ReferenceNo = item.ReferenceNo,
                    CustomerId = item.CustomerId,
                    AttendantId = item.AttendantId,
                    TotalAmount = item.TotalAmount,
                    Created = item.Created.Date,
                }

            }).ToList();
            return transactions;
        }

        public TransactionResponseModel GetById(string refNumber)
        {
            var transaction = _transactionRepository.GetById(refNumber);
            var transactio = new TransactionResponseModel
            {
                Message = "Transaction retrieved successfully",
                Status = true,
                Data = new TransactionDTOs
                {
                    ReferenceNo = transaction.ReferenceNo,
                    CustomerId = transaction.CustomerId,
                    AttendantId = transaction.AttendantId,
                    TotalAmount = transaction.TotalAmount,
                    Created = transaction.Created.Date,
                }
            };
            return transactio;
        }

        public IEnumerable<TransactionResponseModel> GetByStaffId(string staffId)
        {
            var transaction = _transactionRepository.GetByStaffId(staffId);
            var transactions = transaction.Select(item => new TransactionResponseModel
            {
                Message = "Transaction retrieved successfully",
                Status = true,
                Data = new TransactionDTOs
                {
                    ReferenceNo = item.ReferenceNo,
                    CustomerId = item.CustomerId,
                    AttendantId = item.AttendantId,
                    TotalAmount = item.TotalAmount,
                    Created = item.Created.Date,
                }

            }).ToList();
            return transactions;
        }

        public IEnumerable<TransactionResponseModel> GetTransactionByCustomerName(string customerName)
        {
            var transaction = _transactionRepository.GetTransactionByCustomerName(customerName);
            var transactions = transaction.Select(item => new TransactionResponseModel
            {
                Message = "Transaction retrieved successfully",
                Status = true,
                Data = new TransactionDTOs
                {
                    ReferenceNo = item.ReferenceNo,
                    CustomerId = item.CustomerId,
                    AttendantId = item.AttendantId,
                    TotalAmount = item.TotalAmount,
                    Created = item.Created.Date,
                }
            }).ToList();
            return transactions;
        }
    }

}