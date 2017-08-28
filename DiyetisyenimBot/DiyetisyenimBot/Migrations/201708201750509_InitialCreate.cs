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
                        CocukVar = c.Int(nullable: false),
                        KacCocuk = c.Int(nullable: false),
                        KendiDiyetYapti = c.Int(nullable: false),
                        DiyetisGitti = c.Int(nullable: false),
                        KiloAldiVerdi = c.Int(nullable: false),
                        AzKaloriDiyetYapti = c.Int(nullable: false),
                        AlerjiVar = c.Int(nullable: false),
                        NeyeAlerji = c.String(),
                        YeterliSuTuketiyor = c.Int(nullable: false),
                        KacBardakSu = c.Int(nullable: false),
                        CayTuketiyor = c.Int(nullable: false),
                        KahveTuketiyor = c.Int(nullable: false),
                        KacBardakCay = c.Int(nullable: false),
                        KacBardakKahve = c.Int(nullable: false),
                        OgunSaatleriDuzenli = c.Int(nullable: false),
                        CayKahveSekerAtar = c.Int(nullable: false),
                        DuzenliEgzersizYapar = c.Int(nullable: false),
                        SigaraKullanir = c.Int(nullable: false),
                        AlkolKullanir = c.Int(nullable: false),
                        YersemKiloAlirim = c.Int(nullable: false),
                        Vegan = c.Int(nullable: false),
                        HastaligimVar = c.Int(nullable: false),
                        Hastalik = c.String(),
                        IlacTedaviGoruyor = c.Int(nullable: false),
                        IlacAdi = c.String(),
                        SporGecmisiVar = c.Int(nullable: false),
                        SporAdi = c.String(),
                        HamileMi = c.Int(nullable: false),
                        KacinciHafta = c.Int(nullable: false),
                        EmziriyorMu = c.Int(nullable: false),
                        CalismaSistemi = c.Int(nullable: false),
                        CalismaSaatleri = c.Int(nullable: false),
                        UykuProblemiVar = c.Int(nullable: false),
                        AtistirmaIstegiVar = c.Int(nullable: false),
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
                        Yas = c.Int(nullable: false),
                        Kilo = c.Double(nullable: false),
                        Cinsiyet = c.Int(nullable: false),
                        MedeniDurum = c.Int(nullable: false),
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
