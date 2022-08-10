using System.ComponentModel.DataAnnotations;

namespace FrontendMVC.ViewModels
{
    public class UserViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string Token { get; set; }
    }
}
