using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Repositories.Abstract;
using DomainModel.Repositories.Concerete;

namespace DomainModel
{
    public class DataUnitOfWork : IDataUnitOfWork
    {
        private GetEatContext _database;
        private IOrganisationRepository _organisationRepository;
        private IUserProfileRepository _userProfileRepository;

        public GetEatContext Database => _database ?? (_database = new GetEatContext());
        public IOrganisationRepository OrganisationRepository => _organisationRepository ?? (_organisationRepository = new OrganisationRepository(Database));

        public IUserProfileRepository UserProfileRepository => _userProfileRepository ?? (_userProfileRepository = new UserProfileRepository(Database));

        public void SaveChanges()
        {
            Database.SaveChanges();
        }

        public Task SaveChangesAsync()
        {
           return Database.SaveChangesAsync();
        }
    }
}
