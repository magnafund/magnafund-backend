using Donations.API.Enums;
using Donations.API.Models.Data;
using Donations.API.Services;
using ModelLibrary;

namespace Donations.API.Models.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaynowService _paynowService;

        public PaymentRepository(ApplicationDbContext context, IPaynowService paynowService)
        {
            _context = context;
            _paynowService = paynowService;
        }

        public async Task<Result<Payment>> CreatePayment(Payment payment)
        {
            var response = await _paynowService.CreatePaymentAsync(new PaynowPaymentRequest
            {
                AccountNumber = payment.AccountNumber,
                Amount = payment.Amount,
                Descripton = "CF Zimbabwe Testing",
                PaymentMethod = PaymentMethod.ecocash
            });
            return new Result<Payment>(true, new List<string> { "Your donation was successful!"});
        }
    }
}