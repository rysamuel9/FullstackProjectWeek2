using FrontendMVC.Models;
using FrontendMVC.ViewModels;

namespace FrontendMVC.Services.IRepository
{
    public interface IEnrollment
    {
        Task<Enrollment> Insert(EnrollmentCreateViewModel obj);
    }
}
