namespace framework.Services.Payment.ZarinPal.DTOs.Payment
{
    public class PaymentRequest
    {
        public string mobile { get; set; }
        public string email { get; set; }
        public string callback_url { get; set; }
        public string description { get; set; }
        public int amount { get; set; }
        public string merchant_id { get; set; }
    }
}
