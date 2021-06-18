using Business.Concrate;
using DataAccess.EntityFramework;
using Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers
{
    [Authorize]
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutDal());
        // GET: About
        public ActionResult AboutList()
        {
            var result = aboutManager.GetList();
            return View(result);
        }
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            about.isActive = true;
            aboutManager.Add(about);
            return RedirectToAction("AboutList");
        }
        public ActionResult DurumDegis(int id)
        {
            var result= aboutManager.GetByID(id);
            if (result.isActive==true)
            {
                result.isActive = false;
                aboutManager.Update(result);
            }
            else
            {
                result.isActive = true;
                aboutManager.Update(result);

            }

            return RedirectToAction("AboutList");
        }
        public PartialViewResult AddAboutPartial()
        {
            return PartialView();
        }
    }
}