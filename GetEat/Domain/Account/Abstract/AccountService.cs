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
            var userProfile = new UserProfile
            {
                AspNetUserId = aspUserId,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

            _dataUnitOfWork.UserProfileRepository.Add(userProfile);
            await _dataUnitOfWork.SaveChangesAsync();
        }

        public async Task CreateRestouranteor(string aspUserId)
        {
            var userProfile = new UserProfile
            {
                AspNetUserId = aspUserId,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

            var address = new Address()
            {
                Country = "Change Me",
                City = "Change Mev",
                Street = "Change Me",
                Number = "Change Me",
                Neighborhood = "Change Me",
                Latitude = "Change Me",
                Longitude = "Change Me",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

            _dataUnitOfWork.UserProfileRepository.Add(userProfile);
            _dataUnitOfWork.AddressRepository.Add(address);
            await _dataUnitOfWork.SaveChangesAsync();

            _dataUnitOfWork.OrganisationRepository.Add(new Organisation
            {
                OwnerProfileId = userProfile.Id,
                Name = "Change Me",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                AddressId = address.Id
            });

            await _dataUnitOfWork.SaveChangesAsync();

        }

        public Organisation GetOrganisation(int userProgileId)
        {
            return _dataUnitOfWork.OrganisationRepository.GetOrganisation(userProgileId);
        }

        public int GetUserProfileId(string aspId)
        {
            var userProfile = _dataUnitOfWork.UserProfileRepository.GetUserProfileByAspId(aspId);
            if (userProfile == null)
            {
                throw new ArgumentException(nameof(aspId));
            }
            return userProfile.Id;
        }
    }
}
