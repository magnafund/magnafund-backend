namespace Donations.API.Models.Data
{
    public class UpdateDonationRequest
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public double AmountGoal { get; set; }
        public DateTime EndDate { get; set; }
    }
}