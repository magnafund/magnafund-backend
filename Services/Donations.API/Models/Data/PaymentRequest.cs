using Donations.API.Enums;

namespace Donations.API.Models.Data
{
    public class PaymentRequest
    {
        public string? Name { get; set; } = "Anonymous";
        public double Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string? AccountNumber { get; set; }
        public int DonationId { get; set; } 
    }
}