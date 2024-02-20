using Jcvalera.Core.Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jcvalera.Core.Common.DataAccess
{
    public interface IUserDAL
    {
        Task CreateUser(User user);

        Task<List<User>> GetUsers();

        Task UpdateUser(User user);

        Task DeleteUser(int id);

        Task<User> GetUser(int id);

        Task<bool> UserExist(int id);

    }
}
