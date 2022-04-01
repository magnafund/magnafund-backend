using Donations.API.Enums;

namespace Donations.API.Models.Data
{
    public class PaynowPaymentRequest
    {
        public double Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string? AccountNumber { get; set; } 
        public string? Descripton { get; set; } 
    }
}