namespace DiyetisyenimBot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Users : DbMigration
    {
        public override void Up()
        {
            CreateTable(
               "dbo.Users",
               c => new
               {
                   ID = c.Long(nullable: false, identity: true),
                   Ad = c.String(),
                   Soyad = c.String(),
                   Yas = c.Double(),
                   Kilo = c.Double(),
                   Cinsiyet = c.Boolean(),
                   MedeniDurum = c.Boolean(),

               })
               .PrimaryKey(t => t.ID);
        }
        
        public override void Down()
        {
        }
    }
}
