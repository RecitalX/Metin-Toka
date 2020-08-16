using Kurumsal.Models.Sınıflar;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Kurumsal.Controllers
{
    public class KatalogKategoriController : Controller
    {
        private KurumsalDB db = new KurumsalDB();

        #region Kategori Listeleme

        public ActionResult Index()
        {
            var kategori = db.KatalogKategori.ToList().OrderByDescending(x => x.KatalogId);
            return View(kategori);
        }

        #endregion Kategori Listeleme

        #region Kategori Ekleme

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(KatalogKategori k, HttpPostedFileBase ResimURL)
        {
            if (ResimURL != null)
            {
                WebImage img = new WebImage(ResimURL.InputStream);
                FileInfo imginfo = new FileInfo(ResimURL.FileName);
                string logoname = Guid.NewGuid().ToString() + imginfo.Extension;
                img.Save("~/Uploads/Katalog/" + logoname);
                k.ResimURL = "/Uploads/Katalog/" + logoname;
            }
            db.KatalogKategori.Add(k);
            db.SaveChanges();

            TempData["create"] = "Ürün ekleme işlemi başarılı";
            return RedirectToAction("Index");
        }

        #endregion Kategori Ekleme

        #region Kategori Güncelleme

        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return HttpNotFound();
            }
            var b = db.KatalogKategori.Where(x => x.KatalogId == id).SingleOrDefault();
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }

        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(KatalogKategori m, HttpPostedFileBase ResimURL)
        {
            var mkl = db.KatalogKategori.Where(x => x.KatalogId == m.KatalogId).SingleOrDefault();

            if (ResimURL != null)
            {
                if (System.IO.File.Exists(Server.MapPath(mkl.ResimURL)))
                {
                    System.IO.File.Delete(Server.MapPath(mkl.ResimURL));
                }
                WebImage img = new WebImage(ResimURL.InputStream);
                FileInfo imginfo = new FileInfo(ResimURL.FileName);

                string logoname = Guid.NewGuid().ToString() + imginfo.Extension;
                img.Save("~/Uploads/Katalog/" + logoname);
                mkl.ResimURL = "/Uploads/Katalog/" + logoname;

                mkl.ResimURL = "/Uploads/Katalog/" + logoname;
            }
            mkl.Baslik = m.Baslik;
            db.SaveChanges();
            TempData["edit"] = "Katalog güncelleme işlemi başarılı";

            return RedirectToAction("Index", "KatalogKategori");
        }

        #endregion Kategori Güncelleme

        #region Kategori Silme

        public ActionResult Delete(int id)
        {
            var katalog = db.KatalogKategori.Where(x => x.KatalogId == id).SingleOrDefault();
            if (System.IO.File.Exists(Server.MapPath(katalog.ResimURL)))
            {
                System.IO.File.Delete(Server.MapPath(katalog.ResimURL));
            }
            db.KatalogKategori.Remove(katalog);
            db.SaveChanges();
            TempData["delete"] = "Ürün silme işlemi başarılı";
            return RedirectToAction("Index", "KatalogKategori");
        }

        #endregion Kategori Silme
    }
}