using Ultrago.Models.Entity;

namespace Ultrago.Services.Interfaces
{
    public interface IJwtTokenService
    {
        string CreateToken(User user);
    }
}
