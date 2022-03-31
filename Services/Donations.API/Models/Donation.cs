using Donations.API.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Donations.API.Models
{
    public class Donation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public string? Title { get; set; }
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
        public double AmountRaised { get; set; }
        public double AmountGoal { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime EndDate { get; set; }
        public DonationStatus Status { get; set; }
    }
}