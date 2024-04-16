using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wcf.Core.Common.Entities;

namespace Wcf.Core.DAL
{
    public class PersonDAL
    {
        public SqlConnection connection;

        public PersonDAL()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        public async Task<List<Person>> GetPersons()
        {
            var persons = new List<Person>();

            connection.Open();

            var queryString = "SELECT Id, Name, FirstSurname, SecondSurname, Area FROM Employees";
            
            using (var cmd = new SqlCommand(queryString, connection))
            {
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (reader.Read()) 
                    {
                        var person = new Person
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            FirstSurname = reader["FirstSurname"].ToString(),
                            SecondSurname = reader["SecondSurname"].ToString(),
                            Area = reader["Area"].ToString(),
                            //BirthDate = Convert.ToDateTime(reader["BirthDate"].ToString()),
                            //Salary = Convert.ToInt32(reader["Salary"].ToString())

                        };

                        persons.Add(person);
                    }

                }

            }

            connection.Close();

            return persons;
        }
    }
}
