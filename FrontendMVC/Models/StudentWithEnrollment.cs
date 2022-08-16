using FrontendMVC.ViewModels;

namespace FrontendMVC.Models
{
    public class StudentWithEnrollment
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public List<EnrollmentViewModel> Enrollments { get; set; }
    }
}
