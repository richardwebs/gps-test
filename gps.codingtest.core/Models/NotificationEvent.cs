using System;
using System.ComponentModel.DataAnnotations;

namespace gps.codingtest.core
{
    public class NotificationEvent
    {
        public Guid Id { get; set; } = new Guid();

        [Required]
        public string To { get; set; }

        [Required]
        public string From { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public string NotificationType { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;
    }
}
