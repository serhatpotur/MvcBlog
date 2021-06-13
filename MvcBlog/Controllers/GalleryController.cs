using Business.Concrate;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers
{
    public class GalleryController : Controller
    {
        ImageFileManager ImageFile = new ImageFileManager(new EfImageFileDal());
        // GET: Galery
        public ActionResult Index()
        {
            var result = ImageFile.GetList();
            return View(result);
        }
    }
}