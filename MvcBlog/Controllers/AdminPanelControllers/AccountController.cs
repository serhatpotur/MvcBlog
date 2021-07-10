using Business.Concrate;
using DataAccess.Concrate;
using DataAccess.EntityFramework;
using Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcBlog.Controllers
{
    [AllowAnonymous]  //Kurallardan muaf olsun
    public class AccountController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            //SHA1 sha = new SHA1CryptoServiceProvider();
            //string password = admin.AdminPassword;
            //string gelen = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(password)));
            //admin.AdminPassword = gelen;
          
            var result = adminManager.GetUsernamePassword(admin.AdminUserName, admin.AdminPassword);
            if (result != null)
            {

                FormsAuthentication.SetAuthCookie(result.AdminUserName, false); //false: kalıcı cookie oluşmasın
                Session["AdminUserName"] = result.AdminUserName;
                return RedirectToAction("UnReadInbox", "Message");


            }
            else
            {
                ViewBag.ErrorMessage = "Giriş Bilgileriniz Hatalı";
                return View();
            }

        }
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer writer)
        {
            //SHA1 sha = new SHA1CryptoServiceProvider();
            //string password = admin.AdminPassword;
            //string gelen = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(password)));
            //admin.AdminPassword = gelen;

            var result = writerManager.GetUsernamePassword(writer.WriterMail, writer.WriterPassword).FirstOrDefault(); 
            if (result != null)
            {

                FormsAuthentication.SetAuthCookie(result.WriterMail, false); //false: kalıcı cookie oluşmasın
                Session["WriterMail"] = result.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");


            }
            else
            {
                ViewBag.ErrorMessage = "Giriş Bilgileriniz Hatalı";
                return View();
            }

        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login");
        }

    }
}