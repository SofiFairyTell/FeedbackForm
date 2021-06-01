using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FeedBackAngular.Models
{
    public class MessageStoreContext : DbContext
    {
        //Контекст чтобы таблицы в БД были созданы автоматически в случае их отсутствия
        //И для подключения к БД
        public DbSet<User> Users{get;set;}
        public DbSet<Message> Messages{get;set;}
        public DbSet<Theme> Themes { get; set; }

        public MessageStoreContext(DbContextOptions<MessageStoreContext> dbContextOptions):base(dbContextOptions)
        {
            Database.EnsureCreated();
        }

    }
}
