using gps.codingtest.core.Models;

namespace gps.codingtest.core.ServiceInterfaces
{
    public interface ISmsNotificationService
    {
        bool Send(SmsNotificationEvent notificationEvent, out string error);
    }
}
