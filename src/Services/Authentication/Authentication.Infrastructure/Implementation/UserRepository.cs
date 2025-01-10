using Authentication.Application.Repositories;
using Authentication.Domain.Entities;
using Authentication.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Infrastructure.Implementation
{
    public class UserRepository(AuthenticationDbContext dbContext) : IUserRepository
    {
        public async Task<IEnumerable<User>> GetAll()
        {
            return await dbContext.Users.ToListAsync();
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return
                await dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);

        }

        public async Task<User> LoginUser(string email, string password)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user != null)
            {
                var isPasswordMatched = BCrypt.Net.BCrypt.Verify(password, user.Password);

                if (isPasswordMatched)
                {
                    return user;
                }
            }

            return null;
        }

        public async Task<bool> RegisterUser(User user, string Role)
        {
            var role = await dbContext.Roles.FirstOrDefaultAsync(r => r.Name == Role);

            if (role != null)
            {
                user.Roles.Add(role);
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                await dbContext.Users.AddAsync(user);

                await dbContext.SaveChangesAsync();

                return true;
            }
            return false;
        }
    }
}
