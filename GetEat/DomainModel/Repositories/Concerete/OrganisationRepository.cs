using DomainModel.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Entities;

namespace DomainModel.Repositories.Concerete
{
    public class OrganisationRepository :BaseRepository, IOrganisationRepository
    {
        public OrganisationRepository(GetEatContext database) : base(database)
        {
        }

        public void Add(Organisation organisation)
        {
            _database.Organisations.Add(organisation);
        }
    }
}
