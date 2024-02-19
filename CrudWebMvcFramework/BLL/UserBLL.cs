using Jcvalera.Core.Common.Entities;
using Jcvalera.Core.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jcvalera.Core.BLL
{
    public class UserBLL
    {
        public UserDAL userDAL;

        public UserBLL()
        {
            userDAL = new UserDAL();
        }

        public async Task<User> GetUser(int id)
        {
            var user = await userDAL.GetUser(id);

            return user;
        }

        public async Task CreateUser(User user)
        {
            await userDAL.CreateUser(user);
        }

        public async Task<List<User>> GetUsers()
        {
            var users = await userDAL.GetUsers();

            return users;
        }

        public async Task UpdateUser(User user)
        {
            await userDAL.UpdateUser(user);
        }

        public async Task DeleteUser(int Id)
        {
            await userDAL.DeleteUser(Id);
        }

    }
}
