﻿using Business.Concrate;
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
    [AllowAnonymous]
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
            
            var result = adminManager.GetUsernamePassword(admin.AdminUserName, admin.AdminPassword);
            if (result !=null)
            {
                FormsAuthentication.SetAuthCookie(result.AdminUserName,false); //false: kalıcı cookie oluşmasın
                Session["AdminUserName"] = result.AdminUserName;
                return RedirectToAction("Inbox", "Message");
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