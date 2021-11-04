using gps.codingtest.core.ServiceInterfaces;
using gps.codingtest.core.Services;
using Xunit;

namespace gps.codingtest.tests.Services
{
    [CollectionDefinition("")]
    public class EmailServiceIntegrationTests
    {
        private readonly IEmailService _service;

        public EmailServiceIntegrationTests()
        {
            _service = new EmailService();
        }

        [Fact]
        public void Send_Success()
        {
            // execute
            var result = _service.Send("to", "from", "subject", "message");

            // assert
            Assert.True(result);
        }

        [Fact]
        public void IsServiceRunning_Success()
        {
            // execute
            var result = _service.IsServiceRunning();

            // assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Send_Failure_NullOrEmptyTo(string input)
        {
            // execute
            var result = Assert.Throws<FailureToSendException>(() =>  _service.Send(input, "from", "subject", "message"));

            // assert
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Send_Failure_NullOrEmptyFrom(string input)
        {
            // execute
            var result = Assert.Throws<FailureToSendException>(() => _service.Send("to", input, "subject", "message"));

            // assert
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Send_Failure_NullOrEmptySubject(string input)
        {
            // execute
            var result = Assert.Throws<FailureToSendException>(() => _service.Send("to", "from", input, "message"));

            // assert
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Send_Failure_NullOrEmptyMessage(string input)
        {
            // execute
            var result = Assert.Throws<FailureToSendException>(() => _service.Send("to", "from", "subject", input));

            // assert
            Assert.NotNull(result);
        }

    }
}
