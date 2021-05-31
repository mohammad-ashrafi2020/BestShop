using System;
using System.Linq;
using System.Threading.Tasks;
using Account.Application.Models.DTOs.Notifications;
using Account.Domain.Entities.Users;
using Account.Infrastructure.Context;
using AutoMapper;
using framework;
using framework.Services;
using Microsoft.EntityFrameworkCore;

namespace Account.Application.Services.Users.Notifications
{
    public class UserNotificationService : BaseService, IUserNotificationService
    {

        public UserNotificationService(AccountContext context) : base(context)
        {

        }


        public async Task<ResultModel> InsertNotification(NotificationDto model)
        {
            var notification = new UserNotification()
            {
                IsSeen = false,
                CreationDate = DateTime.Now,
                Title = model.Title,
                Body = model.Body,
                UserId = model.UserId
            };
            Insert(notification);
            await Save();
            return ResultModel.Success();
        }

        public async Task<ResultModel<NotificationFilterDto>> GetUserNotifications(int pageId, int take, long userId)
        {
            var result = Table<UserNotification>()
                .OrderByDescending(s => s.CreationDate)
                .Where(n => n.UserId == userId)
                .Select(s => new NotificationDto()
                {
                    Body = s.Body,
                    IsSeen = s.IsSeen,
                    Title = s.Title,
                    UserId = s.UserId
                });
            var skip = (pageId - 1) * take;
            var model = new NotificationFilterDto()
            {
                Notifications = await result.Skip(skip).Take(take).ToListAsync(),
                UserId = userId
            };
            model.GeneratePaging(result, take, pageId);
            return ResultModel<NotificationFilterDto>.Success(model);
        }

        public async Task<ResultModel> SeenNotification(long id)
        {
            var notification = await GetById<UserNotification>(id);
            if (notification == null)
                return ResultModel.Error();

            notification.IsSeen = true;
            Update(notification);
            await Save();
            return ResultModel.Success();
        }

        public async Task<ResultModel> DeleteNotification(long id, long userId)
        {
            var notification = await GetById<UserNotification>(id);
            if (notification == null)
                return ResultModel.Error();

            if (notification.UserId != userId)
                return ResultModel.Error();

            Delete(notification);
            await Save();
            return ResultModel.Success();
        }

        public async Task<ResultModel> DeleteNotification(long id)
        {
            var notification = await GetById<UserNotification>(id);
            if (notification == null)
                return ResultModel.Error();

            Delete(notification);
            await Save();
            return ResultModel.Success();
        }

        public async Task<ResultModel> DeleteUserNotifications(long userId)
        {
            var notifications = Table<UserNotification>().Where(n => n.UserId == userId);
            if (!notifications.Any())
                return ResultModel.Success();

            Delete(notifications);
            await Save();
            return ResultModel.Success();
        }
    }
}