using Jcvalera.Core.Common.Entities;
using Jcvalera.Core.Common.Services;
using Jcvalera.Core.DAL;
using Microsoft.EntityFrameworkCore;

namespace Jcvalera.Core.BLL
{
    public class UserBLL : IUserBLL
    {
        private UserDAL UserDAL;

        public UserBLL(UserDAL userDAL)
        {
            UserDAL = userDAL;
        }

        //private UserDAL UserDAL;

        //public UserBLL()
        //{
        //    UserDAL = new UserDAL();
        //}

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var users = await UserDAL.Users.ToListAsync();

            return users;
        }

        public async Task CreateUser(User user)
        {
            UserDAL.Users.Add(user);

            await UserDAL.SaveChangesAsync();
        }

        public async Task DeleteUser(int id)
        {
            var user = await UserDAL.Users.FindAsync(id);

            UserDAL.Users.Remove(user);

            await UserDAL.SaveChangesAsync();
        }

        public async Task<User> GetUser(int id)
        {
            var user = await UserDAL.Users.FindAsync(id);

            return user;
        }

        public async Task UpdateUser(User user)
        {
            UserDAL.Entry(user).State = EntityState.Modified;

            await UserDAL.SaveChangesAsync();
        }
    }
}
