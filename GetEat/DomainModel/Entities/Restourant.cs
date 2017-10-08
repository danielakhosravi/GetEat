using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Entities
{
    public class Restourant : BaseEntity
    {
        //public int ManagerProfileId { get; set; }

        //[ForeignKey("ManagerProfileId")]
        //public virtual UserProfile ManagerProfile { get; set; }

        public string Name { get; set; }

        public int OrganisationId { get; set; }

        [ForeignKey("OrganisationId")]
        public virtual Organisation Organisation { get; set; }

        public int AddressId { get; set; }

        [ForeignKey("AddressId")]
        public virtual Address Address { get; set; }

        public string PicGuidId { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
