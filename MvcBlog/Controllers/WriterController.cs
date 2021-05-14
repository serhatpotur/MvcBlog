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
    public class WriterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        public ActionResult WriterList()
        {
            var result = writerManager.GetList();
            return View(result);
        }
        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddWriter(Writer writer)
        {
            WriterValidator writerValidator = new WriterValidator();
            ValidationResult results = writerValidator.Validate(writer);
            if (results.IsValid)
            {
                writerManager.Add(writer);
                return RedirectToAction("WriterList");
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
        public ActionResult DeleteWriter(int id)
        {
            var result = writerManager.GetById(id);
            writerManager.Delete(result);
            return RedirectToAction("WriterList");
        }
        [HttpGet]
        public ActionResult UpdateWriter(int id)
        {
            var result = writerManager.GetById(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult UpdateWriter(Writer writer)
        {
            writerManager.Update(writer);
            return RedirectToAction("WriterList");
        }
    }
}