namespace Donations.API.Models.Data
{
    public class DonationRequest
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public double AmountGoal { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }
    }
}