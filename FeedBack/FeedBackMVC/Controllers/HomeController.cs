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
    }
}
