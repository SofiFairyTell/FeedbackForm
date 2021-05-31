using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedBackMVC.Models
{
    public class Message
    {    
        public int MessageId { get; set; }
        public string Message_theme { get; set; }
        public string Message_text { get; set; }
        public int UserId { get; set; } // foreigh key
        public User User { get; set; }

    }
}
