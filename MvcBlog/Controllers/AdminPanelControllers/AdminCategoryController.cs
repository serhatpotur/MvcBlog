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
using PagedList;
using PagedList.Mvc;

namespace MvcBlog.Controllers
{
    [Authorize(Roles = "A")]
    // Giriş yapan kişinin rolü A değilse bu controllera erişemez
    public class AdminCategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
      HeadingManager hm = new HeadingManager(new EfHeadingDal());
        // GET: AdminCategory
        public ActionResult CategoryList(int pageNumber = 1)
        {
            var result = categoryManager.GetList().ToPagedList(pageNumber, 10);
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
                category.CategoryStatüs = true;
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
            if (result.CategoryStatüs == true)
            {
                result.CategoryStatüs = false;
                categoryManager.Update(result);
            }
            else
            {
                result.CategoryStatüs = true;
                categoryManager.Update(result);
            }

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
        public ActionResult CategoryByHeading(int id)
        {
            var result = hm.GetListByCategoryId(id);
            var category = categoryManager.GetById(id).CategoryName;
            ViewBag.CategoryName = category;
            return View(result);
        }
    }
}