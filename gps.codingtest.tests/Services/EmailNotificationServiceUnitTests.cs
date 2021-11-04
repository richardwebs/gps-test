using gps.codingtest.core.ServiceInterfaces;
using gps.codingtest.core.Services;
using Xunit;
using Moq;
using gps.codingtest.core.Models;
using System.Linq;
using System;

namespace gps.codingtest.tests.Services
{
    [CollectionDefinition("")]
    public class EmailNotificationServiceUnitTests
    {
        private readonly IEmailNotificationService _emailNotificationService;
        private readonly Mock<IEmailService> _emailService;

        public EmailNotificationServiceUnitTests()
        {
            _emailService = new Mock<IEmailService>();
            _emailNotificationService = new EmailNotificationService(_emailService.Object);
        }

        [Fact]
        public void Send_Success()
        {
            _emailService.Setup(x => x.IsServiceRunning()).Returns(true);
            // setup
            var input = new EmailNotificationEvent();
            _emailService.Setup(x => x.Send(input.To, input.From, input.Subject, input.Message)).Returns(true);

            // execute
            var result = _emailNotificationService.Send(input, out string errorMsg);

            // verify
            _emailService.Verify(x => x.IsServiceRunning(), Times.Once);
            _emailService.Verify(x => x.Send(input.To, input.From, input.Subject, input.Message), Times.Once);

            // assert
            Assert.True(result);
            Assert.NotNull(errorMsg);
            Assert.Equal(string.Empty, errorMsg);
        }

        [Fact]
        public void Send_Failure_IsNotRunning()
        {
            _emailService.Setup(x => x.IsServiceRunning()).Returns(false);
            // setup
            var input = new EmailNotificationEvent();
            _emailService.Setup(x => x.Send(input.To, input.From, input.Subject, input.Message)).Returns(true);

            // execute
            var result = _emailNotificationService.Send(input, out string errorMsg);

            // verify
            _emailService.Verify(x => x.IsServiceRunning(), Times.Once);
            _emailService.Verify(x => x.Send(input.To, input.From, input.Subject, input.Message), Times.Never);

            // assert
            Assert.False(result);
            Assert.NotNull(errorMsg);
            Assert.True(errorMsg.Any());
        }

        [Fact]
        public void Send_Failure_SendThrowsError()
        {
            _emailService.Setup(x => x.IsServiceRunning()).Returns(true);
            // setup
            var input = new EmailNotificationEvent();
            var sendError = new Exception();
            _emailService.Setup(x => x.Send(input.To, input.From, input.Subject, input.Message)).Throws(sendError);

            // execute
            var result = _emailNotificationService.Send(input, out string errorMsg);

            // verify
            _emailService.Verify(x => x.IsServiceRunning(), Times.Once);
            _emailService.Verify(x => x.Send(input.To, input.From, input.Subject, input.Message), Times.Once);

            // assert
            Assert.False(result);
            Assert.NotNull(errorMsg);
            Assert.Equal(sendError.Message, errorMsg);
        }
    }
}
