using Jcvalera.Core.Common.Entities;

namespace Jcvalera.Core.Common.Services
{
    public interface IUserDAL
    {
        Task<IEnumerable<User>> GetAllUsers();

        Task<User> GetUserDetail(int id);

        Task CreateUser(User user);

        Task UpdateUser(User user);

        Task DeleteUser(int id);
    }
}
