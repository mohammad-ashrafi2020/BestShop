namespace framework.Services.Payment.ZarinPal.DTOs.Payment
{
    public class PaymentResponse
    {
        public PaymentResponseData Data { get; set; }
    }

    public class PaymentResponseData
    {
        public int Code { get; set; }
        public string Authority { get; set; }
        public int Fee { get; set; }
        public string Message { get; set; }
    }
}
