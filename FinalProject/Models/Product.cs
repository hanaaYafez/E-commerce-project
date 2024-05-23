using System.ComponentModel.DataAnnotations;
using System.IO;

namespace FinalProject.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a price.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public float PriceInEGP { get; set; }

        [Required(ErrorMessage = "Please enter a description.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please select an image.")]
        [DataType(DataType.Upload)]
        public string Image { get; set; } // This property will be used for file upload in the view

        [Required(ErrorMessage = "Please enter a type.")]
        public string Type { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
