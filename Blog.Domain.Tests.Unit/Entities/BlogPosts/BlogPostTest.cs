using System;
using _DomainUtils.Exceptions;
using Xunit;
using Blog.Domain.Entities.BlogPostAggregate;
using Blog.Domain.Entities.BlogPostAggregate.Rules;
using FluentAssertions;
using NSubstitute;

namespace Blog.Domain.Tests.Unit.Entities.BlogPosts
{
    public class BlogPostTest
    {
        private readonly BlogPost _post;
        private IPostSlugUniquenessChecker _slugChecker;
        public BlogPostTest()
        {
            _slugChecker = Substitute.For<IPostSlugUniquenessChecker>();
            _slugChecker.IsUniq(Arg.Any<string>()).Returns(true);
            //Arrange
            _post = new(Guid.NewGuid(), "Test Title",
                 "Meta", "test-s", "Test", "test.jpg", "test",
                 "test", "test", 10, 1, null, DateTime.Now, true, _slugChecker);
        }
        [Fact(DisplayName = "Create Post")]
        public void Should_Create_BlogPost()
        {
            //Asserts
            Assert.NotNull(_post);
        }
        [Fact(DisplayName = "Create Post")]
        public void Should_Return_Exception_When_Slug_Is_Duplicated()
        {
            Action action = new Action(() =>
            {
                _slugChecker.IsUniq(Arg.Any<string>()).Returns(false);
                var post = new BlogPost(Guid.NewGuid(), "Test Title",
                    "Meta", "test-s", "Test", "test.jpg", "test",
                    "test", "test", 10, 1, null, DateTime.Now, true, _slugChecker);
            });
            //Asserts
            action.Should().Throw<InvalidDomainDataException>();
        }
        [Fact(DisplayName = "Create Post")]
        public void Should_Return_Exception_When_Title_Or_Description_Is_Null()
        {
            //Act
            Action postAct = () =>
            {
                //Arrange
                var blogPost = new BlogPost(Guid.NewGuid(), null,
                    "Meta", "test-s", "Test",
                    "test.jpg", "test", "test", "test", 10, 1,
                    null, DateTime.Now, true, _slugChecker);
            };

            //Asserts
            postAct.Should().Throw<InvalidDomainDataException>()
                .WithMessage("Title And Description Is Required");
        }
        [Fact(DisplayName = "Delete Post")]
        public void Should_Delete_Post_When_call_method_Delete()
        {
            //Act
            _post.Delete();

            //Asserts
            _post.IsDelete.Should().BeTrue();
            _post.DeleteDate.Should().NotBeNull();
        }

        [Fact(DisplayName = "Recovery Post")]
        public void Should_Recovery_Post_When_call_method_Recovery()
        {
            //Act
            _post.Delete();

            //Asserts
            _post.IsDelete.Should().BeTrue();
            _post.DeleteDate.Should().NotBeNull();

            //Act
            _post.Recovery();

            _post.IsDelete.Should().BeFalse();
        }

        [Fact(DisplayName = "EditPost")]
        public void Should_Edit_Post_When_Call_Method_Edit()
        {
            //Act
            _post.Edit("Edited", "Edited", "Edited", "Edited", "Edited", "Edited", "Edited", 2,
                2, 2, DateTime.Now, true, _slugChecker);

            //Asserts
            _post.Tags.Should().Be("Edited");
            _post.ModifyDate.Should().NotBeNull();
        }
        [Fact(DisplayName = "EditPost")]
        public void Should_Throw_Domain_Exception_When_Edit_Post_With_Null_Value()
        {
            //Act
            Action action = () =>
            {
                _post.Edit("Edited", null, "Edited", "Edited", "Edited", "Edited", "Edited", 2,
                    2, 2, DateTime.Now, true, _slugChecker);
            };


            //Asserts
            action.Should().Throw<InvalidDomainDataException>();
        }
        [Fact(DisplayName = "EditPost")]
        public void Should_Throw_Domain_Exception_When_Edit_Post_With_Duplicated_Slug()
        {
            //Act
            Action action = () =>
            {
                _slugChecker.IsUniq(Arg.Any<string>()).Returns(false);
                _post.Edit("Edited", "Edited", "Edited", "Edited", "Edited", 
                    "Edited", "Edited", 2,
                    2, 2, DateTime.Now, true, _slugChecker);
            };


            //Asserts
            action.Should().Throw<InvalidDomainDataException>()
                .WithMessage("عنوان انگلیسی تکراری است");
        }
        [Fact(DisplayName = "IncreaseVisit")]
        public void Should_Increase_Visit_For_Post()
        {
            //Act
            _post.IncreaseVisit();


            //Asserts
            _post.Visit.Should().Be(1);
        }
    }
}