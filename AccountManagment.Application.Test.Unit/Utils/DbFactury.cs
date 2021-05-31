using System;
using System.Transactions;
using Account.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Account.Application.Tests.Utils
{
    public class DbFactory
    {
        public static AccountContext GetDbContext()
        {
            //var connectionString = "Data Source=.;Initial Catalog=TestDb;Integrated Security=true;MultipleActiveResultSets=true";

            var options = new DbContextOptionsBuilder<AccountContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            var context = new AccountContext(options);
            return context;
        }
    }
}