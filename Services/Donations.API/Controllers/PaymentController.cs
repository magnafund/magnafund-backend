using Microsoft.AspNetCore.Mvc;
using Webdev.Payments;

namespace Donations.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        [HttpPost("process-payment")]
        public async Task<IActionResult> PostPayment()
        {
            // Create a mobile payment, passing the payer's email address. 
            Paynow paynow = new("13426", "95b1ac5e-ae17-490a-8093-84e0112e6145");
            var payment = paynow.CreatePayment("Invoice 32", "iamstan13y@gmail.com");

            // Add items to the payment
            payment.Add("Bananas", 22);
            payment.Add("Apples", 31);

            // Send the payment to paynow
            var response = paynow.SendMobile(payment, "0777991928", "ecocash");
            return Ok(response);
        }
    }
}