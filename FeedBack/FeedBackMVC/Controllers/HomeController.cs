using FeedBackMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FeedBackMVC.Controllers
{
    public class HomeController : Controller
    {
        Models.MessageStoreContext dataContext;
        public HomeController(MessageStoreContext context)
        {
            //конструктор для получения данных
            dataContext = context;
        }
        public IActionResult Index()
        {
            //генерация представления: получаем все объекты из БД в виде списка
            return View(dataContext.Users.ToList());
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
            var data =  dataContext.Messages.Add(message);
            dataContext.SaveChanges();
            return "Ваше сообщение"+ message.User.User_name +"отправлено";
        }
    }
}
