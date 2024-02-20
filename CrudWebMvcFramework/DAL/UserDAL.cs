using Jcvalera.Core.Common.DataAccess;
using Jcvalera.Core.Common.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Jcvalera.Core.DAL
{
    public class UserDAL : IUserDAL
    {
        private SqlConnection connection;

        private string QueryString = string.Empty;

        public UserDAL()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        public async Task<User> GetUser(int Id)
        {
            var user = new User();

            QueryString = $"SELECT * FROM Users WHERE Id = {Id}";

            connection.Open();

            using (var cmd = new SqlCommand(QueryString, connection))
            {
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        user = new User
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            LatName = reader["LastName"].ToString(),
                            Age = Convert.ToInt32(reader["Age"])
                        };
                    }
                }
            }

            connection.Close();

            return user;
        }

        public async Task CreateUser(User user)
        {
            connection.Open();

            using (var cmd = new SqlCommand("sp_CreateUser", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@LastName", user.LatName);
                cmd.Parameters.AddWithValue("@Age", user.Age);

                await cmd.ExecuteNonQueryAsync();
            }

            connection.Close();
        }

        public async Task<List<User>> GetUsers()
        {
            var users = new List<User>();

            connection.Open();

            using (var cmd = new SqlCommand("sp_GetUsers", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        var user = new User
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            LatName = reader["LastName"].ToString(),
                            Age = Convert.ToInt32(reader["Age"])
                        };

                        users.Add(user);
                    }
                }
            }

            connection.Close();

            return users;
        }

        public async Task UpdateUser(User user)
        {
            connection.Open();

            using (var cmd = new SqlCommand("sp_UpdateUser", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", user.Id);
                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@LastName", user.LatName);
                cmd.Parameters.AddWithValue("@Age", user.Age);

                await cmd.ExecuteNonQueryAsync();
            }

            connection.Close();
        }

        public async Task DeleteUser(int id)
        {
            connection.Open();

            using (var cmd = new SqlCommand("sp_DeleteUser", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);

                await cmd.ExecuteNonQueryAsync();
            }

            connection.Close();
        }

        public async Task<bool> UserExist(int id)
        {
            var userExist = false;

            QueryString = $"SELECT * FROM Users WHERE Id = {id}";

            connection.Open();

            using (var cmd = new SqlCommand(QueryString, connection))
            {
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        userExist = true;
                    }
                }
            }

            connection.Close();

            return userExist;
        }

    }
}
