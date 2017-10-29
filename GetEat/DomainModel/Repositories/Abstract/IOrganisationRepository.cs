using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Repositories.Abstract
{
    public interface IOrganisationRepository
    {
        void Add(Organisation organisation);
    }
}
