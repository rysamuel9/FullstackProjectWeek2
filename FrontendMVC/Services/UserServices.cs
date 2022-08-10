using FrontendMVC.Models;
using FrontendMVC.Services.IRepository;
using FrontendMVC.ViewModels;
using Newtonsoft.Json;
using System.Text;

namespace FrontendMVC.Services
{
    public class UserServices : IUser
    {
        public async Task<User> Authenticate(string token)
        {
            User user = new User();
            using (var httpClient = new HttpClient())
            {
                var url = "https://localhost:7093/api/Users/Login";
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer" + token);
                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        user = JsonConvert.DeserializeObject<User>(apiResponse);
                    }
                    else
                    {
                        throw new Exception("Gagal retrieve data");
                    }
                }

                return user;
            }
        }

        //public Task Registartion(UserViewModel user)
        //{
        //    User newUser = new User();
        //    using (var httpClient = new HttpClient())
        //    {
        //        StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

        //    }
        //}
    }
}



//public async Task<Course> Insert(CourseCreateViewModel obj)
//{
//    Course course = new Course();
//    using (var httpClient = new HttpClient())
//    {
//        StringContent content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
//        using (var response = await httpClient.PostAsync("https://localhost:7093/api/Courses", content))
//        {
//            if (response.StatusCode == System.Net.HttpStatusCode.Created)
//            {
//                string apiResponse = await response.Content.ReadAsStringAsync();
//                course = JsonConvert.DeserializeObject<Course>(apiResponse);
//            }
//        }
//    }

//    return course;
//}
