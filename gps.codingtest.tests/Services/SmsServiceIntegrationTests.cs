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
            var result = _service.Send("to", "from", "message");
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
