using System.ComponentModel.DataAnnotations;

namespace tripLog.Models
{
    public class Destination
    {
        public int DestinationId { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Name can't be more than 100 characters")]
        public string? Name { get; set; } = string.Empty;
        public ICollection<Trip> Trips { get; set; } = new List<Trip>();
    }
}
