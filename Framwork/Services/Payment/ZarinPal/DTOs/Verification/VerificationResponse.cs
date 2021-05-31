using System.Collections.Generic;

namespace framework.Services.Payment.ZarinPal.DTOs.Verification
{
    public class VerificationResponse
    {
        public List<VerificationResponseData> Data { get; set; }
        public List<VerificationResponseError> Errors { get; set; }
    }

    public class VerificationResponseData
    {
        public int Code { get; set; }
        public long Ref_id { get; set; }
        public string Card_pan { get; set; }
        public string Fee_type { get; set; }
        public int Fee { get; set; }
    }

    public class FinallyVerificationResponse
    {
        public int Code { get; set; }
        public long Ref_Id { get; set; }
        public string Card_pan { get; set; }
        public string Message { get; set; }
    }
    public class VerificationResponseError
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }
}
