using gps.codingtest.core.Models;
using gps.codingtest.core.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace gps.codingtest.api.Controllers
{
    public interface INotificationController
    {
        IActionResult SendEmailNotification(EmailNotificationEvent notificationEvent);
        IActionResult SendSmsNotification(SmsNotificationEvent notificationEvent);
    }
    
    [Route("[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase, INotificationController
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
        public IActionResult SendEmailNotification( EmailNotificationEvent notificationEvent)
        {            
            var result = _emailNotificationService.Send(notificationEvent, out var errormessage);

            if (!result)
            {
                return BadRequest(errormessage);
            }

            return Ok("Message Sent");            
        }

        [HttpPost]
        [Route("sendSmsNotification")]
        public IActionResult SendSmsNotification(SmsNotificationEvent notificationEvent)
        {
            var result = _smsNotificationService.Send(notificationEvent, out var errormessage);

            if (!result)
            {
                return BadRequest(errormessage);
            }

            return Ok("Message Sent");            
        }               
    }
}
