using Ultrago.Models.Entity;

namespace Ultrago.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> Register(string username, string password);
        Task<User> Authenticate(string username, string password);


    }
}
