using FrontendMVC.Models;
using FrontendMVC.Services.IRepository;

namespace FrontendMVC.Services
{
    public class CourseServices : ICourse
    {
        public Task<IEnumerable<Course>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
