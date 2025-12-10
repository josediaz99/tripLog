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


        }
    }
}
