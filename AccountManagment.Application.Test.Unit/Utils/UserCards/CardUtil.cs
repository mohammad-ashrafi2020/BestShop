using System;
using Account.Application.Models.DTOs.Cards;
using Account.Domain.Entities.Users;
using Account.Infrastructure.Context;

namespace Account.Application.Tests.Utils.UserCards
{
    public class CardUtil
    {
        private AccountContext _context;
        private long _userId;
        private UserCard _card = null;
        public CardUtil(long userId, AccountContext context)
        {
            _context = context;
            _userId = userId;
        }
        public UserCard InsertCard()
        {
            var card = new UserCard()
            {
                AccountNumber = "",
                BankName = "Test",
                CardNumber = "6037991987879976",
                IsActive = true,
                IsDelete = false,
                OwnerName = "Test",
                ShabaNumber = "1234567890123",
                UserId = _userId
            };
            _context.UserCards.Add(card);
            _context.SaveChanges();
            _card = card;
            return card;
        }

        public UserCard CreateNewObjectOfUserCard(InsertCardDto dto)
        {
            return new UserCard()
            {
                AccountNumber = dto.AccountNumber,
                BankName = dto.BankName,
                CardNumber = dto.CardNumber,
                IsActive = true,
                IsDelete = false,
                OwnerName = dto.OwnerName,
                ShabaNumber = dto.ShabaNumber,
                UserId = dto.UserId
            };
        }
        public void CleanCard(UserCard card)
        {
            _context.UserCards.Remove(card);
            _context.SaveChanges();
        }

    }
}