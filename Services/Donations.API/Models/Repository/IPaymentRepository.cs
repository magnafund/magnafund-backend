using ModelLibrary;

namespace Donations.API.Models.Repository
{
    public interface IPaymentRepository
    {
        Task<Result<Payment>> CreatePayment(Payment payment); 
    }
}