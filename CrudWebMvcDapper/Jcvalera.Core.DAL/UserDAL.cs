using Dapper;
using Jcvalera.Core.Common.Entities;
using Jcvalera.Core.Common.Services;
using System.Data;
using System.Data.SqlClient;
using System.Net.NetworkInformation;

namespace Jcvalera.Core.DAL
{
    public class UserDAL : IUserDAL
    {
        public readonly SqlConfiguration Connection;

        public string QueryString = string.Empty;

        public UserDAL(SqlConfiguration connection)
        {
            Connection = connection;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var users = new List<User>();

            var connection = await Connection.GetConnection();

            //by StoredProcedure
            //users = connection.Query<User>("sp_GetUsers", commandType: CommandType.StoredProcedure).ToList();

            //by query String
            QueryString = "SELECT Id, Name, LastName, Age FROM Users";
            users = connection.Query<User>(QueryString).ToList();

            return users;
        }

        public async Task<User> GetUser(int id)
        {
            var user = new User();

            var connection = await Connection.GetConnection();

            //by StoredProcedure
            //var parameters = new DynamicParameters();
            //parameters.Add("@Id", id, DbType.Int32);
            //user = connection.QueryFirstOrDefault<User>("sp_GetUser", parameters, commandType: CommandType.StoredProcedure);

            //by query String
            QueryString = "SELECT Id, Name, LastName, Age FROM Users WHERE Id = @Id";
            user = connection.QueryFirstOrDefault<User>(QueryString, new { Id = id });

            return user;

        }

        public async Task CreateUser(User user)
        {
            var connection = await Connection.GetConnection();
            
            //By stored Procedure
            //var parameters = new DynamicParameters();
            //parameters.Add("@Name", user.Name, DbType.String);
            //parameters.Add("@LastName", user.LastName, DbType.String);
            //parameters.Add("@Age", user.Age, DbType.Int32);

            //await connection.ExecuteAsync("sp_CreateUser", parameters, commandType: CommandType.StoredProcedure);

            //BY Query
            QueryString = @"INSERT INTO Users (Name, LastName, Age) VALUES (@Name, @LastName, @Age)";
            await connection.ExecuteAsync(QueryString, new { user.Name, user.LastName, user.Age });
        }

        public async Task UpdateUser(int id, User user)
        {
            var connection = await Connection.GetConnection();

            //By Stored procedure
            //var parameters = new DynamicParameters();
            //parameters.Add("@Id", id, DbType.Int32);
            //parameters.Add("@Name", user.Name, DbType.String);
            //parameters.Add("@LastName", user.LastName, DbType.String);
            //parameters.Add("@Age", user.Age, DbType.Int32);

            //await connection.ExecuteAsync("sp_UpdateUser", parameters, commandType: CommandType.StoredProcedure);


            //By query
            QueryString = @"UPDATE Users SET Name = @Name, LastName = @LastName, Age=@Age WHERE Id = @Id";
            await connection.ExecuteAsync(QueryString, new { user.Name, user.LastName, user.Age, id });

        }

        public async Task DeleteUser(int id)
        {
            var connection = await Connection.GetConnection();

            //BY stored procedure
            //var parameters = new DynamicParameters();
            //parameters.Add("@Id", id, DbType.Int32);
            //await connection.ExecuteAsync("sp_DeleteUser", parameters, commandType: CommandType.StoredProcedure);

            //Byte query
            QueryString = @"DELETE FROM Users WHERE Id = @Id";
            await connection.ExecuteAsync(QueryString, new { Id = id });
        }
    }
}
