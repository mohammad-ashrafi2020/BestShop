using System.Threading;
using System.Threading.Tasks;
using Blog.Application.Services.PostGroups.Commands.TogglePostGroupStatus;
using Blog.Application.Tests.Integration.Fixture.DataBase;
using Blog.Domain.Entities.BlogPostGroupAggregate;
using Blog.Domain.Entities.BlogPostGroupAggregate.Rules;
using Blog.Infrastructure.Persistent.EF.Context;
using FluentAssertions;
using framework;
using MediatR;
using NSubstitute;
using Xunit;

namespace Blog.Application.Tests.Integration.Services.PostGroups.Commands
{
    [Collection("DataBase")]
    public class TogglePostGroupStatusCommandTests
    {
        private BlogContext _db;
        private IEnglishTitleUniquenessChecker _checker;

        public TogglePostGroupStatusCommandTests(DataBaseFixture db)
        {
            _db = db.context;
            _checker = Substitute.For<IEnglishTitleUniquenessChecker>();
        }
        [Fact]
        public async Task Should_Return_Success_And_Delete_Group()
        {
            //Arrange
            _checker.IsUnique(Arg.Any<string>()).Returns(true);
            var group = new BlogPostGroup("Test", "test", "test", _checker);
            _db.BlogPostGroups.Add(group);
            await _db.SaveChangesAsync();

            var command = new TogglePostGroupStatusCommand(group.Id);
            var handler = new TogglePostGroupStatusCommandHandler(_db);

            //Act
            var res = await handler.Handle(command, new CancellationToken());

            //Asserts
            Assert.True(res.Status == OperationResultStatus.Success);
            Assert.True(group.IsDelete);
        }
        [Fact]
        public async Task Should_Return_Success_And_Recovery_Group()
        {
            //Arrange
            _checker.IsUnique(Arg.Any<string>()).Returns(true);
            var group = new BlogPostGroup("Test", "test", "test", _checker);
            group.Delete();
            _db.BlogPostGroups.Add(group);
            await _db.SaveChangesAsync();

            var command = new TogglePostGroupStatusCommand(group.Id);
            var handler = new TogglePostGroupStatusCommandHandler(_db);

            //Act
            var res =await handler.Handle(command, new CancellationToken());

            //Asserts
            Assert.True(res.Status == OperationResultStatus.Success);
            Assert.False(group.IsDelete);
        }
        [Fact]
        public async Task Should_Return_NotFound_When_GroupNotExist()
        {
            //Arrange
            var command = new TogglePostGroupStatusCommand(-10);
            var handler = new TogglePostGroupStatusCommandHandler(_db);

            //Act
            var res = await handler.Handle(command, new CancellationToken());

            //Asserts
            Assert.True(res.Status == OperationResultStatus.NotFound);
        }
    }
}