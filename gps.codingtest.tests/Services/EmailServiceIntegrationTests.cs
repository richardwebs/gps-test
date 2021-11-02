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
            var result = _service.Send("to", "from", "subject", "message");
            Assert.True(result);
        }

        [Fact]
        public void IsServiceRunning_Success()
        {
            var result = _service.IsServiceRunning();
            Assert.True(result);
        }

    }
}
