using FrontendMVC.Models;
using FrontendMVC.Services.IRepository;
using Newtonsoft.Json;

namespace FrontendMVC.Services
{
    public class CourseServices : ICourse
    {
        public async Task<IEnumerable<Course>> GetAll()
        {
            List<Course> courses = new List<Course>();
            using(var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7093/api/Courses"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    courses = JsonConvert.DeserializeObject<List<Course>>(apiResponse);
                }
            }

            return courses;
        }

        public async Task<Course> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
