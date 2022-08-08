using FullstackProjectWeek2.DTO;

namespace FullstackProjectWeek2.DAL.IRepository
{
    public interface IUser
    {
        Task Registartion(CreateUserDTO user);
        Task<UserDTO> Authenticate(string username, string password);
        Task<IEnumerable<UserDTO>> GetAll();
    }
}
