using Authentication.Domain.Entities;

namespace Authentication.Application.Repositories
{
    public interface IUserRepository
    {
        Task<User> LoginUser(string email, string password);
        Task<bool> RegisterUser(User user, string role);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetUserByEmail(string email);
    }
}
