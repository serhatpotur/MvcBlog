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
    public class WriterMessagePanelController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        // GET: WriterMessagePanel
        public ActionResult WriterInbox( )
        {
            
            var results = messageManager.GetInboxList();
            return View(results);
        }
        public ActionResult WriterSendbox( )
        {
            
            var results = messageManager.GetSendboxList();
            return View(results);
        }
        public ActionResult WriterGetInboxMessageDetails(int id)
        {
            var results = messageManager.GetByMessageId(id);
            return View(results);
        }
        public ActionResult WriterGetSendboxMessageDetails(int id)
        {
            var results = messageManager.GetByMessageId(id);
            return View(results);
        }
        [HttpGet]
        public ActionResult WriterNewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterNewMessage(Message message)
        {
            message.MessageDate = DateTime.Now;
            messageManager.Add(message);
            return RedirectToAction("WriterSendbox");
        }
        public ActionResult Drafts()
        {
            return View();
        }
    }
}