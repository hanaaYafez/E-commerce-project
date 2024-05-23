using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace FinalProject.Models
{
    public class User
    {
        [DefaultValue(0)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a valid email address")]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
