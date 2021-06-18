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
    public class WriterPanelController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        // GET: WriterPanel
        public ActionResult WriterProfile()
        {
            return View();
        }

        public ActionResult MyHeading()
        {

            var result = headingManager.GetListByWriterId();
            return View(result);
        }
        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> categoryValues = (from i in categoryManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = i.CategoryName,
                                                       Value = i.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.Categories = categoryValues;
            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Now;
            heading.WriterID = 2;
            heading.isActive = true;
            headingManager.Add(heading);

            return RedirectToAction("MyHeading");
        }
        public ActionResult DeleteHeading(int id)
        {
            var result = headingManager.GetById(id);
            result.isActive = false;
            headingManager.Delete(result);
            return RedirectToAction("MyHeading");
        }
        [HttpGet]
        public ActionResult UpdateHeading(int id)
        {
            var result = headingManager.GetById(id);
            List<SelectListItem> categoryValues = (from i in categoryManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = i.CategoryName,
                                                       Value = i.CategoryID.ToString()
                                                   }).ToList();
           
            ViewBag.Categories = categoryValues;           
            return View(result);
        }
        [HttpPost]
        public ActionResult UpdateHeading(Heading heading)
        {
            heading.WriterID = 2;
            headingManager.Update(heading);
            return RedirectToAction("MyHeading");
        }
    }
}