using EventsPro.Model;
using Microsoft.EntityFrameworkCore;

namespace EventsPro.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Event> Events { get; set; }
        public DbSet<Organizer> Organizer { get; set; }



    }
}
