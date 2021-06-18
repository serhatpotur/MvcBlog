using Business.Concrate;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers
{
    public class MyProfileController : Controller
    {
        UserManager userManager = new UserManager(new EfUserDal());
        SkillManager skillManager = new SkillManager(new EfSkillDal());
        // GET: MyProfile
        public ActionResult Index()
        {
            var result = skillManager.GetList();
            ViewBag.username = "Serhat Potur";
            ViewBag.Desc = "Web Developer Adayı";
            return View(result);
        }
    }
}