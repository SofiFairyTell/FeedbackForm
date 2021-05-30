using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedBackMVC.Models
{
    public class Message
    {
        public int User_id { get; set; } // foreigh key
        public int  Message_id { get; set; }
        public string Message_theme { get; set; }

        public string Message_text { get; set; }

    }
}
