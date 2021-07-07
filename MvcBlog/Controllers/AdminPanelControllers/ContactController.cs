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
    [Authorize]
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        MessageManager messageManager = new MessageManager(new EfMessageDal());
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
        public PartialViewResult ContactSideBar(string mail)
        {
          

            var UnReadInox = messageManager.GetUnReadInboxList().Count;
            var SenderCount = messageManager.GetSendboxList().Count;
            var ContactCount = contactManager.GetList().Count;
            var DraftCount = messageManager.GetDraftList().Count;
            var ReadInbox = messageManager.GetReadInboxList().Count;
            var TrashListCount = messageManager.GetTrashList().Count;
            ViewBag.d1 = UnReadInox;
            ViewBag.d2 = SenderCount;
            ViewBag.d3 = ContactCount;
            ViewBag.d4 = DraftCount;
            ViewBag.d5 = ReadInbox;
            ViewBag.d6 = TrashListCount;
            return PartialView();
        }
    }
}