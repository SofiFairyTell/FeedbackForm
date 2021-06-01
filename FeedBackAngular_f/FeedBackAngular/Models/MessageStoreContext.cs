using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FeedBackAngular.Models
{
    public class MessageStoreContext : DbContext
    {
        //Чтобы таблицы в БД были созданы автоматически в случае их отсутствия
        public DbSet<User> Users{get;set;}
        public DbSet<Message> Messages{get;set;}

        public MessageStoreContext(DbContextOptions<MessageStoreContext> dbContextOptions):base(dbContextOptions)
        {
            Database.EnsureCreated();
        }

    }
}
