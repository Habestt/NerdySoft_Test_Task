using Microsoft.EntityFrameworkCore;
using NerdySoft_Test_Task.Entities;

namespace NerdySoft_Test_Task.EF
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public DbSet<Announcement> Announcements { get; set; } = null!;        
    }
}
