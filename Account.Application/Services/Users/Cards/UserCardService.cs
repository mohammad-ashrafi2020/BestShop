using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Account.Application.Models.DTOs.Cards;
using Account.Domain.Entities.Users;
using Account.Infrastructure.Context;
using AutoMapper;
using framework;
using framework.Services;
using Microsoft.EntityFrameworkCore;

namespace Account.Application.Services.Users.Cards
{
    public class UserCardService : BaseService, IUserCardService
    {
        private readonly IMapper _mapper;

        public UserCardService(AccountContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }


        public async Task<ResultModel<UserCard>> GetUserCardBy(long cardId)
        {
            var card = await GetById<UserCard>(cardId, "User");
            if (card == null)
                return ResultModel<UserCard>.NotFound();

            return ResultModel<UserCard>.Success(card);
        }

        public async Task<ResultModel<List<UserCard>>> GetUserCards(long userId)
        {
            var cards = await Table<UserCard>()
                .Where(c => c.UserId == userId && c.IsDelete).ToListAsync();

            return ResultModel<List<UserCard>>.Success(cards);
        }

        public async Task<ResultModel> InsertCard(InsertCardDto model)
        {
            var card = _mapper.Map<UserCard>(model);
            card.IsDelete = false;
            card.IsActive = false;
            Insert(card);
            await Save();
            return ResultModel.Success();
        }

        public async Task<ResultModel> EditCard(EditCardDto model)
        {
            var mainCard = await GetUserCardBy(model.Id);

            if (mainCard.Status != ResultModelStatus.Success)
                return ResultModel.NotFound();

            if (mainCard.Data.UserId != model.UserId)
                return ResultModel.Error();

            var card = mainCard.Data;
            card.ShabaNumber = model.ShabaNumber;
            card.AccountNumber = model.CardNumber;
            card.BankName = model.BankName;
            card.OwnerName = model.OwnerName;
            card.CardNumber = model.CardNumber;
            card.IsActive = false;
            Update(card);
            await Save();
            return ResultModel.Success();
        }

        public async Task<ResultModel> DeleteCardByAdmin(long cardId, long deletedBy)
        {
            var mainCard = await GetUserCardBy(cardId);

            if (mainCard.Status != ResultModelStatus.Success)
                return ResultModel.NotFound();

            mainCard.Data.IsDelete = true;
            mainCard.Data.DeletedAt = DateTime.Now;
            mainCard.Data.DeletedBy = deletedBy;
            Update(mainCard.Data);
            await Save();
            return ResultModel.Success();
        }

        public async Task<ResultModel> DeleteCard(long cardId, long userId)
        {
            var mainCard = await GetUserCardBy(cardId);

            if (mainCard.Status != ResultModelStatus.Success)
                return ResultModel.NotFound();

            if (mainCard.Data.UserId != userId)
                return ResultModel.Error();

            mainCard.Data.IsDelete = true;
            mainCard.Data.DeletedAt = DateTime.Now;
            mainCard.Data.DeletedBy = userId;
            Update(mainCard.Data);
            await Save();
            return ResultModel.Success();
        }
    }
}