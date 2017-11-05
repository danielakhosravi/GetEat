using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GetEat.WebUI.Models
{
    public class RestourantViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }


        public int OrganisationId { get; set; }

        public virtual OrganisationViewModel Organisation { get; set; }

        public int AddressId { get; set; }

        public virtual AddressViewModel Address { get; set; }

        public string PicGuidId { get; set; }

        public virtual ICollection<ReviewViewModel> Reviews { get; set; }
        public int KitchenId { get;  set; }
    }
}