using System.Collections.Generic;
using System.Text;

namespace gps.codingtest.core.Models
{
    public interface INotificationMessage
    {
        bool Send(NotificationEvent notificationEvent, out string error);
    }
}
