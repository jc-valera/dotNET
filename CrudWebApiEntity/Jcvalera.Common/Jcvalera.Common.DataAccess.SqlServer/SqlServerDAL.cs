using Jcvalera.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace Jcvalera.Common.DataAccess.SqlServer
{
    public class SqlServerDAL : DbContext
    {
        public SqlServerDAL(DbContextOptions<SqlServerDAL> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}
