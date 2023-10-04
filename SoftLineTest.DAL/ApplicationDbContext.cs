using Microsoft.EntityFrameworkCore;

namespace SoftLineTest.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectionDb.ConnectionString());
        }
    }
}
