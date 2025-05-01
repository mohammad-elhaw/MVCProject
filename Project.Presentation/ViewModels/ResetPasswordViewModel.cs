using System.ComponentModel.DataAnnotations;

namespace Project.Presentation.ViewModels;

public class ResetPasswordViewModel
{
    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Required(ErrorMessage = "Confirm Password is required")]
    [Compare("Password", ErrorMessage = "Confirm Password don't match password")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; } = null!;
}
