using Kurumsal.Models.Sınıflar;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Kurumsal.Controllers
{
    public class KimlikController : Controller
    {
        private KurumsalDB db = new KurumsalDB();

        #region Listeleme

        public ActionResult Index()
        {
            return View(db.Kimlik.ToList());
        }

        #endregion Listeleme

        #region Kimlik düzenleme

        public ActionResult Edit(int id)
        {
            var kimlik = db.Kimlik.Where(x => x.KimlikId == id).SingleOrDefault();
            return View(kimlik);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, Kimlik kimlik, HttpPostedFileBase LogoURL)
        {
            if (ModelState.IsValid)
            {
                var k = db.Kimlik.Where(x => x.KimlikId == id).SingleOrDefault();

                if (LogoURL != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(k.LogoURL)))
                    {
                        System.IO.File.Delete(Server.MapPath(k.LogoURL));
                    }
                    WebImage img = new WebImage(LogoURL.InputStream);
                    FileInfo imginfo = new FileInfo(LogoURL.FileName);

                    string logoname = LogoURL.FileName + imginfo.Extension;
                    img.Resize(300, 200);
                    img.Save("~/Uploads/Kimlik/" + logoname);

                    k.LogoURL = "/Uploads/Kimlik/" + logoname;
                }
                k.Title = kimlik.Title;
                k.Keywords = kimlik.Keywords;
                k.Description = kimlik.Description;
                db.SaveChanges();
                TempData["edit"] = "Güncelleme işlemi başarılı";
                return RedirectToAction("Index");
            }
            return View(kimlik);
        }

        #endregion Kimlik düzenleme
    }
}