using System;
using Account.Domain.Enums;

namespace Account.Application.Models.DTOs.Wallets
{
    public class WalletDto
    {
        public long UserId { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public WalletType Type { get; set; }
        public DateTime CreationDate { get; set; }
        public long? BankTrackingCode { get; set; }
        public bool IsFinally { get; set; }
    }
}