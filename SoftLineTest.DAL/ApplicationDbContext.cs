using Microsoft.EntityFrameworkCore;
using SoftLineTest.Models.Models;

namespace SoftLineTest.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Status> Status { get; set; }
        public DbSet<Task> Task { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            if (Database.EnsureCreated())
            {
                using (ApplicationDbContext db = new ApplicationDbContext(options))
                {
                    db.Status.Add(
                        new Status()
                        {
                            StatusID = 1,
                            StatusName = "Created"
                        });
                    db.Status.Add(
                        new Status()
                        {
                            StatusID = 2,
                            StatusName = "At work"
                        });
                    db.Status.Add(
                        new Status()
                        {
                            StatusID = 3,
                            StatusName = "Completed"
                        });
                    db.SaveChanges();
                }
            }

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectionDb.ConnectionString());
        }
    }
}
