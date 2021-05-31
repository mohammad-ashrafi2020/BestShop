using System.Linq;
using System.Threading.Tasks;
using framework.Services.Payment.ZarinPal.DTOs.Payment;
using framework.Services.Payment.ZarinPal.DTOs.ReFound;
using framework.Services.Payment.ZarinPal.DTOs.UnVerification;
using framework.Services.Payment.ZarinPal.DTOs.Verification;
using Microsoft.Extensions.Configuration;
using RestSharp;
namespace framework.Services.Payment.ZarinPal
{
    public class ZarinPalFactory : IZarinPalFactory
    {
        private readonly IConfiguration _configuration;
        private string MerchantId { get; }
        private string PaymentUrl { get; }
        private string VerifyUrl { get; }
        private string UnVerifiedUrl { get; }
        private string ReFoundUrl { get; }
        private string ReFoundToken { get; }
        public ZarinPalFactory(IConfiguration configuration)
        {
            _configuration = configuration;
            MerchantId = _configuration.GetSection("ZarinPal")["merchant"];
            PaymentUrl = _configuration.GetSection("ZarinPal")["paymentUrl"];
            VerifyUrl = _configuration.GetSection("ZarinPal")["verifyUrl"];
            UnVerifiedUrl = _configuration.GetSection("ZarinPal")["unVerifiedUrl"];
            ReFoundUrl = _configuration.GetSection("ZarinPal")["reFoundUrl"];
            ReFoundToken = _configuration.GetSection("ZarinPal")["reFoundToken"];
        }

        public async Task<PaymentResponseData> CreatePaymentRequest(int amount,
            string mobile, string email, string description,
             string callBackUrl)
        {
            var client = new RestClient(PaymentUrl);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            //Zarin pal Amount Type = Rial
            //For Convert Tooman TO Rial Should do amount * 10 
            var body = new PaymentRequest
            {
                mobile = mobile,
                callback_url = callBackUrl,
                description = description,
                email = email,
                amount = amount * 10,
                merchant_id = MerchantId
            };
            request.AddJsonBody(body);
            var response = await client.ExecuteAsync<PaymentResponse>(request);
            var result = response.Data;
            return result?.Data;
        }

        public async Task<FinallyVerificationResponse> CreateVerificationRequest(string authority, int amount)
        {
            var client = new RestClient(VerifyUrl);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");

            //Zarin pal Amount Type = Rial
            //For Convert Tooman TO Rial Should do amount * 10 
            request.AddJsonBody(new VerificationRequest
            {
                amount = amount * 10,
                merchant_id = MerchantId,
                authority = authority
            });
            var response = await client.ExecuteAsync<VerificationResponse>(request);
            var result = response.Data;
            if (result != null)
            {
                var res = new FinallyVerificationResponse();
                if (result.Data.Any())
                {
                    res.Message = null;
                    res.Card_pan = result.Data[0].Card_pan;
                    res.Ref_Id = result.Data[0].Ref_id;
                    res.Code = result.Data[0].Code;
                }
                else if (result.Errors.Any())
                {
                    res.Message = result.Errors[0].Message;
                    res.Card_pan = null;
                    res.Ref_Id = 0;
                    res.Code = result.Errors[0].Code;
                }

                return res;
            }
            return new FinallyVerificationResponse();
        }

        public async Task<UnVerificationFinallyResponse> GetUnVerificationRequests()
        {
            var client = new RestClient(UnVerifiedUrl);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");

            request.AddJsonBody(new UnVerificationRequest()
            {
                merchant_id = MerchantId
            });
            var result = await client.ExecuteAsync<UnVerificationResponse>(request);
            return result.Data.data;
        }

        public async Task<ReFoundResponse> ReFoundRequest(string authority)
        {
            var client = new RestClient(ReFoundUrl);
            var request = new RestRequest(Method.POST);
            request.AddHeader("authorization", $"Bearer {ReFoundToken}");
            request.AddHeader("Content-Type", "application/json");
           
            request.AddJsonBody(new ReFoundRequest()
            {
                authority = authority,
                merchant_id = MerchantId
            });
            var result = await client.ExecuteAsync<ReFoundResponse>(request);
            return result.Data;
        }
    }
}