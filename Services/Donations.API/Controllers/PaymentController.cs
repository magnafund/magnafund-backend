using Donations.API.Models.Data;
using Donations.API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Webdev.Payments;

namespace Donations.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentController(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        [HttpPost("process-payment")]
        public async Task<IActionResult> PostPayment(PaymentRequest request)
        {
            var result = await _paymentRepository.CreatePayment(new Models.Payment
            {
                AccountNumber = request.AccountNumber,
                Amount = request.Amount,
                DonationId = request.DonationId,
                PaymentMethod = request.PaymentMethod,
                Name = request.Name,
                DateCreated = DateTime.Now
            });

            return Ok(result);
        }
    }
}