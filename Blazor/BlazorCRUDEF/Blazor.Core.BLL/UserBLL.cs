using Blazor.Core.Common.Entities;
using Blazor.Core.Common.Services;
using Blazor.Core.DAL;
using Microsoft.EntityFrameworkCore;

namespace Blazor.Core.BLL
{
    public class UserBLL : IUserBLL
    {
        private readonly UserDAL UserDAL;

        public UserBLL(UserDAL userDAL)
        {
            UserDAL = userDAL;
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

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var users = await UserDAL.Users.ToListAsync();

            return users;
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
