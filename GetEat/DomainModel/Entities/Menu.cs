using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Entities
{
    public class Menu : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Composition { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int ResourantId { get; set; }

        public Restourant Restourant { get; set; }

        [Required]
        public int KitchenId { get; set; }

        [ForeignKey("KitchenId")]
        public Kitchen Kitchen { get; set; }
    }
}
