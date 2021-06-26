using System;
using System.Threading;
using System.Threading.Tasks;
using Blog.Application.Services.PostGroups.Commands.EditGroup;
using Blog.Application.Tests.Integration.Fixture.DataBase;
using Blog.Domain.Entities.BlogPostGroupAggregate;
using Blog.Domain.Entities.BlogPostGroupAggregate.Rules;
using Blog.Infrastructure.Persistent.EF.Context;
using Common.Application;
using Common.Domain.Exceptions;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Blog.Application.Tests.Integration.Services.PostGroups.Commands
{
    [Collection("DataBase")]
    public class EditPostGroupCommandTests
    {
        private BlogContext _db;
        private readonly IEnglishTitleUniquenessChecker _checker;

        public EditPostGroupCommandTests(DataBaseFixture db)
        {
            _db = db.context;
            _checker = Substitute.For<IEnglishTitleUniquenessChecker>();
            _checker.IsUnique(Arg.Any<string>()).Returns(true);
        }
        [Fact]
        public async Task Should_Edit_PostGroup_And_return_Success_Status()
        {
            //Arrange
            _checker.IsUnique(Arg.Any<string>()).Returns(true);
            var group = new BlogPostGroup("Test", "test", "test", _checker);
            _db.BlogPostGroups.Add(group);
            await _db.SaveChangesAsync();

            var command = new EditPostGroupCommand(group.Id, group.MetaDescription,
                group.EnglishGroupTitle, "Group Edited");
            var handler = new EditPostGroupCommandHandler(_db, _checker);

            //Act
            var res = await handler.Handle(command, new CancellationToken());


            //Asserts
            res.Status.Should().Be(OperationResultStatus.Success);
            group.GroupTitle.Should().Be("Group Edited");
        }
        [Fact]
        public async Task Should_Throw_Exception_When_EnglishTitle_Is_duplicated()
        {
            //Arrange
            var group = new BlogPostGroup("Test", "test", "test", _checker);
            _db.BlogPostGroups.Add(group);
            await _db.SaveChangesAsync();

            var command = new EditPostGroupCommand(group.Id, group.MetaDescription,
                "Group Edited", "Group Edited");
            var handler = new EditPostGroupCommandHandler(_db, _checker);

            //Act
            Action action = () =>
            {
                _checker.IsUnique(Arg.Any<string>()).Returns(false);
                var res =  handler.Handle(command, new CancellationToken()).Result;
            };

            //Asserts
            action.Should().Throw<InvalidDomainDataException>()
                .WithMessage("عنوان انگلیسی تکراری است");
        }
    }
}