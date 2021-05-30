using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedBackMVC._Data
{
    public class FirstUsers
    {
        public static void Initialize(Models.MessageStoreContext context)
        {
            if(!context.Users.Any())
            {
                context.Users.AddRange(
                    new Models.User
                    {
                        User_name = "Serega",
                        User_mail = "razoom@mail.ru",
                        User_phone = "8 000 000 00 01"
                    },
                    new Models.User
                    {
                        User_name = "Oleg",
                        User_mail = "volkov@mail.ru",
                        User_phone = "8 000 000 00 02"
                    },
                    new Models.User
                    {
                        User_name = "Igor",
                        User_mail = "grom@mail.ru",
                        User_phone = "8 000 000 00 03"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
