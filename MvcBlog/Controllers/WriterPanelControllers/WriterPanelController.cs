using Business.Concrate;
using DataAccess.EntityFramework;
using Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers.WriterPanelControllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        int id;
        // GET: WriterPanel
        public ActionResult WriterProfile()
        {
            return View();
        }
        public ActionResult MyHeading(string mail)
        {
            
            mail = (string)Session["WriterMail"];
            var writerinfo = writerManager.GetWriterMail(mail);
            id = writerinfo.WriterID;           
            var result = headingManager.GetListByWriterId(id);
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
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterID = id;
            heading.isActive = true;
            headingManager.Add(heading);

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
            heading.WriterID = id;
            heading.isActive = true;
            headingManager.Update(heading);
            return RedirectToAction("MyHeading");
        }
        public ActionResult DeleteHeading(int id)
        {
            var result = headingManager.GetById(id);
            result.isActive = false;
            headingManager.Update(result);
            return RedirectToAction("MyHeading");
        }
    }
}