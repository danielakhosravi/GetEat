using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public string Description { get; set; }

        public string PhoneNumber { get; set; }

        public string WebSite { get; set; }

        public int OrganisationId { get; set; }

        [DisplayName("Kitchen Types")]
        public int KitchenId { get; set; }

        [ForeignKey("KitchenId")]
        public virtual Kitchen Kitchen { get; set; }

        public virtual ICollection<Menu> Menus { get; set; }

        [ForeignKey("OrganisationId")]
        public virtual Organisation Organisation { get; set; }

        public int AddressId { get; set; }

        [ForeignKey("AddressId")]
        public virtual Address Address { get; set; }

        public string PicGuidId { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
