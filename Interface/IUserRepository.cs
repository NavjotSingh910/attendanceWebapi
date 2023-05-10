using attendaceAppWebApi.Models;
using System.Threading.Tasks;

namespace attendaceAppWebApi.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string username, string password);
        Task<bool> UserExists(string username);
        Task<string> GenerateJwtToken(User user);
    }
}
