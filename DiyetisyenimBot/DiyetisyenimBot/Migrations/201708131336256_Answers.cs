namespace DiyetisyenimBot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Answers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
               "dbo.Answers",
               c => new
               {
                   Id = c.Int(nullable: false, identity: true),
                   CocukVar = c.Boolean(),
                   KacCocuk = c.Int(),
                   KendiDiyetYapti = c.Boolean(),
                   DiyetisGitti = c.Boolean(),
                   KiloAldiVerdi = c.Boolean(),
                   AzKaloriDiyetYapti = c.Boolean(),
                   AlerjiVar = c.Boolean(),
                   NeyeAlerji = c.String(),
                   YeterliSuTuketiyor = c.Boolean(),
                   KacBardakSu = c.Int(),
                   CayTuketiyor = c.Boolean(),
                   KahveTuketiyor = c.Boolean(),
                   KacBardakCay = c.Int(),
                   KacBardakKahve = c.Int(),
                   OgunSaatleriDuzenli = c.Boolean(),
                   CayKahveSekerAtar = c.Boolean(),
                   DuzenliEgzersizYapar = c.Boolean(),
                   SigaraKullanir = c.Boolean(),
                   AlkolKullanir = c.Boolean(),
                   YersemKiloAlirim = c.Boolean(),
                   Vegan = c.Boolean(),
                   HastaligimVar = c.Boolean(),
                   Hastalik = c.String(),
                   IlacTedaviGoruyor = c.Boolean(),
                   IlacAdi = c.String(),
                   SporGecmisiVar = c.Boolean(),
                   SporAdi = c.String(),
                   HamileMi = c.Boolean(),
                   KacinciHafta = c.Int(),
                   EmziriyorMu = c.Boolean(),
                   CalismaSistemi = c.String(),
                   CalismaSaatleri = c.String(),
                   UykuProblemiVar = c.Boolean(),
                   AtistirmaIstegiVar = c.Boolean(),
               })
               .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
        }
    }
}
