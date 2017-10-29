using DomainModel.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Entities;

namespace DomainModel.Repositories.Concerete
{
    public class RestourantRepository : BaseRepository, IRestourantRepository
    {
        public RestourantRepository(GetEatContext database) : base(database)
        {
        }

        public void Add(Restourant restourant)
        {
            _database.Restourants.Add(restourant);
        }
    }
}
