using Kurumsal.Models.Sınıflar;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Kurumsal.Controllers
{
    public class MesajController : Controller
    {
        private KurumsalDB db = new KurumsalDB();

        #region Listeleme

        public ActionResult Index()
        {
            var mesaj = db.Mesaj.ToList().OrderByDescending(x => x.ID);
            TempData["Mesaj"] = "Şuan gösterilercek hiç mesajınız yok";

            return View(mesaj);
        }

        #endregion Listeleme

        #region Mesaj Detay

        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mesaj mesaj = db.Mesaj.Find(id);
            if (mesaj == null)
            {
                return HttpNotFound();
            }
            return View(mesaj);
        }

        #endregion Mesaj Detay

        #region Mesaj Silme

        public ActionResult Delete(int id)
        {
            var mesaj = db.Mesaj.Where(x => x.ID == id).SingleOrDefault();
            db.Mesaj.Remove(mesaj);
            db.SaveChanges();
            TempData["delete"] = "Silme İşlemi Başarılı";
            return RedirectToAction("Index", "Mesaj");
        }

        #endregion Mesaj Silme
    }
}