using System.ComponentModel.DataAnnotations;

namespace Project.Presentation.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, ErrorMessage = "First name can't be more than 50 characters")]
        public string FirstName { get; set; } = null!;

        [StringLength(50, ErrorMessage = "Last name can't be more than 50 characters")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "User name is required")]
        [StringLength(50, ErrorMessage = "User name can't be more than 50 characters")]
        public string UserName { get; set; } = null!;
        
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = null!;

        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Password is required")]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
        [Required(ErrorMessage = "Confirm password is required")]
        public string ConfirmPassword { get; set; } = null!;

        public bool IsAgree { get; set; }
    }
}
