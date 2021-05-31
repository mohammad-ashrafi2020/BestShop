using System.Threading.Tasks;

namespace Account.Application.Services.Users.Wallets
{
    public interface IUserWalletService
    {
        Task<int> BalanceWallet(long userId);
    }
}