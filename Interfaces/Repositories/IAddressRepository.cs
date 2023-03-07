using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Interfaces.Repositories
{
    public interface IAddressRepository
    {
        Address Create(Address address);
        Address Update(Address address);
        void Delete(Address address);
        Address GetById(string id);
    }
}
