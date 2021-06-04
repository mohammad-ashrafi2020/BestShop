using System;
using Blog.Application.Tests.Integration.Utils;
using Blog.Infrastructure.Persistent.EF.Context;

namespace Blog.Application.Tests.Integration.Fixture.DataBase
{
    public class DataBaseFixture:IDisposable
    {
        public BlogContext context;
        public DataBaseFixture()
        {
            context = DbFactory.GetDataBase();
        }
        public void Dispose()
        {
            
        }
    }
}