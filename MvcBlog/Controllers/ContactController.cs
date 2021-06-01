using Business.Concrate;
using DataAccess.Concrate;
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
        Context context = new Context();
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
            var ReceiverCount = context.Messages.Where(x => x.ReceiverMail == "admin@gmail.com").Count();
            var SenderCount = context.Messages.Where(x => x.SenderMail == "admin@gmail.com").Count();
            var ContactCount = context.Contacts.Count();
            ViewBag.d1 = ReceiverCount;
            ViewBag.d2 = SenderCount;
            ViewBag.d3 = ContactCount;
            return PartialView();
        }
    }
}