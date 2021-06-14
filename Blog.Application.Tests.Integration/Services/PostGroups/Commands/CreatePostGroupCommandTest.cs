using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using _DomainUtils.Exceptions;
using Blog.Application.Common.Validation;
using Blog.Application.Services.PostGroups.Commands.CreateGroup;
using Blog.Application.Services.PostGroups.DomainServices;
using Blog.Application.Tests.Integration.Fixture.DataBase;
using Blog.Domain.Entities.BlogPostGroupAggregate;
using Blog.Domain.Entities.BlogPostGroupAggregate.Rules;
using Blog.Infrastructure.Persistent.EF.Context;
using FluentAssertions;
using FluentValidation;
using framework;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using Xunit;

namespace Blog.Application.Tests.Integration.Services.PostGroups.Commands
{
    [Collection("DataBase")]
    public class CreatePostGroupCommandTest
    {
        private BlogContext _db;
        private IEnglishTitleUniquenessChecker _checker;
        public CreatePostGroupCommandTest(DataBaseFixture db)
        {
            _db = db.context;
            _checker = Substitute.For<IEnglishTitleUniquenessChecker>();
        }

        [Fact]
        public async Task Should_Create_New_Group()
        {
            //Arrange
            _checker.IsUnique(Arg.Any<string>()).Returns(true);
            var command = new CreatePostGroupCommand("Test", "Test 21", "Test", null);
            var handler = new CreatePostGroupCommandHandler(_db, _checker);

            //Act
            var res = await handler.Handle(command, new CancellationToken());
            await _db.SaveChangesAsync();
            //Asserts
            res.Status.Should().Be(OperationResultStatus.Success);

            //TearDown
        }
        [Fact(DisplayName = "Add Child")]
        public async Task Should_Add_Child_To_Main_Group()
        {
            //Arrange
            _checker.IsUnique(Arg.Any<string>()).Returns(true);
            var blogGroup = new BlogPostGroup("Tes2t", "Test", "Test", _checker);
            _db.BlogPostGroups.Add(blogGroup);
            await _db.SaveChangesAsync();

            var command = new CreatePostGroupCommand("Child", "Child", "Test", blogGroup.Id);
            var handler = new CreatePostGroupCommandHandler(_db, _checker);

            //Act
            var res = await handler.Handle(command, new CancellationToken());
            await _db.SaveChangesAsync();

            //Asserts
            res.Status.Should().Be(OperationResultStatus.Success);
            _db.BlogPostGroups.Include(c => c.Groups).First(b => b.Id == blogGroup.Id).Groups.Should().HaveCount(1);

            //TearDown
            _db.BlogPostGroups.Remove(blogGroup);
            await _db.SaveChangesAsync();
        }
        [Fact(DisplayName = "Add Child")]
        public async Task Should_Return_NotFound_When_NotFound_Parent()
        {
            //Arrange
            var command = new CreatePostGroupCommand("Child", "child 2", "Test", 200);//200 = fakeId => null Entity
            var handler = new CreatePostGroupCommandHandler(_db, _checker);

            //Act
            var res = await handler.Handle(command, new CancellationToken());
            await _db.SaveChangesAsync();

            //Asserts
            res.Status.Should().Be(OperationResultStatus.NotFound);
        }

        [Fact]
        public async Task Should_Throw_Exception_When_EnglishTitle_Is_duplicated()
        {

            _checker.IsUnique(Arg.Any<string>()).Returns(true);
            var blogGroup = new BlogPostGroup("Test 2", "Test", "Test", _checker);
            _db.BlogPostGroups.Add(blogGroup);
            await _db.SaveChangesAsync();
            //Arrange
            var command = new CreatePostGroupCommand("Test", "Test", "Test", null);
            _checker.IsUnique(Arg.Any<string>()).Returns(false);
            var handler = new CreatePostGroupCommandHandler(_db, _checker);

            //Act
            Action action = () =>
           {
               var res = handler.Handle(command, new CancellationToken()).Result;
           };

            //Asserts
            action.Should().Throw<InvalidDomainDataException>()
                .WithMessage("عنوان انگلیسی تکراری است");

            //TearDown
            _db.BlogPostGroups.Remove(blogGroup);
            await _db.SaveChangesAsync();
        }
    }
}