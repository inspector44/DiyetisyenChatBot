namespace DiyetisyenimBot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BotHistoryEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
               "dbo.BotHistoryEntity",
               c => new
               {
                   ID = c.Int(nullable: false, identity: true),
                   Message = c.String(),
                   Source = c.String(),
                   UserId = c.String(),
                   CreateDate = c.DateTime(defaultValue: DateTime.Now)

               })
               .PrimaryKey(t => t.ID);
        }
        
        public override void Down()
        {
        }
    }
}
