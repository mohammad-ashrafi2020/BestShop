using System.Linq;
using System.Threading.Tasks;
using Account.Domain.Entities.Users;
using Account.Domain.Enums;
using Account.Infrastructure.Context;
using framework.Services;
using Microsoft.EntityFrameworkCore;

namespace Account.Application.Services.Users.Wallets
{
    public class UserWalletService : BaseService, IUserWalletService
    {
        public UserWalletService(AccountContext context) : base(context)
        {
        }


        public async Task<int> BalanceWallet(long userId)
        {
            var user = await GetById<User>(userId);
            if (user == null)
                return 0;

            var deposit = await Table<UserWallet>().Where(w => w.Type == WalletType.Deposit)
                .SumAsync(s => s.Price);

            var withdraw = await Table<UserWallet>().Where(w => w.Type == WalletType.Withdraw)
                .SumAsync(s => s.Price);

            return deposit - withdraw;
        }
    }
}