using Xunit;

namespace Blog.Application.Tests.Integration.Fixture.DataBase
{
    [CollectionDefinition("DataBase")]
    public class DataBaseCollection:ICollectionFixture<DataBaseFixture>
    {
        
    }
}