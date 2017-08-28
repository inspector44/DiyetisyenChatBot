namespace DiyetisyenimBot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Questions : DbMigration
    {
        public override void Up()
        {

            CreateTable(
               "dbo.Questions",
               c => new
               {
                   Id = c.Int(nullable: false, identity: true),
                   Question = c.String(),
                   CreateDate = c.DateTime(nullable: true, defaultValue: DateTime.Now),
               })
               .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
        }
    }
}
