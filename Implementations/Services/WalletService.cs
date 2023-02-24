using SMS_MVCDTO.Interfaces.Repositories;
using SMS_MVCDTO.Interfaces.Services;
using SMS_MVCDTO.Models.DTOs.WalletDTOs;
using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Implementations.Services
{
    public class WalletService : IWalletService
    {
        private readonly IWalletRepository _walletRepository;
        public WalletService(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        public CreateWalletRequestModel Create(CreateWalletRequestModel wallet)
        {
            var walle = new Wallet
            {
                CustomerId = wallet.CustomerId,
                Debit = wallet.Debit,
                Credit = wallet.Credit,
            };
            _walletRepository.Create(walle);
            return wallet;
        }

        public CreditWalletRequestModel Credit(CreditWalletRequestModel wallet)
        {
            var walle = new Wallet
            {
                CustomerId = wallet.CustomerId,
                Credit = wallet.Credit,
            };
            _walletRepository.Credit(walle);
            return wallet;

        }

        public DebitWalletRequestModel Debit(DebitWalletRequestModel wallet)
        {
            var walle = new Wallet
            {
                CustomerId = wallet.CustomerId,
                Debit = wallet.Debit,
            };
            _walletRepository.Credit(walle);
            return wallet;

        }

        public double GetBalance()
        {
            var balance = _walletRepository.GetBalance();
            return balance;
        }
    }
}
