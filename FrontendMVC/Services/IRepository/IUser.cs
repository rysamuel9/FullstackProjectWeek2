using FrontendMVC.Models;
using FrontendMVC.ViewModels;

namespace FrontendMVC.Services.IRepository
{
    public interface IUser
    {
        //Task Registartion(UserViewModel user);
        Task<User> Authenticate(string token);
    }
}
