using Business.Concrate;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers
{
    [AllowAnonymous]
    public class HomePageController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        ContentManager cm = new ContentManager(new EfContentDal());
        // GET: Home
        public ActionResult Headings()
        {
            var results = hm.GetList();
           
            return View(results);
        }
        public PartialViewResult Contents(int id=0)
        {
            var results = cm.GetListByHeadingId(id);

            return PartialView(results);
        }
    }
}