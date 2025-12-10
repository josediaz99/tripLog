using System.ComponentModel.DataAnnotations;

namespace tripLog.Models
{
    public class Accommodation
    {
        public int AccommodationId { get; set; }
        [Phone(ErrorMessage = "please enter valid phone number")]
        public string? Phone { get; set; } = string.Empty;
        [DataType(DataType.EmailAddress, ErrorMessage = "please enter valid email")]
        public string? Email { get; set; } = string.Empty;
        public ICollection<Trip> Trip { get; set; } = new List<Trip>();
    }
}
