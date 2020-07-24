using Kurumsal.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace Kurumsal.Models.DB_Contect
{
    public class Initializer:DropCreateDatabaseIfModelChanges<KurumsalDB>
    {
        protected override void Seed(KurumsalDB context)
        {
            var kimlikler = new List<Kimlik>()
            {
                new Kimlik(){Title="Test verisi",Description="Test verisi",Keywords="Test verisi",LogoURL="1.jpg"}
            };
            foreach (var item in kimlikler)
            {
                context.Kimlik.Add(item);
            }
            context.SaveChanges();

            var slider = new List<Slider>()
            {
                new Slider(){Baslik="Test verisi",Aciklama="Test Verisi",ResimURL="1.jpg"}
            };
            foreach (var item in slider)
            {
                context.Slider.Add(item);
            }
            context.SaveChanges();

            var banner = new List<Banner>()
            {
                new Banner(){Baslik="Test Verisi",Aciklama="Test Verisi",ResimURL=".JPG"}
            };
            foreach (var item in banner)
            {
                context.Banner.Add(item);
            }
            context.SaveChanges();

            var iletişimbilgisi = new List<Iletisim>()
            {
                new Iletisim(){Telefon="Test verisi",Mail="Test verisi",WeChat="Test verisi",Whatsapp="Test verisi",instagram="Test verisi",Fax="Test verisi"}
            };
            foreach (var item in iletişimbilgisi)
            {
                context.Iletisim.Add(item);
            }
            context.SaveChanges();

            Admin admin = new Admin()
            {
                Eposta = "isemihbl@gmail.com",
                Sifre = Crypto.HashPassword("123"),
                Yetki = "Admin"
            };
            context.Admin.Add(admin);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}