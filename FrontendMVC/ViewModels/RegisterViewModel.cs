using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FrontendMVC.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmation Password")]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password Not Match!")]
        public string ConfirmPassword { get; set; }

    }
}
