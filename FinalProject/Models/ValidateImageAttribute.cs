using System;
using System.ComponentModel.DataAnnotations;

public class ValidateImageAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        // Check if the value is null
        if (value == null)
        {
            return new ValidationResult("The image is required.");
        }

        // Convert the value to a string
        var strValue = value.ToString();

        // Check if the string is empty or contains only whitespace
        if (string.IsNullOrWhiteSpace(strValue))
        {
            return new ValidationResult("The image is required.");
        }

        // Validate image extension
        var allowedExtensions = new[] { ".png", ".jpg", ".jpeg", ".gif" };
        var fileExtension = System.IO.Path.GetExtension(strValue).ToLower();

        if (!allowedExtensions.Contains(fileExtension))
        {
            return new ValidationResult("The file must be a valid image with extensions: .png, .jpg, .jpeg, .gif");
        }


        // Return success if the image passes all checks
        return ValidationResult.Success;
    }
}
