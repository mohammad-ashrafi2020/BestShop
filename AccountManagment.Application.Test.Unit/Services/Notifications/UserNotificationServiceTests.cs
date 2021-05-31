using System.Threading.Tasks;
using Account.Application.Services.Users.Notifications;
using Account.Application.Tests.Fixture;
using Account.Application.Tests.Utils.Notifications;
using framework;
using Xunit;

namespace Account.Application.Tests.Services.Notifications
{
    [Collection("DataBase Collection")]
    public class UserNotificationServiceTests
    {
        private UserNotificationService _notificationService;
        private NotificationUtil _util;

        public UserNotificationServiceTests(PublicFixture fixture)
        {
            _util = new NotificationUtil(fixture._context, fixture.UserId);
            _notificationService = new UserNotificationService(fixture._context);
        }
        [Fact(DisplayName = "InsertNotification")]
        public async Task Should_Insert_New_Notification()
        {
            //Arrange
            var notification = _util.CreateNewObjectOfNotificationDto();

            //Act
            var res = await _notificationService.InsertNotification(notification);

            //Asserts
            Assert.True(res.Status == ResultModelStatus.Success);
        }
    }
}