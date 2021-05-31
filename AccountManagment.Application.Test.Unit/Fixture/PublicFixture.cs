using System;
using System.Transactions;
using Account.Application.Tests.Utils;
using Account.Application.Tests.Utils.Users;
using Account.Domain.Entities.Users;
using Account.Infrastructure.Context;

namespace Account.Application.Tests.Fixture
{
    public  class PublicFixture : IDisposable
    {
        public readonly long UserId = 1;
        public AccountContext _context;
        private readonly User _user;
        public PublicFixture()
        {
            _context = DbFactory.GetDbContext();
            var user = UserUtil.AddUser(_context,"Address@Test","00000000000)","0000000000");
            UserId = user.Id;
            _user = user;
        }

        public void Dispose()
        {
            UserUtil.ClearUser(_user, _context);
        }
    }
}