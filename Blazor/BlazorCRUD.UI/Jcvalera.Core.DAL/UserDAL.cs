using Dapper;
using Jcvalera.Core.Common.Entities;
using Jcvalera.Core.Common.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace Jcvalera.Core.DAL
{
    public class UserDAL : IUserDAL
    {
        public string ConnectionString;

        private string QueryString = string.Empty;

        public UserDAL(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected SqlConnection dbConnection()
        {
            return new SqlConnection(ConnectionString);
        }


        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var db = dbConnection();

            QueryString = @"SELECT Id, Name, LastName, Age FROM Users";

            var users = await db.QueryAsync<User>(QueryString.ToString(), new { });

            return users;
        }

        public async Task<User> GetUserDetail(int id)
        {
            var db = dbConnection();

            QueryString = $"SELECT Id, Name, LastName, Age FROM Users WHERE Id = @Id";

            var user = await db.QueryFirstOrDefaultAsync<User>(QueryString.ToString(), new { Id = id });

            return user;
        }

        public async Task CreateUser(User user)
        {
            var db = dbConnection();

            QueryString = @"INSERT INTO Users (Name, LastName, Age) 
                            VALUES (@Name, @LastName, @Age)";

            var result = await db.ExecuteAsync(QueryString.ToString(), new { user.Name, user.LastName, user.Age });

        }

        public async Task UpdateUser(User user)
        {
            var db = dbConnection();

            QueryString = @"UPDATE Users SET Name = @Name, LastName = @LastName, Age = @Age WHERE Id = @Id";

            var result = await db.ExecuteAsync(QueryString.ToString(), new { user.Name, user.LastName, user.Age, user.Id });
        }

        public async Task DeleteUser(int id)
        {
            var db = dbConnection();

            QueryString = $"DELETE FROM Users WHERE Id = @Id";

            await db.ExecuteAsync(QueryString.ToString(), new { Id = id });
        }

    }
}
