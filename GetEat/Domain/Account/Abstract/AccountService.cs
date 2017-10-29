using DomainModel;
using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class AccountService : IAccountService
    {
        private readonly IDataUnitOfWork _dataUnitOfWork;

        public AccountService(IDataUnitOfWork dataUnitOfWork)
        {
            _dataUnitOfWork = dataUnitOfWork;
        }

        public async Task CreateBooker(string aspUserId)
        {
            _dataUnitOfWork.UserProfileRepository.Add(new UserProfile { AspNetUserId = aspUserId });
             await _dataUnitOfWork.SaveChangesAsync();
        }

        public async Task CreateRestouranteor(string aspUserId)
        {
            var userProfile = new UserProfile { AspNetUserId = aspUserId };
            _dataUnitOfWork.UserProfileRepository.Add(userProfile);
            _dataUnitOfWork.OrganisationRepository.Add(new Organisation { OwnerProfileId = userProfile.Id });

            await _dataUnitOfWork.SaveChangesAsync();
        }

    }
}
