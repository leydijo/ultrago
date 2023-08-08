using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Ultrago.Models.Entity;
using Ultrago.Services.Interfaces;


namespace Ultrago.Services
{
    public class UserService : IUserService
    {
        private readonly UltragoContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserService(UltragoContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }
        public async Task<User> Authenticate(string username, string password)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.UserName == username);
            if (user == null) return null;

            var isPasswordValid = _passwordHasher.VerifyHashedPassword(user, user.Password, password);
            if (isPasswordValid == Microsoft.AspNetCore.Identity.PasswordVerificationResult.Failed)
            {
                return null;
            }
            user.Password = _passwordHasher.HashPassword(user, password);
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> Register(string username, string password)
        {
            if (await _context.Users.AnyAsync(u => u.UserName == username))
            {
                // Usuario ya existe
                return null;
            }

            var user = new User { UserName = username };
            user.Password = _passwordHasher.HashPassword(user, password);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}
