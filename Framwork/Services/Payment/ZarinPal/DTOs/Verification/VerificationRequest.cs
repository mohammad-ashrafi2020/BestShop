namespace framework.Services.Payment.ZarinPal.DTOs.Verification
{
    public class VerificationRequest
    {
        public int amount { get; set; }
        public string merchant_id { get; set; }
        public string authority { get; set; }
    }
}
