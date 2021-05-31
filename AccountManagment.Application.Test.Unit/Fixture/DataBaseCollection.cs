using Xunit;

namespace Account.Application.Tests.Fixture
{
    [CollectionDefinition("DataBase Collection")]
    public class DataBaseCollection:ICollectionFixture<PublicFixture>
    {
        
    }
}