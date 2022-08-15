using FrontendMVC.Models;
using FrontendMVC.Services.IRepository;
using FrontendMVC.ViewModels;
using Newtonsoft.Json;
using System.Text;

namespace FrontendMVC.Services
{
    public class EnrollmentServices : IEnrollment
    {
        public async Task Delete(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync($"https://localhost:7093/api/Enrollments/{id}"))
                {
                    if (response.StatusCode != System.Net.HttpStatusCode.OK)
                        throw new Exception($"Gagal untuk delete data");
                }
            }
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

        public async Task<Enrollment> GetById(int id)
        {
            Enrollment enrollment = new Enrollment();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"https://localhost:7093/api/Enrollments/{id}"))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        enrollment = JsonConvert.DeserializeObject<Enrollment>(apiResponse);
                    }
                }
            }

            return enrollment;
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

        public async Task<Enrollment> Update(Enrollment obj)
        {
            Enrollment course = await GetById(obj.EnrollmentID);
            if (course == null)
                throw new Exception($"Enrollment dengan ID {obj.EnrollmentID} tidak ditemukan");
            StringContent content = new StringContent(JsonConvert.SerializeObject(obj),
                  Encoding.UTF8, "application/json");
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PutAsync($"https://localhost:7093/api/Enrollments/{obj.EnrollmentID}", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    course = JsonConvert.DeserializeObject<Enrollment>(apiResponse);
                }
            }
            return course;
        }
    }
}
