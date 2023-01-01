using SMS_MVCDTO.Context;
using SMS_MVCDTO.Interfaces.Repositories;
using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Implementations.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private readonly ApplicationContext _context;
        public WalletRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Wallet Create(Wallet wallet)
        {
            _context.Wallets.Add(wallet);
            _context.SaveChanges();
            return wallet;
        }

        public double GetBalance()
        {
            var balance = _context.Wallets.Sum(x => (x.Credit - x.Debit));
            return balance;
        }

        public Wallet Credit(Wallet wallet)
        {
            _context.Wallets.Add(wallet);
            _context.SaveChanges();
            return wallet;
        }

        public Wallet Debit(Wallet wallet)
        {
            _context.Wallets.Add(wallet);
            _context.SaveChanges();
            return wallet;
        }
    }
}
