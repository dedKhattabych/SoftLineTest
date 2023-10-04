using Microsoft.EntityFrameworkCore;
using SoftLineTest.Models.Models;

namespace SoftLineTest.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Status> Status { get; set; }
        public DbSet<Task> Task { get; set; }
        public ApplicationDbContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectionDb.ConnectionString());
        }
    }
}
