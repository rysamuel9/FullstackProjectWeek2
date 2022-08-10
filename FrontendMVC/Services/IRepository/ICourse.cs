using FrontendMVC.Models;
using FrontendMVC.ViewModels;

namespace FrontendMVC.Services.IRepository
{
    public interface ICourse
    {
        Task<IEnumerable<Course>> GetAll();
        Task<Course> GetById(int id);
        Task<Course> Insert(CourseCreateViewModel obj);
    }
}
