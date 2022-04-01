using Donations.API.Enums;

namespace Donations.API.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string? AccountNumber { get; set; }
        public int DonationId { get; set; }
        public int MyProperty { get; set; }
        public DateTime DateCreated { get; set; }
    }
}