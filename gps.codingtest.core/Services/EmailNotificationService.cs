using gps.codingtest.core.Models;
using gps.codingtest.core.ServiceInterfaces;
using System;

namespace gps.codingtest.core.Services
{
    public class EmailNotificationService : IEmailNotificationService
    {
        private readonly IEmailService _emailService;

        public EmailNotificationService(IEmailService emailService)
        {
            _emailService = emailService;
        }
        
        public bool Send(EmailNotificationEvent notificationEvent, out string error)
        {
            bool result = false;
            error = string.Empty;

            try
            {
                if (!_emailService.IsServiceRunning())
                {
                    error = "Service is currently not running";
                    return false;
                }

                result = _emailService.Send(notificationEvent.To, notificationEvent.From, notificationEvent.Subject, notificationEvent.Message);
            }
            catch (Exception e)
            {
                error = e.Message;
            }

            return result;
        }
    }
}