using Jcvalera.Core.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jcvalera.Core.Common.Services
{
    public interface IUserBLL
    {
        Task<IEnumerable<User>> GetAllUsers();

        Task<User> GetUserDetail(int id);

        Task CreateUser(User user);

        Task UpdateUser(User user);

        Task DeleteUser(int id);
    }
}
