using FrontendMVC.Models;
using FrontendMVC.Services.IRepository;
using FrontendMVC.ViewModels;
using Newtonsoft.Json;

namespace FrontendMVC.Services
{
    public class StudentServices : IStudent
    {
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            List<Student> students = new List<Student>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7093/api/Students"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    students = JsonConvert.DeserializeObject<List<Student>>(apiResponse);
                }
            }

            return students;
        }

        public Task<Student> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Student> Insert(StudentCreateViewModel obj)
        {
            throw new NotImplementedException();
        }

        public Task<Student> Update(Student obj)
        {
            throw new NotImplementedException();
        }
    }
}
