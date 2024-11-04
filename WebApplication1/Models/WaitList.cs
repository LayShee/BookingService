using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingService.Models
{
    public class WaitList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WaitlistId { get; set; }
        public int UserId { get; set; }
        public int ClassId { get; set; }
        public DateTime AddedAt { get; set; }
        public bool Status { get; set; }
    }
}
