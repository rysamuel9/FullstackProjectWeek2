using System.ComponentModel.DataAnnotations;

namespace FrontendMVC.ViewModels
{
    public class CourseCreateViewModel
    {
        [Required]
        public string Title { get; set; }
        
        [Required]
        public int Credits { get; set; }
    }
}
