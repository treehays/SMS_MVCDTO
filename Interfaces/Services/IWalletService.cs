using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Interfaces.Services
{
    public interface IWalletService
    {
        Wallet Create(Wallet wallet);
        double GetBalance(Wallet wallet);
        Wallet Update(Wallet wallet);

    }
}
