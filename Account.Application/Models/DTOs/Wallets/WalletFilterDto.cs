using System.Collections.Generic;
using framework;

namespace Account.Application.Models.DTOs.Wallets
{
    public class WalletFilterDto:BasePaging
    {
        public long UserId { get; set; }
        public List<WalletDto> Transactions { get; set; }
    }
}