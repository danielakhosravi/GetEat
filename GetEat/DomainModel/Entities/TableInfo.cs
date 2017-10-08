using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Entities
{
    public class TableInfo : BaseEntity
    {
        public int RestourantId { get; set; }

        [ForeignKey("RestourantId")]
        public virtual Restourant Restourant { get; set; }
    }
}
