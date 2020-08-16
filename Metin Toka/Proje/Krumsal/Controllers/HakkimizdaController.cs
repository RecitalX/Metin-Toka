using Kurumsal.Models.Sınıflar;
using System.Linq;
using System.Web.Mvc;

namespace Kurumsal.Controllers
{
    public class HakkimizdaController : Controller
    {
        private KurumsalDB db = new KurumsalDB();

        #region Listeleme

        public ActionResult Index()
        {
            var h = db.Hakkimizda.ToList();
            return View(h);
        }

        #endregion Listeleme

        #region Düzenleme

        public ActionResult Edit(int id)
        {
            var h = db.Hakkimizda.Where(x => x.HakkimizdaId == id).FirstOrDefault();

            return View(h);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, Hakkimizda h)
        {
            if (ModelState.IsValid)
            {
                var hakkimizda = db.Hakkimizda.Where(x => x.HakkimizdaId == id).SingleOrDefault();

                hakkimizda.Aciklama = h.Aciklama;
                db.SaveChanges();
                TempData["edit"] = "Güncelleme işlemi başarılı";
                return RedirectToAction("Index");
            }

            return View(h);
        }

        #endregion Düzenleme
    }
}