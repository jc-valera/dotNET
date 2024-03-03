using Blazor.Core.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blazor.Core.DAL
{
    public class UserDAL : DbContext
    {
        public UserDAL(DbContextOptions<UserDAL> options) : base (options)
        {
            
        }

        public DbSet<User> Users { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.\\SQLExpress; Database=CrudWebMvcFramework; Trusted_Connection=true; TrustServerCertificate=true;");
        //}
    }
}
