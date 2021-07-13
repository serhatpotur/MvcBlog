using Business.Concrate;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers.AdminPanelControllers
{
    public class ReportController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        // GET: Report
        public ActionResult HeadingReport()
        {
            return View(hm.GetList());
        }
    }
}