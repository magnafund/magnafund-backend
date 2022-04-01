using Donations.API.Models.Data;
using ModelLibrary;
using Webdev.Payments;

namespace Donations.API.Services
{
    public class PaynowService : IPaynowService
    {
        private readonly IConfiguration _configuration;

        public PaynowService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Result<PaynowResponse>> CreatePaymentAsync(PaynowPaymentRequest request)
        {
            Paynow paynow = new(_configuration["PaynowIntegration:Id"], _configuration["PaynowIntegration:Key"]);

            var payment = paynow.CreatePayment("Donation Funds", "iamstan13y@gmail.com");

            payment.Add(request.Descripton, (decimal)request.Amount);

            var response = paynow.SendMobile(payment, request.AccountNumber, "ecocash");

            return new Result<PaynowResponse>(true, new List<string> { "zvafaya" });
            //return new Result<PaynowResponse>();
        }
    }
}