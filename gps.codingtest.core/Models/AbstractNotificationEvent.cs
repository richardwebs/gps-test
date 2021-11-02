using System;

namespace gps.codingtest.core.Models
{
    public abstract class AbstractNotificationEvent
    {
        public Guid Id { get; set; } = new Guid();

        public DateTime Created { get; set; } = DateTime.UtcNow;
    }
}
