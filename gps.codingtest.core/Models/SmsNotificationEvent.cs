﻿using System.ComponentModel.DataAnnotations;

namespace gps.codingtest.core.Models
{
    public class SmsNotificationEvent : AbstractNotificationEvent
    { 
        [Required]
        public string To { get; set; }

        [Required]
        public string From { get; set; }        

        [Required]
        public string Message { get; set; }            
    }
}
