using gps.codingtest.core.Models;
using gps.codingtest.core.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace gps.codingtest.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IEmailNotificationService _emailNotificationService;
        private readonly ISmsNotificationService _smsNotificationService;        

        public NotificationController(IEmailNotificationService emailNotificationService, ISmsNotificationService smsNotificationService)
        {
            _emailNotificationService = emailNotificationService;
            _smsNotificationService = smsNotificationService;
        }

        [HttpPost]
        [Route("sendEmailNotification")]
        public async Task<IActionResult> SendEmailNotification([FromBody] EmailNotificationEvent notificationEvent)
        {
            return await Task.Run(() => {
                var result = _emailNotificationService.Send(notificationEvent, out var errormessage);

                if (!result)
                {
                    BadRequest(errormessage);
                }

                return Ok("Message Sent");
            });
        }

        [HttpPost]
        [Route("sendSmsNotification")]
        public async Task<IActionResult> SendSmsNotification([FromBody] SmsNotificationEvent notificationEvent)
        {
            return await Task.Run(() => {

                var result = _smsNotificationService.Send(notificationEvent, out var errormessage);

                if (!result)
                {
                    BadRequest(errormessage);
                }

                return Ok("Message Sent");
            });
        }               
    }
}
