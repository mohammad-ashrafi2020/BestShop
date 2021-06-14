using System;
using System.IO;
using System.Threading.Tasks;
using Blog.Application.Services.Posts.Commands.CreatePost;
using Blog.Application.Tests.Integration.Fixture.DataBase;
using Blog.Infrastructure.Persistent.EF.Context;
using Microsoft.AspNetCore.Http;
using NSubstitute;
using Xunit;

namespace Blog.Application.Tests.Integration.Services.Posts.Commands
{
    [Collection("DataBase")]
    public class CreatePostCommandHandlerTests
    {
        private readonly BlogContext _db;
        public CreatePostCommandHandlerTests(DataBaseFixture dataBaseFixture)
        {
            _db = dataBaseFixture.context;
        }

        [Fact]
        public async Task Should_Return_Success()
        {
            //Arrange
            var command = new CreatePostCommand(Guid.NewGuid(),
                "Test",
                "test-t", "Test",
                "Test", "test", "Test", 5,
                1, null, "1399/05/05", true, true,null);
        }
    }
}