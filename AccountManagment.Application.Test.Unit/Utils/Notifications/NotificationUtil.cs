using System;
using Account.Application.Models.DTOs.Notifications;
using Account.Domain.Entities.Users;
using Account.Infrastructure.Context;

namespace Account.Application.Tests.Utils.Notifications
{
    public class NotificationUtil
    {
        private readonly AccountContext _context;
        private readonly long _userId;

        public NotificationUtil(AccountContext context, long userId)
        {
            _context = context;
            _userId = userId;
        }

        public UserNotification InsertNotification()
        {
            var notification=new UserNotification()
            {
                Body = "Test",
                IsSeen = false,
                UserId = _userId,
                Title = "Test"
            };
            _context.Add(notification);
            _context.SaveChanges();
            return notification;
        }
        public NotificationDto CreateNewObjectOfNotificationDto()
        {
            var notification = new NotificationDto()
            {
                Body = "Test",
                IsSeen = false,
                UserId = _userId,
                Title = "Test",
                CreateDate = DateTime.Now
            };
            return notification;
        }
        public void Clear(UserNotification notification)
        {
            _context.Remove(notification);
            _context.SaveChanges();
        }
    }
}