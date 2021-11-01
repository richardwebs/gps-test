using System.Collections.Generic;
using System.Text;

namespace gps.codingtest.core.Models
{
    public interface INotificationMessage
    {
        bool send(NotificationEvent notificationEvent, out string error);
    }
}
