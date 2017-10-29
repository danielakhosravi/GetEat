using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Repositories.Concerete
{
    public class BaseRepository
    {
        public GetEatContext _database;

        public BaseRepository(GetEatContext database)
        {
            _database = database;
        }
    }
}
