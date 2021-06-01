using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedBackAngular.Models
{
    //Модель описывает структуру таблицы сообщений
    public class Message
    {    
        public int MessageId { get; set; }
        public int ThemeId { get; set; }    //идентификатор темы
        public string Message_text { get; set; }    //само сообщений
        public int UserId { get; set; } // foreigh key

    }
}
