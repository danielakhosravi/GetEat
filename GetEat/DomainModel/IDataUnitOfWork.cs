using DomainModel.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public interface IDataUnitOfWork
    {
        IOrganisationRepository OrganisationRepository { get; }
        IUserProfileRepository UserProfileRepository { get; }
        IAddressRepository AddressRepository { get; }
        IRestourantRepository RestourantRepository { get; }

        GetEatContext Database { get; }

        void SaveChanges();
        Task SaveChangesAsync();

    }
}
