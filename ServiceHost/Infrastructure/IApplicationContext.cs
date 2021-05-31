using ServiceHost.Infrastructure.DTOs;

namespace ServiceHost.Infrastructure
{
    public interface IApplicationContext
    {
        public bool IsAuthenticated { get; }
        UserInfo GetUserInfo();
    }
}