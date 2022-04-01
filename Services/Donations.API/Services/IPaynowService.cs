using Donations.API.Models.Data;
using ModelLibrary;

namespace Donations.API.Services
{
    public interface IPaynowService
    {
        Task<Result<PaynowResponse>> CreatePaymentAsync(PaynowPaymentRequest request);
    }
}