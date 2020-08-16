using Kurumsal.Models.Sınıflar;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Kurumsal.Controllers
{
    public class HomeController : Controller
    {
        private KurumsalDB db = new KurumsalDB();

        #region Anasayfa

        [Route("")]
        [Route("Anasayfa")]
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Kimlik = db.Kimlik.SingleOrDefault();
            return View();
        }

        #endregion Anasayfa

        #region Ürünler

        [Route("Ürünler")]
        public ActionResult Urun(int Sayfa = 1)
        {
            List<HizmetKategori> kategorilistesi = db.HizmetKategori.Where(x => x.HizmetKategoriId > 0).OrderByDescending(x => x.HizmetKategoriId).ToList();
            ViewBag.Kategorilerim = kategorilistesi;
            ViewBag.Kimlik = db.Kimlik.SingleOrDefault();
            return View(db.Hizmet.Include("HizmetKategori").OrderByDescending(x => x.HizmetId).ToPagedList(Sayfa, 40));
        }

        #endregion Ürünler

        #region Ürün Detay

        [Route("ÜrünPost/{Baslik}-{id:int}")]
        public ActionResult UrunDetay(int id)
        {
            ViewBag.Kimlik = db.Kimlik.SingleOrDefault();
            var u = db.Hizmet.Include("HizmetKategori").Where(x => x.HizmetId == id).SingleOrDefault();
            return View(u);
        }

        #endregion Ürün Detay

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

        #endregion Kategoriye Ait Ürünler

        #region Hakkımızda

        [Route("Hakkımızda")]
        public ActionResult Hakkimizda()
        {
            ViewBag.Kimlik = db.Kimlik.SingleOrDefault();
            return View(db.Hakkimizda.ToList());
        }

        #endregion Hakkımızda

        #region Kataloglar

        [Route("Kataloglar")]
        public ActionResult Katalog()
        {
            ViewBag.Kimlik = db.Kimlik.SingleOrDefault();
            return View(db.KatalogKategori.ToList());
        }

        #endregion Kataloglar

        #region KatalogSlider

        [Route("Kataloglar/{Baslik}/{id:int}")]
        public ActionResult KatalogSlider(int id)
        {
            ViewBag.Kimlik = db.Kimlik.SingleOrDefault();
            var katalog = db.Katalog.Include("KatalogKategori").OrderByDescending(x => x.Id).Where(x => x.KatalogKategori.KatalogId == id);
            return View(katalog);
        }

        #endregion KatalogSlider

        #region En Son Eklenen Ürünler

        public ActionResult EnsonEklenenUruler()
        {
            var urun = db.Hizmet.OrderByDescending(x => x.HizmetId).Take(9);
            return View(urun);
        }

        #endregion En Son Eklenen Ürünler

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

        #endregion Arama Yap

        #region Slider

        public ActionResult Slider()
        {
            return View(db.Slider.ToList().OrderByDescending(x => x.ID));
        }

        #endregion Slider

        #region Banner

        public ActionResult Banner()
        {
            return View(db.Banner.ToList());
        }

        #endregion Banner

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

        #endregion Mesaj Gönderme

        #region İletşim

        public ActionResult Iletisim()
        {
            var iletisim = db.Iletisim.ToList();
            return PartialView(iletisim);
        }

        #endregion İletşim
    }
}