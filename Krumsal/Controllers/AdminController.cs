using Kurumsal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Kurumsal.Controllers
{
    public class AdminController : Controller
    {
        KurumsalDB db = new KurumsalDB();

        #region Anasayfa
        [Route("yonetimpaneli")]
        public ActionResult Index()
        {
            ViewBag.HizmetSay = db.Hizmet.Count();
            return View();
        }
        #endregion

        #region Login
        [Route("yonetimpaneli/giris")]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin admin)
        {

            var login = db.Admin.Where(x => x.Eposta == admin.Eposta).SingleOrDefault();
            if (login.Eposta == admin.Eposta && login.Sifre == Crypto.Hash(admin.Sifre, "MD5"))
            {
                Session["adminid"] = login.AdminId;
                Session["eposta"] = login.Eposta;
                Session["yetki"] = login.Yetki;
                return RedirectToAction("Index", "Admin");
            }
            ViewBag.Uyari = "Kullanıcı adı yada şifre yanlış";
            return View(admin);

        }
        #endregion

        #region Logout
        public ActionResult Logout()
        {
            Session["adminid"] = null;
            Session["eposta"] = null;
            Session.Abandon();
            return RedirectToAction("Login", "Admin");
        }
        #endregion

        #region Şifremi Unuttum (Local Host)
        public ActionResult SifremiUnuttum()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SifremiUnuttum(string eposta)
        {
            var mail = db.Admin.Where(x => x.Eposta == eposta).SingleOrDefault();
            if (mail != null)
            {
                Random rnd = new Random();
                int yenisifre = rnd.Next();

                Admin admin = new Admin();
                mail.Sifre = Crypto.Hash(Convert.ToString(yenisifre), "MD5");
                db.SaveChanges();

                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.EnableSsl = true;
                WebMail.UserName = "kurumsalsite6161@gmail.com";
                WebMail.Password = "Furkan123";
                WebMail.SmtpPort = 587;
                WebMail.Send(eposta, "Admin Panel Giriş Şifreniz", "Şifreniz : " + yenisifre);
                ViewBag.Uyari = "Şifreniz başarı ile gönderilmiştir";
            }
            else
            {
                ViewBag.Uyari = "Sistemde böyle bir mail bulunmamaktadır";
            }
            return View();

        }
        #endregion

        #region Şifremi Unuttum (Server)
        //public ActionResult SifremiUnuttum(string eposta)
        //{
        //    var mail = db.Admin.Where(x => x.Eposta == eposta).SingleOrDefault();
        //    if (mail != null)
        //    {
        //        Random rnd = new Random();
        //        int yenisifre = rnd.Next();

        //        Admin admin = new Admin();
        //        mail.Sifre = Crypto.Hash(Convert.ToString(yenisifre), "MD5");
        //        db.SaveChanges();

        //        WebMail.SmtpServer = "mail.smtpserver";
        //        WebMail.EnableSsl = false;
        //        WebMail.UserName = "kurumsalsite6161@gmail.com";
        //        WebMail.Password = "Furkan123";
        //        WebMail.SmtpPort = 25;
        //        WebMail.Send(eposta, "Admin Panel Giriş Şifreniz", "Şifreniz : " + yenisifre);

        //        ViewBag.Uyari = "Şifreniz Başarı ile gönderilmiştir";
        //    }
        //    else
        //    {
        //        ViewBag.Uyari = "Hata Oluştu.Tekrar deneyiniz";
        //    }
        //    return View();

        //}
        #endregion

        #region Admin Listelenen kısım 
        public ActionResult Adminler()
        {
            return View(db.Admin.ToList());
        }
        #endregion

        #region Yeni Admin Olusturma
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Admin admin, string sifre, string eposta)
        {

            if (ModelState.IsValid)
            {
                admin.Sifre = Crypto.Hash(sifre, "MD5");
                db.Admin.Add(admin);
                db.SaveChanges();
                return RedirectToAction("Adminler");
            }
            return View(admin);
        }
        #endregion

        #region Admin Düzenleme
        public ActionResult Edit(int id)
        {
            var a = db.Admin.Where(x => x.AdminId == id).SingleOrDefault();
            return View(a);
        }
        [HttpPost]

        public ActionResult Edit(int id, Admin admin, string sifre, string eposta)
        {
            if (ModelState.IsValid)
            {
                var a = db.Admin.Where(x => x.AdminId == id).SingleOrDefault();
                a.Sifre = Crypto.Hash(sifre, "MD5");
                a.Eposta = admin.Eposta;
                a.Yetki = admin.Yetki; ;
                db.SaveChanges();
                return RedirectToAction("Adminler");
            }
            return View(admin);
        }
        #endregion

        #region Admin Silme
        public ActionResult Delete(int id)
        {
            var a = db.Admin.Where(x => x.AdminId == id).SingleOrDefault();
            if (a != null)
            {
                db.Admin.Remove(a);
                db.SaveChanges();
                return RedirectToAction("Adminler");

            }
            return View();
        }
        #endregion
    }
}