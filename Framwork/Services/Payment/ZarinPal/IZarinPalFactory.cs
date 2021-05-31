using System.Threading.Tasks;
using framework.Services.Payment.ZarinPal.DTOs.Payment;
using framework.Services.Payment.ZarinPal.DTOs.ReFound;
using framework.Services.Payment.ZarinPal.DTOs.UnVerification;
using framework.Services.Payment.ZarinPal.DTOs.Verification;

namespace framework.Services.Payment.ZarinPal
{
    public interface IZarinPalFactory
    {
        Task<PaymentResponseData> CreatePaymentRequest(int amount,
            string mobile, string email, string description,
            string callBackUrl);

         Task<FinallyVerificationResponse> CreateVerificationRequest(string authority, int price);
         Task<UnVerificationFinallyResponse> GetUnVerificationRequests();
         Task<ReFoundResponse> ReFoundRequest(string authority);
    }
}