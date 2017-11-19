using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GetEat.WebUI.Models
{
    public class OrganisationViewModel
    {
        public int Id { get; set;
        }
        public int OwnerProfileId { get; set; }

        public virtual UserProfileViewModel OwnerProfile { get; set; }

        [Required]
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        public virtual ICollection<RestourantViewModel> Restourants { get; set; }
    }
}