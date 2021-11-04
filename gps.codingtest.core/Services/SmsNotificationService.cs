using System;
using gps.codingtest.core.Models;
using gps.codingtest.core.ServiceInterfaces;

namespace gps.codingtest.core.Services
{
    public class SmsNotificationService : ISmsNotificationService
    {
        private readonly ISmsService _smsService;

        public SmsNotificationService(ISmsService smsService)
        {
            _smsService = smsService;
        }

        public bool Send(SmsNotificationEvent notificationEvent, out string error)
        {
            bool result = false;
            error = string.Empty;

            try
            {
                if (!_smsService.IsServiceRunning())
                {
                    error = "Service is currently not running";
                    return false;
                }

                result = _smsService.Send(notificationEvent.To, notificationEvent.From, notificationEvent.Message);
            }
            catch (Exception e)
            {
                error = e.Message;
            }

            return result;
        }        
    }
}