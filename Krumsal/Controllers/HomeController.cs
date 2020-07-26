using Kurumsal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace Kurumsal.Controllers
{

    public class HomeController : Controller
    {
        KurumsalDB db = new KurumsalDB();

        #region Anasayfa
        [Route("")]
        [Route("Anasayfa")]
        [HttpGet]
        public ActionResult Index() 
        {
            ViewBag.Kimlik = db.Kimlik.SingleOrDefault();
            return View();
        }
        #endregion

        #region Ürünler
        [Route("Ürünler")]
        public ActionResult Urun(int Sayfa = 1)
        {
            ViewBag.Kimlik = db.Kimlik.SingleOrDefault();
            return View(db.Hizmet.Include("HizmetKategori").OrderByDescending(x => x.HizmetId).ToPagedList(Sayfa, 9));
        }
        #endregion

        #region İletişim
        [HttpGet]
        [Route("İletişim")] 
        public ActionResult Iletisim()
        {
            ViewBag.Kimlik = db.Kimlik.SingleOrDefault();
            return View(db.Iletisim.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Iletisim(string adsoyad = null, string email = null, string konu = null, string mesaj = null)
        {

            if (adsoyad != null && email != null)
            {
                WebMail.SmtpServer = "mail.dugmesatis.com";
                WebMail.EnableSsl = false;
                WebMail.UserName = "info@dugmesatis.com";
                WebMail.Password = "MuzafferinKabugu+!";
                WebMail.SmtpPort = 587;
                WebMail.Send("info@dugmesatis.com", konu, "<p class='p-5 bg-primary'>" + email + "</p>" + "<p>" + mesaj + "</p>");
                ViewBag.Uyari = "Mesajınız başarı ile gönderilmiştir.";
            }
            else
            {
                ViewBag.Uyari = "Hata Oluştu.Tekrar deneyiniz";
            }
            return RedirectToAction("Iletisim", "Home");
        }
        #endregion

        #region Ürün Detay
        [Route("ÜrünPost/{Baslik}-{id:int}")]
        public ActionResult UrunDetay(int id)
        {
            ViewBag.Kimlik = db.Kimlik.SingleOrDefault();
            var u = db.Hizmet.Include("HizmetKategori").Where(x => x.HizmetId == id).SingleOrDefault();
            return View(u);
        }

        #endregion

        #region Kategori Listesi
        [Route("ÜrünPost/{HizmetKategoriAdi}/{id:int}")]
        public PartialViewResult KategoriListesi(int? id)
        {
            if (id != null)
            {
                ViewBag.Kategoriler = id;
                var urunlist = db.Hizmet.Where(x => x.HizmetKategoriId == id);
                return PartialView(urunlist);
            }
            else
            {
                var urunlist = db.Hizmet.ToList();
                return PartialView(urunlist);
            }
        }

        #endregion

        #region Kategoriye Ait Ürünler
        //Kategoriye Ait Hizmetler
        [Route("ÜrünPost/{HizmetKategoriAdi}/{id:int}")]
        public ActionResult KategoriyeAitUrunler(int id, int Sayfa = 1)
        {
            ViewBag.Kimlik = db.Kimlik.SingleOrDefault();

            var u = db.Hizmet.Include("HizmetKategori").OrderByDescending(x => x.HizmetId).Where(x => x.HizmetKategori.HizmetKategoriId == id).ToPagedList(Sayfa, 9);
            return View(u);
        }
        #endregion

        #region Hakkımızda 
        [Route("Hakkımızda")]
        public ActionResult Hakkimizda()
        {
            ViewBag.Kimlik = db.Kimlik.SingleOrDefault();
            return View(db.Hakkimizda.ToList());
        }
        #endregion

        #region En Son Eklenen Ürünler
        public ActionResult EnsonEklenenUruler()
        {
            var urun = db.Hizmet.OrderByDescending(x => x.HizmetId).Take(9);
            return View(urun);
        }
        #endregion

        #region Arama Yap
        [Route("AramaSayfası")]
        public ActionResult AramaYap(string aranan)
        {
            ViewBag.Kimlik = db.Kimlik.SingleOrDefault();

            if (!string.IsNullOrEmpty(aranan))
            {
                var mkl = db.Hizmet.Where(x => x.Baslik.Contains(aranan)).ToList();
                if (mkl.Count == 0)
                {
                    ViewBag.NotFound = "Aramanızla Eşleşen Hiçbir Kayıt Bulunamadı!";
                    return View(mkl);
                }
                return View(mkl);
            }
            return View();
        }
        #endregion

        #region Slider 
        public ActionResult Slider()
        {
            return View(db.Slider.ToList().OrderByDescending(x => x.ID));
        }
        #endregion

        #region Banner
        public ActionResult Banner()
        {
            return View(db.Banner.ToList());
        }
        #endregion
    }
}