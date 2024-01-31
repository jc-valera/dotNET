using CRUDWebApi.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CRUDWebApi.Core
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) { }

        public DbSet<Person> Persons { get; set; }
    }
}
