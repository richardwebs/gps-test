using gps.codingtest.core.ServiceInterfaces;
using gps.codingtest.core.Services;
using Xunit;
using Moq;
using gps.codingtest.core.Models;
using System.Linq;
using System;
using gps.codingtest.api.Controllers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace gps.codingtest.tests.Controllers
{
    [CollectionDefinition("")]
    public class NotificationControllerUnitTests
    {
        private readonly INotificationController _controller;
        private readonly Mock<IEmailNotificationService> _emailNotificationService;
        private readonly Mock<ISmsNotificationService> _smsNotificationService;

        public NotificationControllerUnitTests()
        {
            _emailNotificationService = new Mock<IEmailNotificationService>();
            _smsNotificationService = new Mock<ISmsNotificationService>();
            _controller = new NotificationController(_emailNotificationService.Object, _smsNotificationService.Object);
        }

        [Fact]
        public void SendEmailNotification_Success()
        {
            // setup
            var input = new EmailNotificationEvent();
            string errorMsg;
            _emailNotificationService.Setup(x => x.Send(input, out errorMsg)).Returns(true);
            
            //errorMsg = string.Empty;

            // execute
            var result = _controller.SendEmailNotification(input);

            // verify
            _emailNotificationService.Verify(x => x.Send(input, out errorMsg), Times.Once);

            // assert
            Assert.IsType<OkObjectResult>(result);
            // TODO find out how to test for out parameters
        }

        [Fact]
        public void SendEmailNotification_Failure()
        {
            // setup
            var input = new EmailNotificationEvent();
            string errorMsg;
            _emailNotificationService.Setup(x => x.Send(input, out errorMsg)).Returns(false);            

            // execute
            var result = _controller.SendEmailNotification(input);

            // verify
            _emailNotificationService.Verify(x => x.Send(input, out errorMsg), Times.Once);

            // assert
            Assert.IsType<BadRequestObjectResult>(result);
            // TODO find out how to test for out parameters
        }
    }
}
