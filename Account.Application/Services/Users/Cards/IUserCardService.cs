using System.Collections.Generic;
using System.Threading.Tasks;
using Account.Application.Models.DTOs.Cards;
using Account.Domain.Entities.Users;
using framework;

namespace Account.Application.Services.Users.Cards
{
    public interface IUserCardService
    {
        Task<ResultModel<UserCard>> GetUserCardBy(long cardId);
        Task<ResultModel<List<UserCard>>> GetUserCards(long userId);
        Task<ResultModel> InsertCard(InsertCardDto model);
        Task<ResultModel> EditCard(EditCardDto model);
        Task<ResultModel> DeleteCardByAdmin(long cardId,long deletedBy);
        Task<ResultModel> DeleteCard(long cardId,long userId);
    }
}