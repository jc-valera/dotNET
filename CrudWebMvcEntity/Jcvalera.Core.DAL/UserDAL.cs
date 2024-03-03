using Jcvalera.Core.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Jcvalera.Core.DAL
{
    public class UserDAL : DbContext
    {
        public UserDAL(DbContextOptions<UserDAL> options) : base(options)
        {

        }

        public virtual DbSet<User> Users { get; set; }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        //    var connectionString = config.GetConnectionString("DbConnection");

        //    optionsBuilder.UseSqlServer(connectionString);
        //}
    }
}
