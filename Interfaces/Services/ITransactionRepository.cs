﻿using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Interfaces.Services
{
    public interface ITransactionService
    {
        Transaction Create(Transaction transaction);
        Transaction Update(Transaction transaction);
        void Delete(Transaction transaction);
        IList<Transaction> GetAll();
        IList<Transaction> GetByDate();
        Transaction GetById(string Id);
        IList<Transaction> GetByStaffId(string staffId);
        IList<Transaction> GetTransactionByCustomerName(string transaction);
        IList<Transaction> DownloadExcel();

    }
}