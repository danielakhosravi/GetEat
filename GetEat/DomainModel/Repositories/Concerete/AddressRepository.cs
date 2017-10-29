using DomainModel.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Entities;

namespace DomainModel.Repositories.Concerete
{
    public class AddressRepository : BaseRepository, IAddressRepository
    {
        public AddressRepository(GetEatContext database) : base(database)
        {
        }

        public void Add(Address address)
        {
            _database.Addresses.Add(address);
        }
    }
}
