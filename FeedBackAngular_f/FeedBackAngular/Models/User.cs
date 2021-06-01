using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedBackAngular.Models
{
    //Таблица пользователей
    public class User
    {
        public int Id { private set; get; }
        public string User_name { get; set; }
        public string User_mail { get; set; }
        public string User_phone { get; set; }
    }
}
