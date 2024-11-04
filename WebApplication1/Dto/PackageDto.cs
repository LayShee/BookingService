namespace BookingService.Dto
{
    public class PackageIDDto
    {
        public int PackageID { get; set; }
        public int UserID { get; set; }
    }

    public class PackageInfoDto
    {
        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public int RemainingCredits { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int ExpiredStatus { get; set; }
        public string Country { get; set; }
    }
}
