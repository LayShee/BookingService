using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingService.Models
{
    public class UserPackages
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserPackageId { get; set; }
        public int UserId { get; set; }
        public int PackageId { get; set; }
        public int CreditsRemaining { get; set; }
        public int ExpiryStatus { get; set; }
        public Packages packages { get; set; }
    }
}
