using Business.Concrate;
using DataAccess.EntityFramework;
using Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers.AdminPanelControllers
{
    public class ChartController : Controller
    {
        HeadingManager cm = new HeadingManager(new EfHeadingDal());
        // GET: Chart
        public ActionResult PieChart()
        {
            return View();
        }
        public ActionResult CategoryChart()
        {            
            return Json(cm.GetList(), JsonRequestBehavior.AllowGet);
        }
       

    }
}