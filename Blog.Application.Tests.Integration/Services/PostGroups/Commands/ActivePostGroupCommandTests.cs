using System.Threading;
using System.Threading.Tasks;
using Blog.Application.Services.PostGroups.Commands.ActiveGroup;
using Blog.Application.Tests.Integration.Fixture.DataBase;
using Blog.Domain.Entities.BlogPostGroupAggregate;
using Blog.Infrastructure.Persistent.EF.Context;
using FluentAssertions;
using framework;
using MediatR;
using Xunit;

namespace Blog.Application.Tests.Integration.Services.PostGroups.Commands
{
    [Collection("DataBase")]
    public class ActivePostGroupCommandTests
    {
        private IMediator _mediator;
        private BlogContext _db;
        public ActivePostGroupCommandTests(DataBaseFixture db)
        {
            _db = db.context;
            _mediator = NSubstitute.Substitute.For<IMediator>();
        }

        [Fact]
        public async Task Should_Return_Success_And_SetActive_Group()
        {
            //Arrange
            var group = new BlogPostGroup("Test t", "test", "test");
            group.Delete();
            _db.BlogPostGroups.Add(group);
            await _db.SaveChangesAsync();

            var command = new ActivePostGroupCommand(group.Id);
            var handler = new ActivePostGroupCommandHandler(_db);

            //Act
            var res =await handler.Handle(command, new CancellationToken());

            //Asserts
            Assert.True(res.Status == OperationResultStatus.Success);
            Assert.False(group.IsDelete);
            //TearDown
            _db.BlogPostGroups.Remove(group);
            await _db.SaveChangesAsync();
        }
        [Fact]
        public async Task Should_Return_NotFound_When_GroupNotExist_Or_Group_Is_Not_Deleted()
        {
            //Arrange
            var group = new BlogPostGroup("Test t", "test", "test");
            _db.BlogPostGroups.Add(group);
            await _db.SaveChangesAsync();

            var command = new ActivePostGroupCommand(group.Id);
            var handler = new ActivePostGroupCommandHandler(_db);

            //Act
            var res = await handler.Handle(command, new CancellationToken());

            Assert.True(res.Status == OperationResultStatus.NotFound);

            //TearDown
            _db.BlogPostGroups.Remove(group);
            await _db.SaveChangesAsync();
        }
    }
}