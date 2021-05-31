using System.Collections.Generic;

namespace framework.Services.Payment.ZarinPal.DTOs.UnVerification
{
    public class UnVerificationResponse
    {
        public UnVerificationFinallyResponse data { get; set; }
        public List<object> errors { get; set; }
    }

    public class UnVerificationFinallyResponse
    {
        public string code { get; set; }
        public string message { get; set; }
        public List<UnVerificationResponseItem> authorities { get; set; }
    }
}