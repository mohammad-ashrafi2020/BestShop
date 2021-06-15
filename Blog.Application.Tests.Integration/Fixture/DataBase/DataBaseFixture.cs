using System;
using System.Transactions;
using Blog.Application.Tests.Integration.Utils;
using Blog.Infrastructure.Persistent.EF.Context;

namespace Blog.Application.Tests.Integration.Fixture.DataBase
{
    public class DataBaseFixture : IDisposable
    {
        public readonly BlogContext context;
        private readonly TransactionScope scope;
        public DataBaseFixture()
        {
            context = DbFactory.GetDataBase();
            scope = new TransactionScope();
        }
        public void Dispose()
        {
            try
            {
                scope.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            context.Dispose();
        }
    }
}