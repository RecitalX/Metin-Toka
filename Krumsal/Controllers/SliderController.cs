using Kurumsal.Models;
using Kurumsal.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Kurumsal.Controllers
{
    public class SliderController : Controller
    {
        KurumsalDB db = new KurumsalDB();
        #region Listeleme
        public ActionResult Index()
        {
            return View(db.Slider.ToList().OrderByDescending(x => x.ID));
        }
        #endregion

        #region Slider Ekleme
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ID,Baslik,Aciklama,ResimURL")] Slider slider, HttpPostedFileBase ResimURL)
        {
            if (ModelState.IsValid)
            {
                if (ResimURL != null)
                {
                    WebImage img = new WebImage(ResimURL.InputStream);
                    FileInfo imginfo = new FileInfo(ResimURL.FileName);
                    string logoname = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Save("~/Uploads/Slider/" + logoname);
                    slider.ResimURL = "/Uploads/Slider/" + logoname;
                }
                db.Slider.Add(slider);
                db.SaveChanges();
                TempData["Bilgi"] = "Slider ekleme işlemi başarılı";
                return RedirectToAction("Index");
            }

            return View(slider);
        }
        #endregion

        #region Slider Düzenleme
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Slider.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "ID,Baslik,Aciklama,ResimURL")] Slider slider, HttpPostedFileBase ResimURL, int id)
        {
            if (ModelState.IsValid)
            {
                var s = db.Slider.Where(x => x.ID == id).SingleOrDefault();
                if (ResimURL != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(s.ResimURL)))
                    {
                        System.IO.File.Delete(Server.MapPath(s.ResimURL));
                    }
                    WebImage img = new WebImage(ResimURL.InputStream);
                    FileInfo imginfo = new FileInfo(ResimURL.FileName);

                    string sliderimgname = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(1024, 360);
                    img.Save("~/Uploads/Slider/" + sliderimgname);

                    s.ResimURL = "/Uploads/Slider/" + sliderimgname;
                }
                s.Baslik = slider.Baslik;
                s.Aciklama = slider.Aciklama;
                db.SaveChanges();
                TempData["Bilgi"] = "Slider güncelleme işlemi başarılı";
                return RedirectToAction("Index");
            }
            return View(slider);
        }
        #endregion

        #region Slider Silme
        public ActionResult Delete(int id)
        {
            Slider slider = db.Slider.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            if (System.IO.File.Exists(Server.MapPath(slider.ResimURL)))
            {
                System.IO.File.Delete(Server.MapPath(slider.ResimURL));
            }
            db.Slider.Remove(slider);
            db.SaveChanges();
            TempData["Bilgi"] = "Slider silme işlemi başarılı";
            return RedirectToAction("Index");
        }
        #endregion
    }
}