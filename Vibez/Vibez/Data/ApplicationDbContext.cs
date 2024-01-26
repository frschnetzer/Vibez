using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vibez.Data.Models;

namespace Vibez.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Event>()
               .HasData(
                   new Event() { EventId = 1, EventName = "Sample Event 1", CreatorName = "test@gmail.com", ParticipantCount = 50, City = "Sample City 1", Address = "123 Main St", Postcode = "12345", Notes = "This is a sample event.", Date = new DateTime(2024, 3, 25), EventTime = "12:00" },
                   new Event() { EventId = 2, EventName = "Sample Event 2", CreatorName = "test@gmail.com", ParticipantCount = 20, City = "Sample City 2", Address = "123 Sesame Stret", Postcode = "6800", Notes = "This is a sample event.", Date = new DateTime(2024, 1, 2), EventTime = "15:00" },
                   new Event() { EventId = 3, EventName = "Sample Event 3", CreatorName = "test@gmail.com", ParticipantCount = 35, City = "Sample City 3", Address = "123 Secondary St", Postcode = "1234", Notes = "This is a sample event.", Date = new DateTime(2024, 3, 17), EventTime = "20:00" },
                   new Event() { EventId = 4, EventName = "Sample Event 4", CreatorName = "test@gmail.com", ParticipantCount = 12, City = "Sample City 4", Address = "13 Main St", Postcode = "7777", Notes = "This is a sample event.", Date = new DateTime(2024, 1, 15), EventTime = "18:00" }
               );
        }

        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Friend> Friends { get; set; }
    }
}
