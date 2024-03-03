using Jcvalera.Core.Common.Entities;
using Jcvalera.Core.Common.Services;
using Jcvalera.Core.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jcvalera.Core.BLL
{
    public class UserBLL : IUserBLL
    {
        private readonly SqlConfiguration Configuration;
        private IUserDAL userDAL;

        public UserBLL(SqlConfiguration configuration)
        {
            Configuration = configuration;
            userDAL = new UserDAL(configuration.ConnectionString);
        }

        public async Task CreateUser(User user)
        {
            await userDAL.CreateUser(user);
        }

        public async Task DeleteUser(int id)
        {
            await userDAL.DeleteUser(id);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var users = await userDAL.GetAllUsers();

            return users;
        }

        public async Task<User> GetUserDetail(int id)
        {
            var user = await userDAL.GetUserDetail(id);

            return user;
        }

        public async Task UpdateUser(User user)
        {
            await userDAL.UpdateUser(user);
        }
    }
}
