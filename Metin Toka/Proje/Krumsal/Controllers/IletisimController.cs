using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kurumsal.Models;
using Kurumsal.Models.Sınıflar;

namespace Kurumsal.Controllers
{
    public class IletisimController : Controller
    {
        private KurumsalDB db = new KurumsalDB();

        #region Listeleme
        public ActionResult Index()
        {
            return View(db.Iletisim.ToList());
        }
        #endregion

        #region İletişim Bilgileri Güncelleme
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Iletisim iletisim = db.Iletisim.Find(id);
            if (iletisim == null)
            {
                return HttpNotFound();
            }
            return View(iletisim);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IletisimId,Telefon,Mail,WeChat,Whatsapp,instagram,Fax,")] Iletisim iletisim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iletisim).State = EntityState.Modified;
                db.SaveChanges();
                TempData["edit"] = "Güncelleme işlemi başarılı";
                return RedirectToAction("Index");
            }
            return View(iletisim);
        }
        #endregion

    }
}
