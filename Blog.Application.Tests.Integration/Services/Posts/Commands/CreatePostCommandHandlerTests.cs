using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using _DomainUtils.Exceptions;
using Blog.Application.Services.Posts.Commands.CreatePost;
using Blog.Application.Tests.Integration.Fixture.DataBase;
using Blog.Domain.Entities.BlogPostAggregate.Rules;
using Blog.Infrastructure.Persistent.EF.Context;
using FluentAssertions;
using framework;
using framework.SecurityUtil;
using Microsoft.AspNetCore.Http;
using NSubstitute;
using Xunit;

namespace Blog.Application.Tests.Integration.Services.Posts.Commands
{
    [Collection("DataBase")]
    public class CreatePostCommandHandlerTests
    {
        private readonly BlogContext _db;
        private readonly IPostSlugUniquenessChecker _slugChecker;
        public CreatePostCommandHandlerTests(DataBaseFixture dataBaseFixture)
        {
            _slugChecker = Substitute.For<IPostSlugUniquenessChecker>();
            _slugChecker.IsUniq(Arg.Any<string>()).Returns(true);
            _db = dataBaseFixture.context;
        }

        [Fact]
        public async Task Should_Return_Success()
        {
            //Arrange
            var file = MockIFormFile();
            var command = new CreatePostCommand(Guid.NewGuid(),
                "Test",
                "test-t", "Test",
                "Test", "test", "Test", 5,
                1, null, "1399/05/05", true, true, file);
            var handler = new CreatePostCommandHandler(_db, _slugChecker);
            //Act
            var res = await handler.Handle(command, new CancellationToken());

            //Asserts
            res.Status.Should().Be(OperationResultStatus.Success);

            //TearDown

            var path = Directory.GetCurrentDirectory() + "//wwwroot//images";
            var directory = new DirectoryInfo(path);
            directory.Delete(true); //Delete Image
        }
        [Fact]
        public void Should_Return_Error_When_Slug_Is_Duplicated()
        {
            //Arrange
            var file = MockIFormFile();
            _slugChecker.IsUniq(Arg.Any<string>()).Returns(false);
            var command = new CreatePostCommand(Guid.NewGuid(),
                "Test",
                "Test", "Test",
                "Test", "test", "Test", 5,
                1, null, "1399/05/05", true, true, file);
            var handler = new CreatePostCommandHandler(_db, _slugChecker);

            //Act
            Action action = new Action(() =>
            {
                var res = handler.Handle(command, new CancellationToken()).Result;
            });

            //Asserts
            action.Should().Throw<InvalidDomainDataException>()
                .WithMessage("عنوان انگلیسی تکراری است");
        }
        [Fact]
        public async Task Should_Return_Error_When_Slug_Is_Unicode()
        {
            //Arrange
            var file = MockIFormFile();
            var command = new CreatePostCommand(Guid.NewGuid(),
                "Test",
                "سلام", "Test",
                "Test", "test", "Test", 5,
                1, null, "1399/05/05", true, true, file);
            var handler = new CreatePostCommandHandler(_db, _slugChecker);

            //Act
            var res = await handler.Handle(command, new CancellationToken());


            //Asserts
            res.Status.Should().Be(OperationResultStatus.Error);
            res.Message.Should().Be("عنوان انگلیسی فقط قادر به ذخیره متن انگلیسی می باشد");
        }
        [Fact]
        public async Task Should_Return_Error_When_IformFile_is_Null()
        {
            //Arrange
            var command = new CreatePostCommand(Guid.NewGuid(),
                "Test",
                "سلام", "Test",
                "Test", "test", "Test", 5,
                1, null, "1399/05/05", true, true, null);
            var handler = new CreatePostCommandHandler(_db, _slugChecker);

            //Act
            var res = await handler.Handle(command, new CancellationToken());


            //Asserts
            res.Status.Should().Be(OperationResultStatus.Error);
            res.Message.Should().Be("عکس را وارد کنید");
        }

        private IFormFile MockIFormFile()
        {
            //Should Exist File In Path
            var filePath = @"C:\Banner.png";
            var stream = File.OpenRead(filePath);
            var file = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(filePath))
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/png"
            };
            return file;
        }
    }
}