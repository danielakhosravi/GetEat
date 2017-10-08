using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Entities
{
    public class UserProfile : BaseEntity
    {
        [Required]
        public string AspNetUserId { get; set; }

        public string ForeName { get; set; }

        public string SurName { get; set; }

        public string PicGuidId { get; set; }
    }
}
