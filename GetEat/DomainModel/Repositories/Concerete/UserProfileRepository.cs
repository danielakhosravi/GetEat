using DomainModel.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Entities;

namespace DomainModel.Repositories.Concerete
{
    public class UserProfileRepository : BaseRepository, IUserProfileRepository
    {
        public UserProfileRepository(GetEatContext database) : base(database)
        {
        }

        public void Add(UserProfile userProfile)
        {
            _database.UserProfiles.Add(userProfile);
        }
    }
}
