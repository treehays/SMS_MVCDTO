using SMS_MVCDTO.Interfaces.Repositories;
using SMS_MVCDTO.Interfaces.Services;
using SMS_MVCDTO.Models.DTOs.WalletDTOs;
using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Implementations.Services
{
    public class WalletService : IWalletService
    {
        private readonly IWalletRepository _wallet;
        public WalletService(IWalletRepository wallet)
        {
            _wallet = wallet;
        }

        public CreateWalletRequestModel Create(CreateWalletRequestModel wallet)
        {
            var walle = new Wallet
            {
                CustomerId= wallet.CustomerId,
                Debit = wallet.Debit,
                Credit = wallet.Credit,
            };
        _wallet.Create(walle);
            return wallet;
        }

        public CreditWalletRequestModel Credit(CreditWalletRequestModel wallet)
        {
            var walle = new Wallet
            {
                CustomerId= wallet.CustomerId,
                Credit = wallet.Credit,
            };
            _wallet.Credit(walle);
            return wallet;

        }

        public DebitWalletRequestModel Debit(DebitWalletRequestModel wallet)
        {
            var walle = new Wallet
            {
                CustomerId = wallet.CustomerId,
                Debit = wallet.Debit,
            };
            _wallet.Credit(walle);
            return wallet;

        }

        public double GetBalance()
        {
            var balance = _wallet.GetBalance();
            return balance;
        }
    }
}
