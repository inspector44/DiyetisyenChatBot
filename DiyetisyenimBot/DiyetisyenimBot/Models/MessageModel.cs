using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Connector;
using System.Threading.Tasks;
using DiyetisyenimBot.Helper;
using Microsoft.Bot.Builder.FormFlow.Advanced;
using DiyetisyenimBot.EF;
using Newtonsoft.Json;
using DiyetisyenimBot.Controllers;
using Microsoft.ServiceBus.Messaging;
using System.Text;

namespace DiyetisyenimBot.Models
{
    public enum CinsiyetEnum
    {
        IGNORE = 0,
        [Terms("kadin", "Kadin", "kadın", "Kadın")]
        Kadin = 1,
        [Terms("Erkek", "erkek")]
        Erkek = 2
    }

    public enum MDurumEnum
    {
        IGNORE = 0,
        [Terms("Evli", "evli", "evlı", "Evlı")]
        Evli = 1,
        [Terms("bekar", "Bekar")]
        Bekar = 2
    }

    public enum CocukVarEnum
    {
        IGNORE = 0,
        [Terms("Var", "var", "evet", "Evet")]
        Var = 1,
        [Terms("Yok", "yok", "Hayır", "hayir", "Hayir", "hayır")]
        Yok = 2
    }

    public enum SecimEnum
    {
        IGNORE = 0,
        [Terms("Evet", "evet")]
        Evet = 1,
        [Terms("Yok", "yok", "Hayır", "hayir", "Hayir", "hayır")]
        Hayır = 2
    }

    public enum CalismaSisEnum
    {
        IGNORE = 0,
        [Terms("Ayakta", "ayakta")]
        Ayakta = 1,
        [Terms("Masabaşı", "Masabaşi", "Masabasi", "Masabası", "masabaşı", "masabaşi")]
        Masabası = 2,
        [Terms("hareketli", "Hareketli", "Hareketlı", "hareketlı")]
        Hareketli = 3
    }
    public enum CalismaSaatleriEnum
    {
        IGNORE = 0,
        [Terms("TumGun", "Tumgun", "tumgun", "tümgün", "Tüm gün", "tüm gün", "TümGün", "Tum Gun")]
        TumGun = 1,
        [Terms("Gece", "gece")]
        Gece = 2,
        [Terms("Part_Time", "part_time", "part time", "Part Time")]
        Part_Time = 3,
        [Terms("Serbest", "serbest")]
        Serbest = 4
    }

    [Serializable]
    public class MessageModel
    {
        
        

        [Prompt("Adiniz Nedir?")]
        public string Ad { get; set; }

        [Prompt("Soyadiniz Nedir?")]
        public string Soyad { get; set; }

        [Prompt("Yaşınız?")]
        public int Yas { get; set; }

        [Prompt("Kilonuz")]
        public double Kilo { get; set; }

        [Template(TemplateUsage.EnumSelectOne, "Bir seçim yapar mısınız? {||}", "Bir seçim yapar mısınız?{||}")]
        public CinsiyetEnum CinsEnum_Method { get; set; }
        //public CinsiyetEnum cinsBool { get; set; }


        [Template(TemplateUsage.EnumSelectOne, "Medeni Durumunuz nedir? {||}", "Medeni Durumunuz nedir?{||}")]
        public MDurumEnum MDurumEnum_Method { get; set; }
        //public MDurumEnum MedDurumBool { get; set; }



        [Template(TemplateUsage.EnumSelectOne, "Çocuğunuz var mı? {||}", "Çocuğunuz var mı?{||}")]
        public CocukVarEnum CocukVar_Method { get; set; }
        //public CocukVarEnum CocukVarBool { get; set; }



        [Prompt("Kaç çocuğunuz var?")]
        public int KacCocuk { get; set; }


        [Template(TemplateUsage.EnumSelectOne, "Kendi kendinize hiç diyet yaptınız mı? {||}", "Kendi kendinize hiç diyet yaptınız mı?{||}")]
        public SecimEnum DiyetYapti_Method { get; set; }
        //public SecimEnum KendiDiyetYaptiBool { get; set; }


        [Template(TemplateUsage.EnumSelectOne, "Daha önce diyetisyene gittiniz mi? {||}", "Daha önce diyetisyene gittiniz mi?{||}")]
        public SecimEnum DiyetGitti_Method { get; set; }
        //public SecimEnum DiyetisGittiBool { get; set; }


        [Template(TemplateUsage.EnumSelectOne, "Daha önce fazla kilo alıp verdiniz mi? {||}", "Daha önce fazla kilo alıp verdiniz mi? {||}")]
        public SecimEnum KiloAldiVerdi_Method { get; set; }
        //public SecimEnum KiloAldiVerdiBool { get; set; }


        [Template(TemplateUsage.EnumSelectOne, "Daha önce az kalorili diyet yaptınız mı? {||}", "Daha önce az kalorili diyet yaptınız mı? {||}")]
        public SecimEnum AzKaloriDiYapti_Method { get; set; }
        //public SecimEnum AzKaloriDiyetYaptiBool { get; set; }


        [Template(TemplateUsage.EnumSelectOne, "Herhangi bir şeye alerjiniz var mı? {||}", "Herhangi bir şeye alerjiniz var mı? {||}")]
        public SecimEnum AlerjiVar_Method { get; set; }
        //public SecimEnum AlerjiVarBool { get; set; }


        [Prompt("Neye alerjiniz var?")]
        public string NeyeAlerji { get; set; }


        [Template(TemplateUsage.EnumSelectOne, "Yeterli miktarda su tüketiyor musunuz? {||}", "Yeterli miktarda su tüketiyor musunuz? {||}")]
        public SecimEnum YeterliSu_Method { get; set; }
        //public SecimEnum YeterliSuTuketiyorBool { get; set; }


        [Prompt("Günde kaç bardak su içiyorsunuz?")]
        public int KacBardakSu { get; set; }


        [Template(TemplateUsage.EnumSelectOne, "Sık sık çay tüketiyor musunuz? {||}", "Sık sık çay tüketiyor musunuz? {||}")]
        public SecimEnum CayTuketiyor_Method { get; set; }
        //public SecimEnum CayTuketiyorBool { get; set; }


        [Template(TemplateUsage.EnumSelectOne, "Sık sık çay kahve tüketiyor musunuz? {||}", "Sık sık çay kahve tüketiyor musunuz? {||}")]
        public SecimEnum Kahvetuketiyor_Method { get; set; }
        //public SecimEnum KahveTuketiyorBool { get; set; }


        [Prompt("Günde kaç bardak çay içiyorsunuz?")]
        public int KacBardakCay { get; set; }

        [Prompt("Günde kaç bardak kahve tüketiyorsunuz?")]
        public int KacBardakKahve { get; set; }

        [Template(TemplateUsage.EnumSelectOne, "Öğün saatleriniz düzenli mi? {||}", "Öğün saatleriniz düzenli mi? {||}")]
        public SecimEnum OgunSaatleriDuzenli_Method { get; set; }
        //public SecimEnum OgunSaatleriDuzenliBool { get; set; }


        [Template(TemplateUsage.EnumSelectOne, "Çay/Kahveye şeker atar mısınız? {||}", "Çay/Kahveye şeker atar mısınız? {||}")]
        public SecimEnum SekerAtarmi_Method { get; set; }
        //public SecimEnum CayKahveSekerAtarBool { get; set; }


        [Template(TemplateUsage.EnumSelectOne, "Düzenli egzersiz yapar mısınız? {||}", "Düzenli egzersiz yapar mısınız? {||}")]
        public SecimEnum EgzersizYapar_Method { get; set; }
        //public SecimEnum DuzenliEgzersizYaparBool { get; set; }


        [Template(TemplateUsage.EnumSelectOne, "Sigara kullanıyor musunuz? {||}", "Sigara kullanıyor musunuz? {||}")]
        public SecimEnum SigaraKullanir_Method { get; set; }
        //public SecimEnum SigaraKullanirBool { get; set; }


        [Template(TemplateUsage.EnumSelectOne, "Alkol kullanıyor musunuz? {||}", "Alkol kullanıyor musunuz? {||}")]
        public SecimEnum AlkolKullanir_Method { get; set; }
        //public SecimEnum AlkolKullanirBool { get; set; }


        [Template(TemplateUsage.EnumSelectOne, "Yersem kilo alırım diye düşünüyor musunuz? {||}", "Yersem kilo alırım diye düşünüyor musunuz? {||}")]
        public SecimEnum YersemKilo_Method { get; set; }
        //public SecimEnum YersemKiloAlirimBool { get; set; }


        [Template(TemplateUsage.EnumSelectOne, "Vegan veya vejeteryan mısınız? {||}", "Vegan veya vejeteryan mısınız? {||}")]
        public SecimEnum VeganVej_Method { get; set; }
        //public SecimEnum VeganBool { get; set; }


        [Template(TemplateUsage.EnumSelectOne, "Herhangi bir hastalığınız var mı? {||}", "Herhangi bir hastalığınız var mı? {||}")]
        public SecimEnum HastalikVar_Method { get; set; }
        //public SecimEnum HastaligimVarBool { get; set; }


        [Prompt("Hastalığınız nedir?")]
        public string Hastalik { get; set; }


        [Template(TemplateUsage.EnumSelectOne, "İlaç tedavisi görüyor musunuz?  {||}", "İlaç tedavisi görüyor musunuz?{||}")]
        public SecimEnum IlacTedGoruyor_Method { get; set; }
        //public SecimEnum IlacTedaviGoruyorBool { get; set; }


        [Prompt("Kullandığınız ilacın adı nedir?")]
        public string IlacAdi { get; set; }



        [Template(TemplateUsage.EnumSelectOne, "Profesyonel spor geçmişiniz var mı? {||}", "Profesyonel spor geçmişiniz var mı? {||}")]
        public SecimEnum SporGecmisi_Method { get; set; }
        //public SecimEnum SporGecmisiVarBool { get; set; }


        [Prompt("Hangi spor?")]
        public string SporAdi { get; set; }



        [Template(TemplateUsage.EnumSelectOne, "Hamile misiniz? {||}", "Hamile misiniz? {||}")]
        public SecimEnum HamileMi_Method { get; set; }
        //public SecimEnum HamileMiBool { get; set; }


        [Prompt("Hamileliğinizin kaçıncı haftasındasınız?")]
        public int KacinciHafta { get; set; }


        [Template(TemplateUsage.EnumSelectOne, "Emziriyor musunuz? {||}", "Emziriyor musunuz? {||}")]
        public SecimEnum EmziriyorMu_Method { get; set; }
        //public SecimEnum EmziriyorMuBool { get; set; }


        [Template(TemplateUsage.EnumSelectOne, "Çalışma sisteminiz nasıl? {||}", "Çalışma sisteminiz nasıl? {||}")]
        public CalismaSisEnum CalismaSistemi_Method { get; set; }
        //public CalismaSisEnum CalismaSistemi { get; set; }


        [Template(TemplateUsage.EnumSelectOne, "Çalışma saatleriniz nasıl? {||}", "Çalışma saatleriniz nasıl? {||}")]
        public CalismaSaatleriEnum CalismSaatleri_Method { get; set; }
        //public CalismaSaatleriEnum CalismaSaatleri { get; set; }



        [Template(TemplateUsage.EnumSelectOne, "Uyku probleminiz var mı? {||}", "Uyku probleminiz var mı? {||}")]
        public SecimEnum UykuProVar_Method { get; set; }
        //public SecimEnum UykuProblemiVarBool { get; set; }


        [Template(TemplateUsage.EnumSelectOne, "Sık sık atıştırma isteği duyuyor musunuz? {||}", "Sık sık atıştırma isteği duyuyor musunuz? {||}")]
        public SecimEnum AtistirmaIstegi_Method { get; set; }
        //public SecimEnum AtistirmaIstegiVarBool { get; set; }



        public static IForm<MessageModel> BuildForm()
        {
            OnCompletionAsyncDelegate<MessageModel> tamamlandi = async (context, state) =>
            {
                await context.PostAsync("Verdiğiniz yanıtlar için teşekkür ederiz.");
                
                var user = new Users()
                {
                    Ad = state.Ad,
                    Soyad = state.Soyad,
                    Cinsiyet = state.CinsEnum_Method,
                    Kilo = state.Kilo,
                    MedeniDurum = state.MDurumEnum_Method,
                    Yas = state.Yas
                };
                var answers = new Answers()
                {
                    CocukVar = state.CocukVar_Method,
                    KacCocuk = state.KacCocuk,
                    KendiDiyetYapti = state.DiyetYapti_Method,
                    DiyetisGitti = state.DiyetGitti_Method,
                    KiloAldiVerdi = state.KiloAldiVerdi_Method,
                    AzKaloriDiyetYapti = state.AzKaloriDiYapti_Method,
                    AlerjiVar = state.AlerjiVar_Method,
                    NeyeAlerji = state.NeyeAlerji,
                    YeterliSuTuketiyor = state.YeterliSu_Method,
                    KacBardakSu = state.KacBardakSu,
                    CayTuketiyor = state.CayTuketiyor_Method,
                    KahveTuketiyor = state.Kahvetuketiyor_Method,
                    KacBardakCay = state.KacBardakCay,
                    KacBardakKahve = state.KacBardakKahve,
                    OgunSaatleriDuzenli = state.OgunSaatleriDuzenli_Method,
                    CayKahveSekerAtar = state.SekerAtarmi_Method,
                    DuzenliEgzersizYapar = state.EgzersizYapar_Method,
                    SigaraKullanir = state.SigaraKullanir_Method,
                    AlkolKullanir = state.AlkolKullanir_Method,
                    YersemKiloAlirim = state.YersemKilo_Method,
                    Vegan = state.VeganVej_Method,
                    HastaligimVar = state.HastalikVar_Method,
                    Hastalik = state.Hastalik,
                    IlacTedaviGoruyor = state.IlacTedGoruyor_Method,
                    IlacAdi = state.IlacAdi,
                    SporGecmisiVar = state.SporGecmisi_Method,
                    SporAdi = state.SporAdi,
                    HamileMi = state.HamileMi_Method,
                    KacinciHafta = state.KacinciHafta,
                    EmziriyorMu = state.EmziriyorMu_Method,
                    CalismaSistemi = state.CalismaSistemi_Method,
                    CalismaSaatleri = state.CalismSaatleri_Method,
                    UykuProblemiVar = state.UykuProVar_Method,
                    AtistirmaIstegiVar = state.AtistirmaIstegi_Method

                };

                var EvntHubModl = new Models.EventHubModel()
                {
                    Ad = state.Ad,
                    Soyad = state.Soyad,
                    Cinsiyet = state.CinsEnum_Method,
                    Kilo = state.Kilo,
                    MedeniDurum = state.MDurumEnum_Method,
                    Yas = state.Yas,

                    CocukVar = state.CocukVar_Method,
                    KacCocuk = state.KacCocuk,
                    KendiDiyetYapti = state.DiyetYapti_Method,
                    DiyetisGitti = state.DiyetGitti_Method,
                    KiloAldiVerdi = state.KiloAldiVerdi_Method,
                    AzKaloriDiyetYapti = state.AzKaloriDiYapti_Method,
                    AlerjiVar = state.AlerjiVar_Method,
                    NeyeAlerji = state.NeyeAlerji,
                    YeterliSuTuketiyor = state.YeterliSu_Method,
                    KacBardakSu = state.KacBardakSu,
                    CayTuketiyor = state.CayTuketiyor_Method,
                    KahveTuketiyor = state.Kahvetuketiyor_Method,
                    KacBardakCay = state.KacBardakCay,
                    KacBardakKahve = state.KacBardakKahve,
                    OgunSaatleriDuzenli = state.OgunSaatleriDuzenli_Method,
                    CayKahveSekerAtar = state.SekerAtarmi_Method,
                    DuzenliEgzersizYapar = state.EgzersizYapar_Method,
                    SigaraKullanir = state.SigaraKullanir_Method,
                    AlkolKullanir = state.AlkolKullanir_Method,
                    YersemKiloAlirim = state.YersemKilo_Method,
                    Vegan = state.VeganVej_Method,
                    HastaligimVar = state.HastalikVar_Method,
                    Hastalik = state.Hastalik,
                    IlacTedaviGoruyor = state.IlacTedGoruyor_Method,
                    IlacAdi = state.IlacAdi,
                    SporGecmisiVar = state.SporGecmisi_Method,
                    SporAdi = state.SporAdi,
                    HamileMi = state.HamileMi_Method,
                    KacinciHafta = state.KacinciHafta,
                    EmziriyorMu = state.EmziriyorMu_Method,
                    CalismaSistemi = state.CalismaSistemi_Method,
                    CalismaSaatleri = state.CalismSaatleri_Method,
                    UykuProblemiVar = state.UykuProVar_Method,
                    AtistirmaIstegiVar = state.AtistirmaIstegi_Method
                };

                try
                {

                    var JsonUser = JsonConvert.SerializeObject(EvntHubModl);
                    //var JsonAnswers = JsonConvert.SerializeObject(answers);
                    var EventHubClient = MessagesController.ConnectEventHub();
                    //EventHubClient.Send(new EventData(Encoding.UTF8.GetBytes(JsonAnswers)));
                    EventHubClient.Send(new EventData(Encoding.UTF8.GetBytes(JsonUser)));
                    
                    using (EF.ApplicationDbContext db = new ApplicationDbContext())
                    {

                        db.Answers.Add(answers);
                        db.Users.Add(user);
                        
                        db.SaveChanges();
                    }
                    
                }
                catch (Exception)
                {

                    throw;
                }
            };
            return new FormBuilder<MessageModel>()
                .Message("Diyetisyenime Hoşgeldiniz.")

                .Field(nameof(Ad))

                .Field(nameof(Soyad))

                .Field(nameof(Yas))

                .Field(nameof(Kilo))
                
                .Field(nameof(CinsEnum_Method))
                
                .Field(nameof(MDurumEnum_Method))
                
                .Field(nameof(CocukVar_Method))

                .Field(nameof(KacCocuk))
                
                .Field(nameof(DiyetYapti_Method))
                
                .Field(nameof(DiyetGitti_Method))
                
                .Field(nameof(KiloAldiVerdi_Method))
                
                .Field(nameof(AzKaloriDiYapti_Method))
                
                .Field(nameof(AlerjiVar_Method))

                .Field(nameof(NeyeAlerji))
                
                .Field(nameof(YeterliSu_Method))

                .Field(nameof(KacBardakSu))
                
                .Field(nameof(CayTuketiyor_Method))
                
                .Field(nameof(Kahvetuketiyor_Method))

                .Field(nameof(KacBardakCay))

                .Field(nameof(KacBardakKahve))
                
                .Field(nameof(OgunSaatleriDuzenli_Method))
                
                .Field(nameof(SekerAtarmi_Method))
                
                .Field(nameof(EgzersizYapar_Method))
                
                .Field(nameof(SigaraKullanir_Method))
                
                .Field(nameof(AlkolKullanir_Method))
                
                .Field(nameof(YersemKilo_Method))
                
                .Field(nameof(VeganVej_Method))
                
                .Field(nameof(HastalikVar_Method))

                .Field(nameof(Hastalik))
                
                .Field(nameof(IlacTedGoruyor_Method))

                .Field(nameof(IlacAdi))            
                
                .Field(nameof(SporGecmisi_Method))               

                .Field(nameof(SporAdi))

                .Field(nameof(HamileMi_Method))
         
                .Field(nameof(KacinciHafta))

                .Field(nameof(EmziriyorMu_Method))

                .Field(nameof(CalismaSistemi_Method))

                .Field(nameof(CalismSaatleri_Method))

                .Field(nameof(UykuProVar_Method))


                .Field(nameof(AtistirmaIstegi_Method))
                .AddRemainingFields()
                .OnCompletion(tamamlandi)
                .Build();
        }
        

    }
}