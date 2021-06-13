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
    public class MessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        // GET: Message
        public ActionResult Inbox()
        {
            var results = messageManager.GetInboxList();
            return View(results);
        }
        public ActionResult Sendbox()
        {
            var results = messageManager.GetSendboxList();
            return View(results);
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            var results = messageManager.GetByMessageId(id);
            return View(results);
        }
        public ActionResult GetSendboxMessageDetails(int id)
        {
            var results = messageManager.GetByMessageId(id);
            return View(results);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            message.MessageDate = DateTime.Now;
            messageManager.Add(message);
            return RedirectToAction("Sendbox");
        }
        public ActionResult Drafts()
        {
            return View();
        }
    }
}