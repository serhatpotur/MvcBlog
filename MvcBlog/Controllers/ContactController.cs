using Business.Concrate;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers
{
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        // GET: Contact
        public ActionResult ContactList()
        {
            var result = contactManager.GetList();
            return View(result);
        }
        public ActionResult GetContactDetails(int id)
        {
            var results = contactManager.GetById(id);
            return View(results);
        }
        public PartialViewResult ContactSideBar()
        {
            return PartialView();
        }
    }
}