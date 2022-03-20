using Donations.API.Enums;

namespace Donations.API.Models
{
    public class Donation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Description { get; set; }
        public double AmountRaised { get; set; }
        public double AmountGoal { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime EndDate { get; set; }
        public DonationStatus Status { get; set; }
    }
}