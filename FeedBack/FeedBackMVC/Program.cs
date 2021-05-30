using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

using System;

using FeedBackMVC.Models;

namespace FeedBackMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var skope = host.Services.CreateScope())
            {
                var services = skope.ServiceProvider;
                try
                {
                    //Выполним соединение с бд, а затем запишем в нее данные первых пользователей
                    var context = services.GetRequiredService<MessageStoreContext>();
                    _Data.FirstUsers.Initialize(context);
                }
                catch (Exception ex)
                {
                    //Выведем лог ошибки 
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "Ошибка при добавлении в БД");
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
