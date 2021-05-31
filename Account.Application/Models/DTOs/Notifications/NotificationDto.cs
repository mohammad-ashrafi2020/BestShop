using System;

namespace Account.Application.Models.DTOs.Notifications
{
    public class NotificationDto
    {
        public long UserId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public bool IsSeen { get; set; }
        public DateTime CreateDate { get; set; }
    }
}