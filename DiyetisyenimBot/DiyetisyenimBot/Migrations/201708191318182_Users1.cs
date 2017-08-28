namespace DiyetisyenimBot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Users1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Answers", "CocukVar", c => c.String());
            AlterColumn("dbo.Answers", "KacCocuk", c => c.String());
            AlterColumn("dbo.Answers", "KendiDiyetYapti", c => c.String());
            AlterColumn("dbo.Answers", "DiyetisGitti", c => c.String());
            AlterColumn("dbo.Answers", "KiloAldiVerdi", c => c.String());
            AlterColumn("dbo.Answers", "AzKaloriDiyetYapti", c => c.String());
            AlterColumn("dbo.Answers", "AlerjiVar", c => c.String());
            AlterColumn("dbo.Answers", "YeterliSuTuketiyor", c => c.String());
            AlterColumn("dbo.Answers", "KacBardakSu", c => c.String());
            AlterColumn("dbo.Answers", "CayTuketiyor", c => c.String());
            AlterColumn("dbo.Answers", "KahveTuketiyor", c => c.String());
            AlterColumn("dbo.Answers", "KacBardakCay", c => c.String());
            AlterColumn("dbo.Answers", "KacBardakKahve", c => c.String());
            AlterColumn("dbo.Answers", "OgunSaatleriDuzenli", c => c.String());
            AlterColumn("dbo.Answers", "CayKahveSekerAtar", c => c.String());
            AlterColumn("dbo.Answers", "DuzenliEgzersizYapar", c => c.String());
            AlterColumn("dbo.Answers", "SigaraKullanir", c => c.String());
            AlterColumn("dbo.Answers", "AlkolKullanir", c => c.String());
            AlterColumn("dbo.Answers", "YersemKiloAlirim", c => c.String());
            AlterColumn("dbo.Answers", "Vegan", c => c.String());
            AlterColumn("dbo.Answers", "HastaligimVar", c => c.String());
            AlterColumn("dbo.Answers", "IlacTedaviGoruyor", c => c.String());
            AlterColumn("dbo.Answers", "SporGecmisiVar", c => c.String());
            AlterColumn("dbo.Answers", "HamileMi", c => c.String());
            AlterColumn("dbo.Answers", "KacinciHafta", c => c.String());
            AlterColumn("dbo.Answers", "EmziriyorMu", c => c.String());
            AlterColumn("dbo.Answers", "UykuProblemiVar", c => c.String());
            AlterColumn("dbo.Answers", "AtistirmaIstegiVar", c => c.String());
            AlterColumn("dbo.Users", "Yas", c => c.String());
            AlterColumn("dbo.Users", "Kilo", c => c.String());
            AlterColumn("dbo.Users", "Cinsiyet", c => c.String());
            AlterColumn("dbo.Users", "MedeniDurum", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "MedeniDurum", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Users", "Cinsiyet", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Users", "Kilo", c => c.Double(nullable: false));
            AlterColumn("dbo.Users", "Yas", c => c.Double(nullable: false));
            AlterColumn("dbo.Answers", "AtistirmaIstegiVar", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Answers", "UykuProblemiVar", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Answers", "EmziriyorMu", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Answers", "KacinciHafta", c => c.Int(nullable: false));
            AlterColumn("dbo.Answers", "HamileMi", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Answers", "SporGecmisiVar", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Answers", "IlacTedaviGoruyor", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Answers", "HastaligimVar", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Answers", "Vegan", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Answers", "YersemKiloAlirim", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Answers", "AlkolKullanir", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Answers", "SigaraKullanir", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Answers", "DuzenliEgzersizYapar", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Answers", "CayKahveSekerAtar", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Answers", "OgunSaatleriDuzenli", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Answers", "KacBardakKahve", c => c.Int(nullable: false));
            AlterColumn("dbo.Answers", "KacBardakCay", c => c.Int(nullable: false));
            AlterColumn("dbo.Answers", "KahveTuketiyor", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Answers", "CayTuketiyor", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Answers", "KacBardakSu", c => c.Int(nullable: false));
            AlterColumn("dbo.Answers", "YeterliSuTuketiyor", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Answers", "AlerjiVar", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Answers", "AzKaloriDiyetYapti", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Answers", "KiloAldiVerdi", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Answers", "DiyetisGitti", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Answers", "KendiDiyetYapti", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Answers", "KacCocuk", c => c.Int(nullable: false));
            AlterColumn("dbo.Answers", "CocukVar", c => c.Boolean(nullable: false));
        }
    }
}
