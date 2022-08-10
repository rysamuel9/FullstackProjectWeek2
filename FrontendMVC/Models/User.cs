using System.ComponentModel.DataAnnotations;

namespace FrontendMVC.Models
{
    public class User
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}
