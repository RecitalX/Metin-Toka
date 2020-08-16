using Kurumsal.Models.Sınıflar;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Kurumsal.Controllers
{
    public class HizmetKategoriController : Controller
    {
        private KurumsalDB db = new KurumsalDB();

        #region Listeleme

        public ActionResult Index()
        {
            return View(db.HizmetKategori.ToList().OrderByDescending(x => x.HizmetKategoriId));
        }

        #endregion Listeleme

        #region Kategori Ekleme

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HizmetKategoriId,HizmetKategoriAdi,Aciklama")] HizmetKategori hizmetKategori)
        {
            if (ModelState.IsValid)
            {
                db.HizmetKategori.Add(hizmetKategori);
                db.SaveChanges();
                TempData["create"] = "Kategori ekleme işlemi başarılı";
                return RedirectToAction("Index");
            }

            return View(hizmetKategori);
        }

        #endregion Kategori Ekleme

        #region Kategori Düzenlme

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HizmetKategoriId,HizmetKategoriAdi,Aciklama")] HizmetKategori hizmetKategori)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hizmetKategori).State = EntityState.Modified;
                db.SaveChanges();
                TempData["edit"] = "Kategori güncelleme işlemi başarılı";
                return RedirectToAction("Index");
            }
            return View(hizmetKategori);
        }

        #endregion Kategori Düzenlme

        #region Kategori Sil

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
            //TempData["delete"] = "Kategori silme işlemi başarılı";
            return RedirectToAction("Index", "HizmetKategori");
        }

        #endregion Kategori Sil

        #region Silme İşlemi Onay

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HizmetKategori hizmetKategori = db.HizmetKategori.Find(id);
            db.HizmetKategori.Remove(hizmetKategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion Silme İşlemi Onay
    }
}