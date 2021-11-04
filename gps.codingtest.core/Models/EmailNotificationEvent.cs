using System.ComponentModel.DataAnnotations;

namespace gps.codingtest.core.Models
{
    public class EmailNotificationEvent : AbstractNotificationEvent
    {
        [Required(ErrorMessage = "Please fill in the to-field")]
        public string To { get; set; }

        [Required(ErrorMessage = "Please fill in the from-field")]
        public string From { get; set; }

        [Required(ErrorMessage = "Please fill in the subject-field")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Please fill in the message-field")]
        public string Message { get; set; }        
    }
}
