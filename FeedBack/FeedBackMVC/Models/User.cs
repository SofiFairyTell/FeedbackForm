using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedBackMVC.Models
{
    public class User
    {
        public int Id { get; set; }
        public string User_name { get; set; }
        public string User_mail { get; set; }
        public string User_phone { get; set; }
    }
}
