using System.Threading.Tasks;
using Account.Application.Models.DTOs.Notifications;
using framework;

namespace Account.Application.Services.Users.Notifications
{
    public interface IUserNotificationService
    {
        Task<ResultModel> InsertNotification(NotificationDto model);
        Task<ResultModel<NotificationFilterDto>> GetUserNotifications(int pageId,int take,long userId);
        Task<ResultModel> SeenNotification(long id);
        Task<ResultModel> DeleteNotification(long id, long userId);
        Task<ResultModel> DeleteNotification(long id);
        Task<ResultModel> DeleteUserNotifications(long userId);
    }
}