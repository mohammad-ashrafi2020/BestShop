using System.Net.Mime;
using System.Threading.Tasks;
using Account.Application.Models.DTOs.Cards;
using Account.Application.Services.Users.Cards;
using Account.Application.Tests.Fixture;
using Account.Application.Tests.Utils.UserCards;
using Account.Domain.Entities.Users;
using Account.Infrastructure.Context;
using AutoMapper;
using FluentAssertions;
using framework;
using NSubstitute;
using Xunit;

namespace Account.Application.Tests.Services.Cards
{
    [Collection("DataBase Collection")]
    public class UserCardServiceTests
    {
        private readonly PublicFixture _publicFixture;
        private readonly UserCardService _userCardService;
        private readonly CardUtil _cardUtil;
        private readonly IMapper _mapper;
        public UserCardServiceTests(PublicFixture fixture)
        {
            _publicFixture = fixture;
            _cardUtil = new CardUtil(fixture.UserId, fixture._context);
            _mapper = Substitute.For<IMapper>();
            _userCardService = new UserCardService(fixture._context, _mapper);
        }

        [Fact(DisplayName = "GetUserCardBy")]
        public async Task Should_Return_SuccessStatus_And_Return_UserCard_By_CardId_When_CardIsExist()
        {
            //Arrange
            var card = _cardUtil.InsertCard();

            //Act
            var res = await _userCardService.GetUserCardBy(card.Id);

            //Asserts
            Assert.True(res.Status == ResultModelStatus.Success);
            res.Data.Id.Should().Be(card.Id);

            //Clean
            _cardUtil.CleanCard(card);
        }
        [Fact(DisplayName = "GetUserCardBy")]
        public async Task GetCardById_Should_Return_NotFoundStatus_When_CardNotExist()
        {
            //Act
            var res = await _userCardService.GetUserCardBy(-1);

            //Asserts
            Assert.True(res.Status == ResultModelStatus.NotFound);
        }
        [Fact(DisplayName = "GetUserCards")]
        public async Task GetUserCards_By_UserId_Should_Return_ListOfUserCard_And_Return_SuccessStatus()
        {
            //Act
            var res = await _userCardService.GetUserCards(_publicFixture.UserId);

            //Asserts
            Assert.True(res.Status == ResultModelStatus.Success);
            res.Data.Should().HaveCountGreaterOrEqualTo(0);
        }

        [Fact(DisplayName = "InsertCard")]
        public async Task Should_Insert_Card_And_Return_SuccessStatus()
        {
            //Arrange
            var insertModel = new InsertCardDto()
            {
                AccountNumber = "123456789",
                BankName = "Test2",
                CardNumber = "603799",
                OwnerName = "Mohammad",
                ShabaNumber = "12345678",
                UserId = _publicFixture.UserId
            };
            var card = _cardUtil.CreateNewObjectOfUserCard(insertModel);

            //Act
            _mapper.Map<UserCard>(Arg.Any<InsertCardDto>()).Returns(card);
            var res = await _userCardService.InsertCard(insertModel);

            //asserts
            Assert.True(res.Status == ResultModelStatus.Success);

            //Clean
            _cardUtil.CleanCard(card);
        }
        [Fact(DisplayName = "EditCard")]
        public async Task Should_Edit_Card_And_Return_SuccessStatus_When_DataIsOk()
        {
            //Arrange
            var card = _cardUtil.InsertCard();
            var editModel = new EditCardDto()
            {
                AccountNumber = "123456789",
                BankName = "Test2",
                CardNumber = "603799",
                OwnerName = "Card_Edited",
                ShabaNumber = "12345678",
                UserId = _publicFixture.UserId,
                Id = card.Id
            };
            //Act
            var res = await _userCardService.EditCard(editModel);

            //asserts
            Assert.True(res.Status == ResultModelStatus.Success);
            card.OwnerName.Should().Be("Card_Edited");

            //Clean
            _cardUtil.CleanCard(card);
        }
        [Fact(DisplayName = "EditCard")]
        public async Task EditCard_Should_Return_NotFoundStatus_When_Card_Not_Exist()
        {
            //Arrange
            var editModel = new EditCardDto()
            {
                AccountNumber = "123456789",
                BankName = "Test2",
                CardNumber = "603799",
                OwnerName = "Card_Edited",
                ShabaNumber = "12345678",
                UserId = _publicFixture.UserId,
                Id = -1
            };
            //Act
            var res = await _userCardService.EditCard(editModel);

            //asserts
            Assert.True(res.Status == ResultModelStatus.NotFound);
        }
        [Fact(DisplayName = "EditCard")]
        public async Task EditCard_Should_Return_ErrorStatus_When_Card_Not_For_User()
        {
            //Arrange
            var card = _cardUtil.InsertCard();
            var editModel = new EditCardDto()
            {
                AccountNumber = "123456789",
                BankName = "Test2",
                CardNumber = "603799",
                OwnerName = "Card_Edited",
                ShabaNumber = "12345678",
                UserId = -1,
                Id = card.Id
            };
            //Act
            var res = await _userCardService.EditCard(editModel);

            //asserts
            Assert.True(res.Status == ResultModelStatus.Error);

            //Clean
            _cardUtil.CleanCard(card);
        }
        [Fact(DisplayName = "DeleteCardByAdmin")]
        public async Task Should_Return_NotFoundStatus_When_Card_NotFound()
        {
            //Act
            var res = await _userCardService.DeleteCardByAdmin(-1,_publicFixture.UserId);

            //asserts
            Assert.True(res.Status == ResultModelStatus.NotFound);
        }
        [Fact(DisplayName = "DeleteCardByAdmin")]
        public async Task Should_Return_SuccessStatus_When_every_Thing_is_Ok()
        {
            //Arrange
            var card = _cardUtil.InsertCard();

            //Act
            var res = await _userCardService.DeleteCardByAdmin(card.Id, _publicFixture.UserId);

            //asserts
            Assert.True(res.Status == ResultModelStatus.Success);

            //Clean
            _cardUtil.CleanCard(card);
        }
        [Fact(DisplayName = "DeleteCard")]
        public async Task DeleteCard_Should_Return_NotFoundStatus_When_Card_NotFound()
        {
            //Act
            var res = await _userCardService.DeleteCard(-1, _publicFixture.UserId);

            //asserts
            Assert.True(res.Status == ResultModelStatus.NotFound);
        }
        [Fact(DisplayName = "DeleteCard")]
        public async Task DeleteCard_Should_Return_ErrorStatus_When_Card_Not_For_User()
        {
            //Arrange
            var card = _cardUtil.InsertCard();

            //Act
            var res = await _userCardService.DeleteCard(card.Id, -1);

            //asserts
            Assert.True(res.Status == ResultModelStatus.Error);

            //Clean
            _cardUtil.CleanCard(card);
        }
        [Fact(DisplayName = "DeleteCard")]
        public async Task DeleteCard_Should_Return_SuccessStatus_When_every_Thing_is_Ok()
        {

            //Arrange
            var card = _cardUtil.InsertCard();

            //Act
            var res = await _userCardService.DeleteCard(card.Id, _publicFixture.UserId);

            //asserts
            Assert.True(res.Status == ResultModelStatus.Success);

            //Clean
            _cardUtil.CleanCard(card);
        }
    }
}