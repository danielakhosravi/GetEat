using DomainModel.Entities;

namespace DomainModel.Repositories.Abstract
{
    public interface IAddressRepository
    {
        void Add(Address address);
    }
}