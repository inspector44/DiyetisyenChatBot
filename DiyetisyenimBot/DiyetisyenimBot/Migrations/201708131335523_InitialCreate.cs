namespace DiyetisyenimBot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CocukVar = c.Boolean(nullable: false),
                        KacCocuk = c.Int(nullable: false),
                        KendiDiyetYapti = c.Boolean(nullable: false),
                        DiyetisGitti = c.Boolean(nullable: false),
                        KiloAldiVerdi = c.Boolean(nullable: false),
                        AzKaloriDiyetYapti = c.Boolean(nullable: false),
                        AlerjiVar = c.Boolean(nullable: false),
                        NeyeAlerji = c.String(),
                        YeterliSuTuketiyor = c.Boolean(nullable: false),
                        KacBardakSu = c.Int(nullable: false),
                        CayTuketiyor = c.Boolean(nullable: false),
                        KahveTuketiyor = c.Boolean(nullable: false),
                        KacBardakCay = c.Int(nullable: false),
                        KacBardakKahve = c.Int(nullable: false),
                        OgunSaatleriDuzenli = c.Boolean(nullable: false),
                        CayKahveSekerAtar = c.Boolean(nullable: false),
                        DuzenliEgzersizYapar = c.Boolean(nullable: false),
                        SigaraKullanir = c.Boolean(nullable: false),
                        AlkolKullanir = c.Boolean(nullable: false),
                        YersemKiloAlirim = c.Boolean(nullable: false),
                        Vegan = c.Boolean(nullable: false),
                        HastaligimVar = c.Boolean(nullable: false),
                        Hastalik = c.String(),
                        IlacTedaviGoruyor = c.Boolean(nullable: false),
                        IlacAdi = c.String(),
                        SporGecmisiVar = c.Boolean(nullable: false),
                        SporAdi = c.String(),
                        HamileMi = c.Boolean(nullable: false),
                        KacinciHafta = c.Int(nullable: false),
                        EmziriyorMu = c.Boolean(nullable: false),
                        CalismaSistemi = c.String(),
                        CalismaSaatleri = c.String(),
                        UykuProblemiVar = c.Boolean(nullable: false),
                        AtistirmaIstegiVar = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BotHistoryEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        Source = c.String(),
                        UserId = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Question = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Ad = c.String(),
                        Soyad = c.String(),
                        Yas = c.Double(nullable: false),
                        Kilo = c.Double(nullable: false),
                        Cinsiyet = c.Boolean(nullable: false),
                        MedeniDurum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Questions");
            DropTable("dbo.BotHistoryEntities");
            DropTable("dbo.Answers");
        }
    }
}
