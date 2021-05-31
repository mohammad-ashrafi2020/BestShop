using System.Collections.Generic;
using framework;

namespace Account.Application.Models.DTOs.Notifications
{
    public class NotificationFilterDto:BasePaging
    {
        public List<NotificationDto> Notifications { get; set; }
        public long UserId { get; set; }
    }
}