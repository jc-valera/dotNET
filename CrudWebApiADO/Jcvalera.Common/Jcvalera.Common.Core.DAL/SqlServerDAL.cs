using Jcvalera.Common.Entities;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Jcvalera.Common.Core.DAL
{
    public class SqlServerDAL
    {
        private string Connection = string.Empty;

        public SqlServerDAL()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            Connection = builder.GetSection("ConnectionStrings:DbConnection").Value;
        }

        public async Task<bool> ExistUser(int id)
        {
            var userExist = false;

            var queryString = $"SELECT Id FROM Users WHERE Id = {id}";

            using (SqlConnection conn = new (Connection))
            {
                conn.Open();
                var cmd = new SqlCommand(queryString, conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    userExist = true;
                }
                conn.Close();
            }
            
            return userExist;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = new List<User>();

            using (SqlConnection conn = new(Connection))
            {
                conn.Open();
                using (SqlCommand cmd = new("sp_GetUsers", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var user = new User
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString() ?? string.Empty,
                                LastName = reader["LastName"].ToString() ?? string.Empty,
                                Age = Convert.ToInt32(reader["Age"])
                            };

                            users.Add(user);
                        }
                    }
                }
            }

            return users;
        }

        public async Task CreateUser(User user)
        {
            using (SqlConnection conn = new(Connection))
            {
                conn.Open();
                using (SqlCommand cmd = new("sp_CreateUser", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", user.Name);
                    cmd.Parameters.AddWithValue("@LastName", user.LastName);
                    cmd.Parameters.AddWithValue("@Age", user.Age);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public async Task UpdateUser(int id, User user)
        {
            using (SqlConnection conn = new(Connection))
            {
                conn.Open();
                using (SqlCommand cmd = new("sp_UpdateUser", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Name", user.Name);
                    cmd.Parameters.AddWithValue("@LastName", user.LastName);
                    cmd.Parameters.AddWithValue("@Age", user.Age);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public async Task DeleteUser(int id)
        {
            using (SqlConnection conn = new(Connection))
            {
                conn.Open();
                using (SqlCommand cmd = new("sp_DeleteUser", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
