using System.Data.SqlClient;

var builder = new SqlConnectionStringBuilder();

builder.DataSource = "JCVALERA\\SQLEXPRESS";
builder.UserID = "sa";
builder.Password = "P@$$w0rd__!*";
builder.InitialCatalog = "Northwind";

string queryText = "SELECT * FROM Employees";

try
{
    using (var con = new SqlConnection(builder.ConnectionString))
    {
        con.Open();

        using (var cmd = new SqlCommand(queryText, con))
        {
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"The first name is {reader[2]} and the LastName is {reader[1]}");
                }
            }
        }
    }
}
catch (SqlException ex)
{
    Console.WriteLine(ex.ToString());
}