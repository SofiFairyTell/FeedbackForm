using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedBackAngular.Models
{
    public class Message
    {    
        public int MessageId { get; set; }
        public string ThemeName { get; set; }
        public int ThemeId { get; set; }
        public string Message_text { get; set; }
        public int UserId { get; set; } // foreigh key

    }
}
