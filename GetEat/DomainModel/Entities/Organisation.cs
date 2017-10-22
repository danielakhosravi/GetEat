using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DomainModel.Entities
{
    public class Organisation : BaseEntity
    {        
        public int OwnerProfileId { get; set; }

        [ForeignKey("OwnerProfileId")]
        public virtual UserProfile OwnerProfile { get; set; }

        [Required]
        public string Name { get; set; }

        public string About { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        public string WebSite { get; set; }

        [ForeignKey("AddressId")]
        public virtual Address HeadOfficeAddress { get; set; }

        public int AddressId { get; set; }

        public string RegistrationNumber { get; set; }

        public virtual ICollection<Restourant> Restourants { get; set; }
 
    }
}
