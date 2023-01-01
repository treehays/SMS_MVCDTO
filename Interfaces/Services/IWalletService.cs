using SMS_MVCDTO.Models.DTOs.WalletDTOs;
using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Interfaces.Services
{
    public interface IWalletService
    {
       CreateWalletRequestModel Create (CreateWalletRequestModel wallet);
        double GetBalance ();
        CreditWalletRequestModel Credit (CreditWalletRequestModel wallet);
        DebitWalletRequestModel Debit (DebitWalletRequestModel wallet);
    }
}
