using BigEvent.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BigEvent.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<BasicUser> BasicUsers { get; set; }

        public DbSet<EventType> EventTypes { get; set; }

        public DbSet<Organizer> Organizers { get; set; }

        public DbSet<Image> Images { get; set; }
        public DbSet<Attendance> Attendance { get; set; }

        public DbSet<EventInCalendar> EventsInCalendar { get; set; }

        public DbSet<Message> Messages { get; set; }
        public DbSet<UserMessage> UserMessages { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {


            //        builder.Entity<Message>()
            //.HasOne(c => c.Organizer)
            //.WithMany()
            //.OnDelete(DeleteBehavior.SetNull);

            builder.Entity<Message>().HasOne(x => x.Organizer).WithMany().HasForeignKey(x => x.OrganizerId).OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);

        }
    }
}
