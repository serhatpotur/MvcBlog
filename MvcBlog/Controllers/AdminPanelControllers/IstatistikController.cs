using DataAccess.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers
{
    public class IstatistikController : Controller
    {
        Context context = new Context();
        // GET: Istatistik
        public ActionResult Index()
        {
            var result = context.Categories.Count();
            var result2 = context.Headings.Count(x => x.Category.CategoryID == 7);
            var result3 = context.Writers.Count(x=>x.WriterName.Contains("a"));
            var result4 = context.Headings.Max(x => x.Category.CategoryName);
            var result5 = context.Categories.Count(x => x.CategoryStatüs ==true);
            var result6 = context.Categories.Count(x => x.CategoryStatüs == false);
            ViewBag.CategoryCount = result;
            ViewBag.Heading = result2;
            ViewBag.Writer = result3;
            ViewBag.HeadingMax = result4;
            ViewBag.StatüsFark = (result5 - result6);
            return View();
        }
    }
}