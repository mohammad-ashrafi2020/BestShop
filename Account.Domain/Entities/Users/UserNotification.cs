using System;
using _DomainUtils.Domain;

namespace Account.Domain.Entities.Users
{
    public class UserNotification:BaseEntity
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public bool IsSeen { get; set; }


        #region Relations
        public User User { get; set; }
        #endregion
    }
}