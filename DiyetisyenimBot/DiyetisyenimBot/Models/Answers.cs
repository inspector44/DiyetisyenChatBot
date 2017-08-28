using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DiyetisyenimBot.Models
{
    public class Answers
    {
        [Key]
        public int ID { get; set; }
        public CocukVarEnum CocukVar { get; set; }
        public int KacCocuk { get; set; }
        public SecimEnum KendiDiyetYapti { get; set; }
        public SecimEnum DiyetisGitti { get; set; }
        public SecimEnum KiloAldiVerdi { get; set; }
        public SecimEnum AzKaloriDiyetYapti { get; set; }
        public SecimEnum AlerjiVar { get; set; }
        public string NeyeAlerji { get; set; }
        public SecimEnum YeterliSuTuketiyor { get; set; }
        public int KacBardakSu { get; set; }
        public SecimEnum CayTuketiyor { get; set; }
        public SecimEnum KahveTuketiyor { get; set; }
        public int KacBardakCay { get; set; }
        public int KacBardakKahve { get; set; }
        public SecimEnum OgunSaatleriDuzenli { get; set; }
        public SecimEnum CayKahveSekerAtar { get; set; }
        public SecimEnum DuzenliEgzersizYapar { get; set; }
        public SecimEnum SigaraKullanir { get; set; } 
        public SecimEnum AlkolKullanir { get; set; } 
        public SecimEnum YersemKiloAlirim { get; set; }
        public SecimEnum Vegan { get; set; }
        public SecimEnum HastaligimVar { get; set; }
        public string Hastalik { get; set; }
        public SecimEnum IlacTedaviGoruyor { get; set; }
        public string IlacAdi { get; set; }
        public SecimEnum SporGecmisiVar { get; set; }
        public string SporAdi { get; set; }
        public SecimEnum HamileMi { get; set; }
        public int KacinciHafta { get; set; }
        public SecimEnum EmziriyorMu { get; set; }
        public CalismaSisEnum CalismaSistemi { get; set; } 
        public CalismaSaatleriEnum CalismaSaatleri { get; set; } 
        public SecimEnum UykuProblemiVar { get; set; }
        public SecimEnum AtistirmaIstegiVar { get; set; }

    }
}