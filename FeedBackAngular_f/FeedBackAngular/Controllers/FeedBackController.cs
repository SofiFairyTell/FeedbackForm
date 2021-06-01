using FeedBackAngular.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FeedBackAngular.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FeedBackController : Controller
    {
        private readonly Models.MessageStoreContext _context;
        public FeedBackController(MessageStoreContext context)
        {
            //конструктор для получения данных
            _context = context;
        }
       

        //Найти сообщения по id пользователя
        [HttpGet]
        public IActionResult SendMessage(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            ViewBag.UserId = id;
            return View();
        }

        [HttpPost]
        public string Send(Message message, User user)
        {
            //user.Id = 4;
            // dataContext.Users.Add(user);
            //Message mess = new Message();
            //mess.UserId = user.Id;
            //mess.Message_text = message.Message_text;
            //mess.Message_theme = message.Message_theme;
            //mess.User = user;
            //if(message.User == null)
            //{
            //    message.User = user;
            //}
            var data =  _context.Messages.Add(message);
            _context.SaveChanges();
            return "Ваше сообщение"+user.User_name+"отправлено";
        }
        [HttpPost]
        public async Task<ActionResult<UserMessage>> PostUserData(UserMessage userData)
        {
            var founded = _context.Users.FirstOrDefault(t => t.User_mail == userData.UserMessage_Email &&
                 t.User_phone == userData.UserMessage_Phone);

            var userId = 0;
            if (founded is null)
            {
                //Пользователь был найден
                var addedUser = new User()
                {
                    User_name = userData.UserMessage_Name,
                    User_mail = userData.UserMessage_Email,
                    User_phone = userData.UserMessage_Phone
                };
                _context.Users.Add(addedUser);
                await _context.SaveChangesAsync();
                userId = addedUser.Id;
            }
            else
                userId = founded.Id;

            var subject = _context.Themes.FirstOrDefault(t => t.ThemeName == userData.UserMessage_Theme);

            if (subject is null)
            {
                subject = new Theme() { ThemeName = userData.UserMessage_Theme };
                _context.Themes.Add(subject);
                await _context.SaveChangesAsync();
            }

            var message = new Message()
            {
                UserId = userId,
                ThemeId = subject.ThemeId,
                Message_text = userData.UserMessage_Message
            };
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            Console.WriteLine();


            return CreatedAtAction(nameof(PostUserData), new { id = userData.UserMessageId }, message);
        }
    }
}
