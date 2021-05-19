using Business.Concrate;
using Business.ValidationRules.FluentValidation;
using DataAccess.EntityFramework;
using Entity.Concrate;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        public ActionResult HeadingList()
        {
            var result = headingManager.GetList();
            return View(result);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {

            List<SelectListItem> categoryValues = (from i in categoryManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = i.CategoryName,
                                                       Value = i.CategoryID.ToString()
                                                   }).ToList();
            List<SelectListItem> writerValues = (from i in writerManager.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = i.WriterName + " " + i.WriterSurname,
                                                     Value = i.WriterID.ToString()
                                                 }).ToList();
            ViewBag.Categories = categoryValues;
            ViewBag.Writers = writerValues;
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            HeadingValidator headingValidator = new HeadingValidator();
            ValidationResult results = headingValidator.Validate(heading);
            if (results.IsValid)
            {
                headingManager.Add(heading);
                return RedirectToAction("HeadingList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }

        }
    }
}