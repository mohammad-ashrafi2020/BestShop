using System;
using System.Threading;
using Blog.Application.Services.Posts.Commands.EditPost;
using Blog.Application.Tests.Integration.Fixture.DataBase;
using Blog.Domain.Entities.BlogPostAggregate;
using Blog.Domain.Entities.BlogPostAggregate.Rules;
using Blog.Infrastructure.Persistent.EF.Context;
using FluentAssertions;
using framework;
using NSubstitute;
using Xunit;

namespace Blog.Application.Tests.Integration.Services.Posts.Commands
{
    [Collection("DataBase")]
    public class EditPostCommandHandlerTests
    {
        private readonly BlogContext _db;
        private readonly IPostSlugUniquenessChecker _slugChecker;
        private BlogPost post;
        public EditPostCommandHandlerTests(DataBaseFixture dataBaseFixture)
        {
            _slugChecker = Substitute.For<IPostSlugUniquenessChecker>();
            _slugChecker.IsUniq(Arg.Any<string>()).Returns(true);
            _db = dataBaseFixture.context;
            post = new BlogPost(Guid.NewGuid(), "T", "T", "T", "T", "T", "T", "T", "T", 5, 1, null, DateTime.Now, true,
                _slugChecker);
            _db.BlogPosts.Add(post);
            _db.SaveChanges();
        }

        [Fact]
        public void Should_Return_Success_When_Data_is_OK()
        {
            //Arrange
            var command = new EditPostCommand("Edited", "Edited", "Edited", "Edited", "Edited", "Edited", 5, 2, 1, null,
                true, true, null, post.Id);
            var handler = new EditPostCommandHandler(_db, _slugChecker);
            //Act
            var res=handler.Handle(command, new CancellationToken()).Result;

            //Asserts
            res.Status.Should().Be(OperationResultStatus.Success);
        }
        [Fact]
        public void Should_Return_NotFound_When_Id_Is_Fake()
        {
            //Arrange
            var command = new EditPostCommand("Edited", "Edited", "Edited", "Edited",
                "Edited", "Edited", 5, 2, 1, null,
                true, true, null, -10);
            var handler = new EditPostCommandHandler(_db, _slugChecker);
            //Act
            var res = handler.Handle(command, new CancellationToken()).Result;

            //Asserts
            res.Status.Should().Be(OperationResultStatus.NotFound);
        }
    }
}