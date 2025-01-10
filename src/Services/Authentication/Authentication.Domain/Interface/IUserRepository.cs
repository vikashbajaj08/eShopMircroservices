using Authentication.Domain.Entities;

namespace Authentication.Domain.Interface
{
    public interface IUserRepository
    {
        User LoginUser(string email, string password);
        bool RegisterUser(User user, string role);
        IEnumerable<User> GetAll();
    }
}
