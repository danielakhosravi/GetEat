using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Entities
{
    public class Event : BaseEntity
    {
        public string Name { get; set; }

        public int RestourantId { get; set; }

        public string Description { get; set; }

        public DateTime EventDateTime { get; set; }
    }
}
