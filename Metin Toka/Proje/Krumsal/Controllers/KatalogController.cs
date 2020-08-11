using Kurumsal.Models;
using Kurumsal.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Kurumsal.Controllers
{
    public class KatalogController : Controller
    {
        private KurumsalDB db = new KurumsalDB();
        public ActionResult Index()
        {
            var katalog = db.Katalog.ToList().OrderByDescending(x => x.Id);
            return View(katalog);
        }

        public ActionResult Create()
        {
            ViewBag.KatalogId = new SelectList(db.KatalogKategori, "KatalogId", "Baslik");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Katalog k, HttpPostedFileBase ResimURL)
        {
            if (ModelState.IsValid)
            {
                if (ResimURL != null)
                {
                    WebImage img = new WebImage(ResimURL.InputStream);
                    FileInfo imginfo = new FileInfo(ResimURL.FileName);
                    string logoname = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Save("~/Uploads/Katalog/" + logoname);
                    k.ResimURL = "/Uploads/Katalog/" + logoname;
                }
                db.Katalog.Add(k);
                db.SaveChanges();
            }
            TempData["create"] = "Katalog ekleme işlemi başarılı";
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return HttpNotFound();
            }
            var b = db.Katalog.Where(x => x.Id == id).SingleOrDefault();
            if (b == null)
            {
                return HttpNotFound();
            }
            ViewBag.KatalogId = new SelectList(db.KatalogKategori, "KatalogId", "Baslik", b.KatalogId);
            return View(b);
        }

        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(Katalog m, HttpPostedFileBase ResimURL)
        {
            var mkl = db.Katalog.Where(x => x.Id == m.Id).SingleOrDefault();

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

                mkl.ResimURL = "/Uploads/Hizmet/" + logoname;
            }
            mkl.KatalogId = m.KatalogId;

            db.SaveChanges();
            TempData["edit"] = "Katalog güncelleme işlemi başarılı";

            return RedirectToAction("Index", "Katalog");
        }

        public ActionResult Delete(int id)
        {
            var katalog = db.Katalog.Where(x => x.Id == id).SingleOrDefault();
            db.Katalog.Remove(katalog);
            db.SaveChanges(); 
            TempData["delete"] = "Katalog silme işlemi başarılı";
            return RedirectToAction("Index");
        }
    }
}