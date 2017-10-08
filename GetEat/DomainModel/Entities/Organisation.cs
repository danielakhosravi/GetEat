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

        public string Phone { get; set; }

        public string Fax { get; set; }

        public virtual ICollection<Restourant> Restourants { get; set; }
 
    }
}
