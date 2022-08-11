using FrontendMVC.Models;
using FrontendMVC.Services.IRepository;
using FrontendMVC.ViewModels;
using Newtonsoft.Json;
using System.Text;

namespace FrontendMVC.Services
{
    public class CourseServices : ICourse
    {
        public async Task Delete(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync($"https://localhost:7093/api/Courses/{id}"))
                {
                    if (response.StatusCode != System.Net.HttpStatusCode.OK)
                        throw new Exception($"Gagal untuk delete data");
                }
            }
        }

        public async Task<IEnumerable<Course>> GetAll()
        {
            List<Course> courses = new List<Course>();
            using (var httpClient = new HttpClient())
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
            Course course = new Course();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"https://localhost:7093/api/Courses/{id}"))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        course = JsonConvert.DeserializeObject<Course>(apiResponse);
                    }
                }
            }

            return course;
        }

        public async Task<Course> Insert(CourseCreateViewModel obj)
        {
            Course course = new Course();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:7093/api/Courses", content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.Created)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        course = JsonConvert.DeserializeObject<Course>(apiResponse);
                    }
                }
            }

            return course;
        }

        public async Task<Course> Update(Course obj)
        {

            Course course = await GetById(obj.CourseID);
            if (course == null)
                throw new Exception($"Data course dengan id {obj.CourseID} tidak ditemukan");
            StringContent content = new StringContent(JsonConvert.SerializeObject(obj),
                  Encoding.UTF8, "application/json");
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PutAsync($"https://localhost:7093/api/Courses/{obj.CourseID}", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    course = JsonConvert.DeserializeObject<Course>(apiResponse);
                }
            }
            return course;
        }
    }
}
