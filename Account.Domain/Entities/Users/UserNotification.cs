using framework.Domain;

namespace Account.Domain.Entities.Users
{
    public class UserNotification:BaseEntity
    {
        public long UserId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public bool IsSeen { get; set; }


        #region Relations
        public User User { get; set; }
        #endregion
    }
}