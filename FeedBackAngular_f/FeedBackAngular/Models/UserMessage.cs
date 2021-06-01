using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedBackAngular.Models
{
    public class UserMessage
    {
            public int UserMessageId { get; set; }
            public string UserMessage_Name { get; set; }
            public string UserMessage_Email { get; set; }
            public string UserMessage_Phone { get; set; }
            public string UserMessage_Theme { get; set; }
            public string UserMessage_Message { get; set; }
    }
}
