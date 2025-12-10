using Microsoft.EntityFrameworkCore;
namespace tripLog.Models
{
    public class TripLogContext : DbContext
    {
        public TripLogContext (DbContextOptions<TripLogContext> options)
            : base(options)
        {
        }
        public DbSet<Trip> Trips { get; set; } = null!;
        public DbSet<Accommodation> Accommodations { get; set; } = null!;
        public DbSet<Activity> Activities { get; set; } = null!;
        public DbSet<Destination> Destinations { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // trip - destination
            // one destination can have many trips
            // deleting destination that is being used will fail
            modelBuilder.Entity<Trip>()
                .HasOne(t => t.Accommodation)
                .WithMany(a => a.Trip)
                .HasForeignKey(a => a.TripId)
                .OnDelete(DeleteBehavior.Restrict);
            // trip - destination 
            // one destination can have many trips
            // one trip can only have one destination
            modelBuilder.Entity<Trip>()
                .HasOne(t => t.Destination)
                .WithMany(d => d.Trips)
                .HasForeignKey(t => t.DestinationId)
                .OnDelete(DeleteBehavior.Restrict);
            // trip - activities
            // many to many 
            modelBuilder.Entity<Trip>()
               .HasMany(t => t.Activities)
               .WithMany(a => a.Trips)
               .UsingEntity<Dictionary<string, object>>(
                   "TripActivity",
                   j => j
                       .HasOne<Activity>()
                       .WithMany()
                       .HasForeignKey("ActivityId"),
                   j => j
                       .HasOne<Trip>()
                       .WithMany()
                       .HasForeignKey("TripId"),
                   j =>
                   {
                       j.HasKey("TripId", "ActivityId");
                   });

            //============= seed data ===============
            // destination
             modelBuilder.Entity<Destination>().HasData(
               new Destination { DestinationId = 1, Name = "Paris" },
               new Destination { DestinationId = 2, Name = "New York" }
               );
            //accommodation
            modelBuilder.Entity<Accommodation>().HasData(
                new Accommodation
                {
                    AccommodationId = 1,
                    Phone = "123-456-7890",
                    Email = "sampleEmail@gmail.com"
                },
                new Accommodation
                {
                    AccommodationId = 2,
                    Phone = "987-654-3210",
                    Email = "sampleEmail1@gmail.com"
                });
            //activities
            modelBuilder.Entity<Activity>().HasData(
                new Activity { ActivityId = 1, Name = "Sightseeing" },
                new Activity { ActivityId = 2, Name = "Museum Visit" },
                new Activity { ActivityId = 3, Name = "Food Tasting" }
            );
            modelBuilder.Entity<Trip>().HasData(
                new Trip
                {
                    TripId = 1,
                    StartDate = new DateTime(2023, 5, 1),
                    EndDate = new DateTime(2023, 5, 10),
                    DestinationId = 1,
                    AccommodationId = 1
                },
                new Trip
                {
                    TripId = 2,
                    StartDate = new DateTime(2023, 6, 15),
                    EndDate = new DateTime(2023, 6, 25),
                    DestinationId = 2,
                    AccommodationId = 2
                }
                );
            //trip activities
            modelBuilder.Entity("TripActivity").HasData(
                new { TripId = 1, ActivityId = 1 },
                new { TripId = 1, ActivityId = 2 },
                new { TripId = 2, ActivityId = 2 },
                new { TripId = 2, ActivityId = 3 }
                );
        }
    }

}
