using FrontendMVC.Models;
using FrontendMVC.ViewModels;

namespace FrontendMVC.Services.IRepository
{
    public interface IStudent
    {
        Task<IEnumerable<Student>> GetAll();
        Task<Student> GetById(int id);
        Task<Student> Insert(StudentCreateViewModel obj);
        Task<Student> Update(Student obj);
        Task Delete(int id);
        Task<IEnumerable<StudentWithEnrollment>> GetWithEnrollment();
        Task<IEnumerable<Student>> SearchByName(string name);
    }
}
