using BigEvent.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BigEvent.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Event>Events { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
