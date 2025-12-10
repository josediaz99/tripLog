using System.ComponentModel.DataAnnotations;

namespace tripLog.Models
{
    public class Trip
    {
        public int TripId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        //foreign keys
        public int DestinationId { get; set; }
        public Destination Destination { get; set; } = null!;
        public int AccommodationId { get; set; }
        public Accommodation Accommodation { get; set; } = null!;
        public ICollection<Activity> Activities { get; set; } = new List<Activity>();
    }
}
