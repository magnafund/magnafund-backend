namespace Donations.API.Models.Data
{
    public class UpdateDonationRequest
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string? Title { get; set; }
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
        public double AmountGoal { get; set; }
        public DateTime EndDate { get; set; }
    }
}