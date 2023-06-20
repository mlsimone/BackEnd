using BackEndPoints.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEndPoints.Data
{
    public class DatabaseContextClass : DbContext
    {
        public DatabaseContextClass(DbContextOptions<DatabaseContextClass> options) : base(options) { }
        public DbSet<Item> Items { get; set; } = null!;
    }

}
