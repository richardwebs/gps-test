using gps.codingtest.core.ServiceInterfaces;
using gps.codingtest.core.Services;
using Xunit;

namespace gps.codingtest.tests.Services
{
    [CollectionDefinition("")]
    public class SmsServiceIntegrationTests
    {
        private readonly ISmsService _service;

        public SmsServiceIntegrationTests()
        {
            _service = new SmsService();
        }

        [Fact]
        public void Send_Success()
        {
            // exexute
            var result = _service.Send("to", "from", "message");

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
            var result = Assert.Throws<FailureToSendException>(() => _service.Send(input, "from", "message"));

            // assert
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Send_Failure_NullOrEmptyFrom(string input)
        {
            // execute
            var result = Assert.Throws<FailureToSendException>(() => _service.Send("to", input, "message"));

            // assert
            Assert.NotNull(result);
        }        

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Send_Failure_NullOrEmptyMessage(string input)
        {
            // execute
            var result = Assert.Throws<FailureToSendException>(() => _service.Send("to", "from", input));

            // assert
            Assert.NotNull(result);
        }

    }
}
