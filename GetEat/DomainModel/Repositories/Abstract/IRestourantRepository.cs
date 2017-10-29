using DomainModel.Entities;

namespace DomainModel.Repositories.Abstract
{
    public interface IRestourantRepository
    {
        void Add(Restourant restourant);
    }
}