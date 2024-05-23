using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class ProductDto
    {
        [Required(ErrorMessage = "Please enter a name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a price.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public float PriceInEGP { get; set; }

        [Required(ErrorMessage = "Please enter a description.")]
        public string Description { get; set; }
        public IFormFile? ImageFile { get; set; } 

        [Required(ErrorMessage = "Please enter a type.")]
        public string Type { get; set; }
    }
}
