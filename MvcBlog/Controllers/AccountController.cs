using Business.Concrate;
using DataAccess.Concrate;
using DataAccess.EntityFramework;
using Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcBlog.Controllers
{
    public class AccountController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal()); 
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            //Context context = new Context();

            //var result = context.Admins.FirstOrDefault(x => x.AdminUserName == admin.AdminUserName && x.AdminPassword == admin.AdminPassword);
            var result = adminManager.GetUsernamePassword(admin.AdminUserName, admin.AdminPassword);
            if (result !=null)
            {
                FormsAuthentication.SetAuthCookie(result.AdminUserName,false);
                Session["AdminUserName"] = result.AdminUserName;
                return RedirectToAction("CategoryList", "AdminCategory");
            }
            else {
                ViewBag.ErrorMessage = "Giriş Bilgileriniz Hatalı";
                return View();
            }
            
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        
    }
}