using System.ComponentModel.DataAnnotations;

namespace Project.Presentation.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage ="Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        public bool RememberMe { get; set; }
    }
}
