using FrontendMVC.Models;
using FrontendMVC.ViewModels;

namespace FrontendMVC.Services.IRepository
{
    public interface IEnrollment
    {
        Task<IEnumerable<Enrollment>> GetAll();
        Task<Enrollment> GetById(int id);
        Task<Enrollment> Insert(EnrollmentCreateViewModel obj);
        Task<Enrollment> Update(Enrollment obj);
        Task Delete(int id);
    }
}
