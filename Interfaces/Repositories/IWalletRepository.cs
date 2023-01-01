using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Interfaces.Repositories
{
    public interface IWalletRepository
    {
        Wallet Create(Wallet wallet);
        double GetBalance();
        Wallet Credit (Wallet wallet);
        Wallet Debit (Wallet wallet);
    }
}
