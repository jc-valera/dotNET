using Jcvalera.Core.Common.Entities;
using Jcvalera.Core.Common.Services;
using Jcvalera.Core.DAL;

namespace Jcvalera.Core.BLL
{
    public class UserBLL : IUserBLL
    {
        public readonly SqlConfiguration Configuration; 
        public IUserDAL UserDAL;

        public UserBLL(SqlConfiguration configuration)
        {
            Configuration = configuration;
            UserDAL = new UserDAL(configuration);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var users = await UserDAL.GetAllUsers();

            return users;
        }

        public async Task CreateUser(User user)
        {
            await UserDAL.CreateUser(user);
        }

        public async Task DeleteUser(int id)
        {
            await UserDAL.DeleteUser(id);
        }

        public async Task<User> GetUser(int id)
        {
            var user = new User();

            user = await UserDAL.GetUser(id);

            return user;
        }

        public async Task UpdateUser(int id, User user)
        {
            await UserDAL.UpdateUser(id, user);
        }
    }
}
