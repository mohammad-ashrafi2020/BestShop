using Blog.Infrastructure.Persistent.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Tests.Integration.Utils
{
    public class DbFactory
    {
        public static BlogContext GetDataBase()
        {
            var options = new DbContextOptionsBuilder<BlogContext>()
                .UseInMemoryDatabase("TestDb")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .Options;
            var context = new BlogContext(options);
            return context;
        }
    }
}