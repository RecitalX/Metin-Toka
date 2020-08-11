using Kurumsal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using Kurumsal.Models.Sınıflar;

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
            List<HizmetKategori> kategorilistesi = db.HizmetKategori.Where(x => x.HizmetKategoriId > 0).OrderByDescending(x => x.HizmetKategoriId).ToList();
            ViewBag.Kategorilerim = kategorilistesi;
            ViewBag.Kimlik = db.Kimlik.SingleOrDefault();
            return View(db.Hizmet.Include("HizmetKategori").OrderByDescending(x => x.HizmetId).ToPagedList(Sayfa, 40));
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

        #region Kategoriye Ait Ürünler
        //Kategoriye Ait Hizmetler
        [Route("ÜrünPost/{HizmetKategoriAdi}/{id:int}")]
        public ActionResult KategoriyeAitUrunler(int id, int Sayfa = 1)
        {
            ViewBag.Kimlik = db.Kimlik.SingleOrDefault();
            List<HizmetKategori> kategorilistesi = db.HizmetKategori.Where(x => x.HizmetKategoriId > 0).OrderByDescending(x => x.HizmetKategoriId).ToList();
            ViewBag.Kategorilerim = kategorilistesi;
            var u = db.Hizmet.Include("HizmetKategori").OrderByDescending(x => x.HizmetId).Where(x => x.HizmetKategori.HizmetKategoriId == id).ToPagedList(Sayfa, 40);
            TempData["UrunYok"] = "Bu kategoriye ait ürün bulunmamaktadır.";
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

       
        #region Kataloglar
        [Route("Kataloglar")]
        public ActionResult Katalog()
        {
            ViewBag.Kimlik = db.Kimlik.SingleOrDefault();
            return View(db.Katalog.ToList());
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
            List<HizmetKategori> kategorilistesi = db.HizmetKategori.Where(x => x.HizmetKategoriId > 0).OrderByDescending(x => x.HizmetKategoriId).ToList();
            ViewBag.Kategorilerim = kategorilistesi;
            ViewBag.Kimlik = db.Kimlik.SingleOrDefault();
            var urun = from d in db.Hizmet select d;
            if (!string.IsNullOrEmpty(aranan))
            {
                urun = urun.Where(x => x.Baslik.Contains(aranan) || x.UrunKodu.Contains(aranan) || x.Aciklama.Contains(aranan));
                if (urun.Count() == 0)
                {
                    ViewBag.NotFound = "Aramanız eşleşen bir sonuç bulunamadı.";
                    return View(urun);
                }
            }
            return View(urun.ToList());
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

        #region Mesaj Gönderme
        [HttpGet]
        [Route("İletişim")]
        public ActionResult Mesaj()
        {
            ViewBag.Kimlik = db.Kimlik.SingleOrDefault();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Mesaj([Bind(Include = "ID,AdSoyad,Telefon,Konu,İleti")] Mesaj mesaj)
        {
            if (ModelState.IsValid)
            {
                mesaj.saat = DateTime.Now.Hour;
                db.Mesaj.Add(mesaj);
                db.SaveChanges();

            }
            TempData["Basarılı"] = "Mesaj gönderme işlemi başarılı";
            return RedirectToAction("Mesaj", "Home");
        }
        #endregion

        public ActionResult Iletisim()
        {
            var iletisim = db.Iletisim.ToList();
            return PartialView(iletisim);
        }
    }
}