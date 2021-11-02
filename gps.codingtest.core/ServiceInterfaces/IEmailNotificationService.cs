
using gps.codingtest.core.Models;

namespace gps.codingtest.core.ServiceInterfaces
{
    public interface IEmailNotificationService
    {
        bool Send(EmailNotificationEvent notificationEvent, out string error);
    }
}
