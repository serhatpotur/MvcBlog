using Business.Concrate;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers
{
    public class TestController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        // GET: Test
        public ActionResult Index()
        {
            return View(cm.GetList());
        }
    }
}