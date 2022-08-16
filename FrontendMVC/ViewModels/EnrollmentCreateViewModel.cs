using FrontendMVC.Models;

namespace FrontendMVC.ViewModels
{
    public enum Grade
    {
        A, B, C, D, F
    }
    public class EnrollmentCreateViewModel
    {
        public int StudentID { get; set; }
        public int CourseID { get; set; }
        public Grade? Grade { get; set; }
        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
