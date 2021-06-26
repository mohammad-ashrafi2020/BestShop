using AdminPanel.Infrastructure.DTOs;

namespace AdminPanel.Infrastructure
{
    public interface IApplicationContext
    {
        public bool IsAuthenticated { get; }
        UserInfo GetUserInfo();
    }
}