using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Entities
{
    public class Booking :BaseEntity
    {
        public int RestourantId { get; set; }

        public int UserProfileId { get; set; }

        public DateTime ReservationDateTime { get; set; }

        public int NumberOfPeople { get; set; }

        public string Request { get; set; }

        public bool IsConfirmed { get; set; }

        public ICollection<Menu> Orders { get; set; }
    }
}
