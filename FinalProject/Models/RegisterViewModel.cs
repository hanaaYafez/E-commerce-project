using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public class RegistrationViewModel
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }

    [Required]
    public string Address { get; set; }

    [Required]
    [StringLength(11, MinimumLength = 11, ErrorMessage = "Phone Number must be 11 digits long.")]
    public string PhoneNumber { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [RegularExpression(@"^(?=.*[a-zA-Z]).{8,}$", ErrorMessage = "Password must be at least 8 characters long and contain at least one letter.")]
    public string Password { get; set; }

    [Required]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    [DataType(DataType.Password)]
    public string ConfirmationPassword { get; set; }

    [Display(Name = "Image")]
    [DefaultValue("default.png")]
    [ValidateImage(ErrorMessage = "Please upload a valid image file")]
    public string cust_Pic { get; set; }
}
