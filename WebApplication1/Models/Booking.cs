using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingService.Models
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public int PackageId { get; set; }
        public int Status { get; set; }
        public int CreditsUsed { get; set; }
        public bool IsRefunded { get; set; }
        public DateTime BookedAt { get; set; }
    }
}
