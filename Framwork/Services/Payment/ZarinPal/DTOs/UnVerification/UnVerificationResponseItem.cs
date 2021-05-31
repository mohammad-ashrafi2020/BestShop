using System;

namespace framework.Services.Payment.ZarinPal.DTOs.UnVerification
{
    public class UnVerificationResponseItem
    {
        public string authority { get; set; }

        public int amount { get; set; }
        public string callback_url { get; set; }
        public string referer { get; set; }
        public DateTime date { get; set; }
        public string email { get; set; }
    }
}