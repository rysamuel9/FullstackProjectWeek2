using FrontendMVC.Models;

namespace FrontendMVC.Services.IRepository
{
    public interface ICourse
    {
        Task<IEnumerable<Course>> GetAll();
        Task<Course> GetById(int id);
    }
}
