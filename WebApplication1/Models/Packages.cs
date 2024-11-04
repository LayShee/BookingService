using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingService.Models
{
    public class Packages
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public int Credits { get; set; }
        public int Price { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Country { get; set; }
    }
}
