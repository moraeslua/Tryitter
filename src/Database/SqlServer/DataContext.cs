using Microsoft.EntityFrameworkCore;
using Tryitter.Models;

namespace Tryitter.src.Database.SqlServer
{
    public class DataContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}
