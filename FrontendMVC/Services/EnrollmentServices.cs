using FrontendMVC.Models;
using FrontendMVC.Services.IRepository;
using FrontendMVC.ViewModels;
using Newtonsoft.Json;
using System.Text;

namespace FrontendMVC.Services
{
    public class EnrollmentServices : IEnrollment
    {
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Enrollment>> GetAll()
        {
            List<Enrollment> enrollments = new List<Enrollment>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7093/api/Enrollments"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    enrollments = JsonConvert.DeserializeObject<List<Enrollment>>(apiResponse);
                }
            }

            return enrollments;
        }

        public Task<Enrollment> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Enrollment> Insert(EnrollmentCreateViewModel obj)
        {
            Enrollment enrollment = new Enrollment();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:7093/api/Enrollments", content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.Created)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        enrollment = JsonConvert.DeserializeObject<Enrollment>(apiResponse);
                    }
                }
            }

            return enrollment;
        }

        public Task<Enrollment> Update(Enrollment obj)
        {
            throw new NotImplementedException();
        }
    }
}
