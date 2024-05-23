using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }

        [Required(ErrorMessage ="You must enter your Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must enter your Adress")]
        public string Address { get; set; }

        [Required(ErrorMessage = "You must enter your PhoneNumber")]
        [Phone(ErrorMessage = "PhoneNumber is not valid,Please enter a vaild Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "You must enter your Email")]
        [EmailAddress(ErrorMessage = "Email is not valid,Please enter a vaild Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "You must enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Confirm your password")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="The Password and confirmation password do not match")]
        public string ConfirmationPassword { get; set; }

        [Display(Name = "Image")]
        [DefaultValue("default.png")]
        [ValidateImage(ErrorMessage = "Please upload a valid image file")]
        public string cust_Pic { get; set; }

    public ICollection<Order> Orders { get; set; }
        public ICollection<Cart> carts { get; set; }
    }
}
