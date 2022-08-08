using FullstackProjectWeek2.DAL.IRepository;
using FullstackProjectWeek2.DTO;
using FullstackProjectWeek2.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FullstackProjectWeek2.DAL
{
    public class UserDAL : IUser
    {
        private readonly UserManager<IdentityUser> _userManager;
        private AppSettings _appSettings;

        public UserDAL(UserManager<IdentityUser> userManager, IOptions<AppSettings> appSettings)
        {
            _userManager = userManager;
            _appSettings = appSettings.Value;
        }
        public async Task<UserDTO> Authenticate(string username, string password)
        {
            var currUser = await _userManager.FindByNameAsync(username);
            var userResult = await _userManager.CheckPasswordAsync(currUser, password);
            if (!userResult)
                throw new Exception("Autentikasi gagal !");

            var user = new UserDTO
            {
                Username = username
            };
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.Username));

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            return user;
        }

        public Task<IEnumerable<UserDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task Registartion(CreateUserDTO user)
        {
            try
            {
                var newUser = new IdentityUser
                {
                    UserName = user.Username,
                    Email = user.Username
                };

                var result = await _userManager.CreateAsync(newUser, user.Password);
                if (!result.Succeeded)
                {
                    StringBuilder sb = new StringBuilder();
                    var errors = result.Errors;
                    foreach (var error in errors)
                    {
                        sb.Append($"{error.Code} - {error.Description} \n");
                    }
                    throw new Exception($"Error: {sb.ToString()}");
                }
            }
            catch (Exception ex)
            {

                throw new Exception($"Error: {ex.Message}");
            }
        }
    }
}
