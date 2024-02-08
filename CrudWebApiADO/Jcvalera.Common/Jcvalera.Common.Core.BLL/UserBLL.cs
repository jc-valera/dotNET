using Jcvalera.Common.Core.DAL;
using Jcvalera.Common.Entities;

namespace Jcvalera.Common.Core.BLL
{
    public class UserBLL
    {
        public SqlServerDAL dataAccess;

        public UserBLL()
        {
            dataAccess = new SqlServerDAL();
        }

        public async Task<bool> ExistUser(int id)
        {
            var userExist = await dataAccess.ExistUser(id);

            return userExist;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await dataAccess.GetUsers();

            return users;
        }

        public async Task<IEnumerable<User>> CreateUser(User user)
        {
            await dataAccess.CreateUser(user);

            var users = await dataAccess.GetUsers();

            return users;
        }

        public async Task<IEnumerable<User>> UpdateUser(int id, User user)
        {
            await dataAccess.UpdateUser(id, user);

            var users = await dataAccess.GetUsers();

            return users;
        }

        public async Task<IEnumerable<User>> DeleteUser(int id)
        {
            await dataAccess.DeleteUser(id);

            var users = await dataAccess.GetUsers();

            return users;
        }
    }
}
