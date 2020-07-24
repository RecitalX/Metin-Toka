using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kurumsal.Models;

namespace Kurumsal.Controllers
{
    public class HizmetKategoriController : Controller
    {
        private KurumsalDB db = new KurumsalDB();

        // GET: HizmetKategori
        public ActionResult Index()
        {
            return View(db.HizmetKategori.ToList().OrderByDescending(x => x.HizmetKategoriId));
        }

        // GET: HizmetKategori/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HizmetKategori hizmetKategori = db.HizmetKategori.Find(id);
            if (hizmetKategori == null)
            {
                return HttpNotFound();
            }
            return View(hizmetKategori);
        }

        // GET: HizmetKategori/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HizmetKategori/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HizmetKategoriId,HizmetKategoriAdi,Aciklama")] HizmetKategori hizmetKategori)
        {
            if (ModelState.IsValid)
            {
                db.HizmetKategori.Add(hizmetKategori);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hizmetKategori);
        }

        // GET: HizmetKategori/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HizmetKategori hizmetKategori = db.HizmetKategori.Find(id);
            if (hizmetKategori == null)
            {
                return HttpNotFound();
            }
            return View(hizmetKategori);
        }

        // POST: HizmetKategori/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HizmetKategoriId,HizmetKategoriAdi,Aciklama")] HizmetKategori hizmetKategori)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hizmetKategori).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hizmetKategori);
        }

        // GET: HizmetKategori/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                HizmetKategori hizmetKategori = db.HizmetKategori.Find(id);
                if (hizmetKategori == null)
                {
                    return HttpNotFound();
                }
                db.HizmetKategori.Remove(hizmetKategori);
                db.SaveChanges();
                TempData["DeleteMessage"] = "succeed";
            }
            catch (Exception ex)
            {

                TempData["DeleteMessage"] = "failed : " + ex.Message;
                TempData["DeleteMessage1"] = "Hata : " + "Bu kategoriyi kullanan ürün varken bu kategoriyi silemezsiniz.";
            }
           
            return RedirectToAction("Index", "HizmetKategori");
        }

        // POST: HizmetKategori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HizmetKategori hizmetKategori = db.HizmetKategori.Find(id);
            db.HizmetKategori.Remove(hizmetKategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
