using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiyetisyenimBot.Models
{
    public class Users
    {
        public long ID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int Yas { get; set; }
        public double Kilo { get; set; }
        public CinsiyetEnum Cinsiyet { get; set; }
        public MDurumEnum MedeniDurum { get; set; }
        
    }
}