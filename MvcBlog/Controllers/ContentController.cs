using Business.Concrate;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers
{
    public class ContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        // GET: Content
        public ActionResult ContentByHeading(int id)
        {
            var result = contentManager.GetListByHeadingId(id);
            result.OrderByDescending(x => x.ContentDate);
            var head = headingManager.GetById(id).HeadingName;
            ViewBag.HeadName = head;
            return View(result);
        }
    }
}