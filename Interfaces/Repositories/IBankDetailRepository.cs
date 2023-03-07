using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Interfaces.Repositories
{
    public interface IBankDetailRepository
    {
        BankDetail Create(BankDetail bankDetail);
        BankDetail Update(BankDetail bankDetail);
        void Delete(BankDetail bankDetail);
        BankDetail GetById(string id);

    }
}
