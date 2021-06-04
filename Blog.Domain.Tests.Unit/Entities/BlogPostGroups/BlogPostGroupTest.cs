using System;
using _DomainUtils.Exceptions;
using Blog.Domain.Entities.BlogPostGroupAggregate;
using FluentAssertions;
using Xunit;

namespace Blog.Domain.Tests.Unit.Entities.BlogPostGroups
{
    public class BlogPostGroupTest
    {
        private BlogPostGroup blogGroup;
        public BlogPostGroupTest()
        {
            blogGroup = new("Test Title", "گروه تست", "Meta Description");
        }

        [Fact(DisplayName = "Create Group")]
        public void Should_Create_Group()
        {
            //Asserts
            blogGroup.Should().NotBeNull();
            blogGroup.EnglishGroupTitle.Should().Be("test title");//.ToLower()
        }
        [Fact(DisplayName = "Create Group")]
        public void CreateGroup_Should_Throw_Exception_When_Create_User_Width_Null_Value()
        {
            //Act
            Action action = () =>
            {
                var post = new BlogPostGroup(null, "Test", "Test");
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
                var post = new BlogPostGroup("test T", null, "Test");
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
                var post = new BlogPostGroup("test T", "Test", null);
            };
            //Asserts
            action.Should().Throw<InvalidDomainDataException>()
                .WithMessage("Meta Description Is Required");
        }
        [Fact(DisplayName = "Edit Group")]
        public void Should_Edit_Group()
        {
            //Act
            blogGroup.Edit("Edited ", "Edited", "Edited");

            //Asserts
            blogGroup.EnglishGroupTitle.Should().Be("edited");
            blogGroup.ModifyDate.Should().NotBeNull();
        }
        [Fact(DisplayName = "Edit Group")]
        public void EditGroup_Should_Throw_Exception_When_EnglishTitle_Is_Null()
        {
            //Act
            Action action = () =>
            {
                blogGroup.Edit(null, "Edited", "Edited");

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
                blogGroup.Edit("Edited", null, "Edited");

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
                blogGroup.Edit("Edited", "Test", null);

            };

            //Asserts
            action.Should().Throw<InvalidDomainDataException>()
                .WithMessage("Meta Description Is Required");
        }
        [Fact]
        public void AddChild()
        {
            //Act
            blogGroup.AddChild("Test ","test","Test");

            //Asserts
            blogGroup.Groups.Should().HaveCount(1);
        }
    }
}