using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GetEat.WebUI.Models
{
    public class OrganisationViewModel
    {
        public int OwnerProfileId { get; set; }

        public virtual UserProfileViewModel OwnerProfile { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        public virtual ICollection<RestourantViewModel> Restourants { get; set; }
    }
}