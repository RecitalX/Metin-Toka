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
    public class BannerController : Controller
    {
        KurumsalDB db = new KurumsalDB();
        public ActionResult Index()
        {
            return View(db.Banner.ToList());
        }

        // GET: Banner/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banner banner = db.Banner.Find(id);
            if (banner == null)
            {
                return HttpNotFound();
            }
            return View(banner);
        }


        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Baslik,ResimURL,Aciklama,Url")] Banner banner, HttpPostedFileBase ResimURL, int id)
        {
            if (ModelState.IsValid)
            {
                var k = db.Banner.Where(x => x.ID == id).SingleOrDefault();

                if (ResimURL != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(k.ResimURL)))
                    {
                        System.IO.File.Delete(Server.MapPath(k.ResimURL));
                    }
                    WebImage img = new WebImage(ResimURL.InputStream);
                    FileInfo imginfo = new FileInfo(ResimURL.FileName);

                    string logoname = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Save("~/Uploads/Banner/" + logoname);
                    k.ResimURL = "/Uploads/Banner/" + logoname;

                    k.ResimURL = "/Uploads/Banner/" + logoname;
                }
                k.Baslik = banner.Baslik;
                k.Aciklama = banner.Aciklama;
                k.Url = banner.Url;
                db.SaveChanges();
                TempData["Bilgi"] = "Güncelleme İşleminiz Başarılı ";
                return RedirectToAction("Index");
            }
            return View(banner);
        } 
    }
}