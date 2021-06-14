using System;
using _DomainUtils.Exceptions;
using Blog.Domain.Entities.BlogPostGroupAggregate;
using Blog.Domain.Entities.BlogPostGroupAggregate.Rules;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Blog.Domain.Tests.Unit.Entities.BlogPostGroups
{
    public class BlogPostGroupTest
    {
        private BlogPostGroup blogGroup;
        private IEnglishTitleUniquenessChecker _checker;

        public BlogPostGroupTest()
        {
            _checker = NSubstitute.Substitute.For<IEnglishTitleUniquenessChecker>();
            _checker.IsUnique(NSubstitute.Arg.Any<string>()).Returns(true);
            blogGroup = new("Test Title", "گروه تست", "Meta Description", _checker);
        }

        [Fact(DisplayName = "Create Group")]
        public void Should_Create_Group()
        {
            //Asserts
            blogGroup.Should().NotBeNull();
            blogGroup.EnglishGroupTitle.Should().Be("test title");//.ToLower()
        }
        [Fact(DisplayName = "Create Group")]
        public void Should_Throw_Exception_When_EnglishTitle_is_Unicode()
        {
            //Act
            Action action = () =>
            {
                //Arrange
                var newGroup = new BlogPostGroup("متن فارسی", "Test", "Test", _checker);
            };

            //Asserts
            action.Should().Throw<InvalidDomainDataException>().WithMessage("عنوان انگلیسی فقط باید شامل حرف انگلیسی باشد");
        }
        [Fact(DisplayName = "Create Group")]
        public void CreateGroup_Should_Throw_Exception_When_Create_User_Width_Null_Value()
        {
            //Act
            Action action = () =>
            {
                var post = new BlogPostGroup(null, "Test", "Test", _checker);
            };
            //Asserts
            action.Should().Throw<InvalidDomainDataException>()
                .WithMessage("عنوان انگلیسی اجباری است");
        }
        [Fact(DisplayName = "Create Group")]
        public void CreateGroup_Should_Throw_Exception_When_GroupTitle_Is_Null()
        {
            //Act
            Action action = () =>
            {
                var post = new BlogPostGroup("test T", null, "Test", _checker);
            };
            //Asserts
            action.Should().Throw<InvalidDomainDataException>()
                .WithMessage("عنوان گروه اجباری است");
        }
        [Fact(DisplayName = "Create Group")]
        public void CreateGroup_Should_Throw_Exception_When_MetaDescription_Is_Null()
        {
            //Act
            Action action = () =>
            {
                var post = new BlogPostGroup("test T", "Test", null, _checker);
            };
            //Asserts
            action.Should().Throw<InvalidDomainDataException>()
                .WithMessage("Meta Description Is Required");
        }
        [Fact(DisplayName = "Edit Group")]
        public void Should_Edit_Group()
        {
            //Act
            blogGroup.Edit("Edited ", "Edited", "Edited", _checker);

            //Asserts
            blogGroup.EnglishGroupTitle.Should().Be("edited");
            blogGroup.ModifyDate.Should().NotBeNull();
        }
        [Fact(DisplayName = "Edit Group")]
        public void EditGroup_Should_Throw_Exception_When_EnglishTitle_is_Unicode()
        {
            //Act
            Action action = () =>
            {
                blogGroup.Edit("متن فارسی ", "Edited", "Edited", _checker);
            };
            //Asserts
            action.Should().Throw<InvalidDomainDataException>().WithMessage("عنوان انگلیسی فقط باید شامل حرف انگلیسی باشد");
        }
        [Fact(DisplayName = "Edit Group")]
        public void EditGroup_Should_Throw_Exception_When_EnglishTitle_is_Duplicated()
        {
            //Act
            Action action = () =>
            {
                _checker.IsUnique(Arg.Any<string>()).Returns(false);
                blogGroup.Edit("duplicated", "Edited", "Edited", _checker);
            };
            //Asserts
            action.Should().Throw<InvalidDomainDataException>()
                .WithMessage("عنوان انگلیسی تکراری است");
        }
        [Fact(DisplayName = "Edit Group")]
        public void EditGroup_Should_Throw_Exception_When_EnglishTitle_Is_Null()
        {
            //Act
            Action action = () =>
            {
                blogGroup.Edit(null, "Edited", "Edited", _checker);

            };
            //Asserts
            action.Should().Throw<InvalidDomainDataException>()
                .WithMessage("عنوان انگلیسی اجباری است");
        }
        [Fact(DisplayName = "Edit Group")]
        public void EditGroup_Should_Throw_Exception_When_GroupTitle_Is_Null()
        {
            //Act
            Action action = () =>
            {
                blogGroup.Edit("Edited", null, "Edited", _checker);

            };

            //Asserts
            action.Should().Throw<InvalidDomainDataException>()
                .WithMessage("عنوان گروه اجباری است");
        }
        [Fact(DisplayName = "Edit Group")]
        public void EditGroup_Should_Throw_Exception_When_MetaDescription_Is_Null()
        {
            //Act
            Action action = () =>
            {
                blogGroup.Edit("Edited", "Test", null, _checker);

            };

            //Asserts
            action.Should().Throw<InvalidDomainDataException>()
                .WithMessage("Meta Description Is Required");
        }
        [Fact]
        public void AddChild()
        {
            //Act
            blogGroup.AddChild("Test ", "test", "Test", _checker);

            //Asserts
            blogGroup.Groups.Should().HaveCount(1);
        }
    }
}