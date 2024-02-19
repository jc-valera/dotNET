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

        public UserDAL()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        public async Task<User> GetUser(int Id)
        {
            var user = new User();

            var queryString = $"SELECT * FROM Users WHERE Id = {Id}";

            using (var con = (connection))
            {
                con.Open();

                using (var cmd = new SqlCommand(queryString, connection))
                {
                    using (var reader = cmd.ExecuteReader())
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
            }

            return user;
        }

        public async Task CreateUser(User user)
        {
            using (var con = (connection))
            {
                con.Open();

                using (var cmd = new SqlCommand("sp_CreateUser", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", user.Name);
                    cmd.Parameters.AddWithValue("@LastName", user.LatName);
                    cmd.Parameters.AddWithValue("@Age", user.Age);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public async Task<List<User>> GetUsers()
        {
            var users = new List<User>();

            connection.Open();

            using (var cmd = new SqlCommand("sp_GetUsers", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
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

            return users;
        }

        public async Task UpdateUser(User user)
        {
            using (var con = (connection))
            {
                con.Open();

                using (var cmd = new SqlCommand("sp_UpdateUser", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", user.Id);
                    cmd.Parameters.AddWithValue("@Name", user.Name);
                    cmd.Parameters.AddWithValue("@LastName", user.LatName);
                    cmd.Parameters.AddWithValue("@Age", user.Age);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public async Task DeleteUser(int Id)
        {
            using (var con = (connection))
            {
                con.Open();

                using (var cmd = new SqlCommand("sp_DeleteUser", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", Id);

                    cmd.ExecuteNonQuery();
                }

            }
        }

    }
}
