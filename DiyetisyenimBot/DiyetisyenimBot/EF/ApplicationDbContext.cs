using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DiyetisyenimBot.EF
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("defaultconnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Models.BotHistoryEntity> BotHistoryEntities { get; set; }
        public DbSet<Models.Answers> Answers { get; set; }
        public DbSet<Models.Questions> Questions { get; set; }
        public DbSet<Models.Users> Users { get; set; }
    }
}