using System.ComponentModel.DataAnnotations;

namespace tripLog.Models
{
    public class Activity
    {
        public int ActivityId { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "name can't exceed 100 characters")]
        public string? Name { get; set; } = string.Empty;
        public ICollection<Trip> Trips { get; set; } = new List<Trip>(); 
    }
}
