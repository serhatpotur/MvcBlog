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
    [Authorize(Roles ="A")] 
    // Giriş yapan kişinin rolü A değilse bu controllera erişemez
    public class AdminCategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        // GET: AdminCategory
        public ActionResult CategoryList()
        {
            var result = categoryManager.GetList();
            return View(result);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(category);
            if (results.IsValid)
            {
                categoryManager.Add(category);
                return RedirectToAction("CategoryList");
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
        public ActionResult DeleteCategory(int id)
        {
            var result = categoryManager.GetById(id);
            categoryManager.Delete(result);
            return RedirectToAction("CategoryList");
        }
        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var result = categoryManager.GetById(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            categoryManager.Update(category);
            return RedirectToAction("CategoryList");
        }
    }
}