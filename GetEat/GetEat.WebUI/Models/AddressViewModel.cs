using System.ComponentModel.DataAnnotations;

namespace GetEat.WebUI.Models
{
    public class AddressViewModel
    {
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Neighborhood { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string Number { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }
    }
}