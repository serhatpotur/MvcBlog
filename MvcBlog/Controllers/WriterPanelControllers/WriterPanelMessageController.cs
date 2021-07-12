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

namespace MvcBlog.Controllers.WriterPanelControllers
{
    
    public class WriterPanelMessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        MessageValidator messageValidator = new MessageValidator();
        // GET: WriterPanelMessage
        public ActionResult WriterUnReadInbox( )
        {
            string mail = (String)Session["WriterMail"];
            var results = messageManager.GetUnReadInboxList(mail);
            return View(results);
        }
        public ActionResult WriterReadInbox( )
        {
            string mail = (String)Session["WriterMail"];
            var results = messageManager.GetReadInboxList(mail);
            return View(results);
        }
        public ActionResult WriterSendbox( )
        {
            string mail = (String)Session["WriterMail"];
            var results = messageManager.GetSendboxList(mail);
            return View(results);
        }
        public ActionResult GetWriterInboxMessageDetails(int id)
        {
            var results = messageManager.GetByMessageId(id);
            return View(results);
        }
        public ActionResult GetWriterSendboxMessageDetails(int id)
        {
            var results = messageManager.GetByMessageId(id);
            return View(results);
        }
        [HttpGet]
        public ActionResult NewWriterMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewWriterMessage(Message message, string menuName)
        {
            ValidationResult results = messageValidator.Validate(message);
            //Gönder Butonuna basılmış ise
            if (menuName == "send")
            {
                //Validator kontrol ettik
                if (results.IsValid)
                {
                    //Şimdilik kapalı Session ile çekilecek
                    //message.SenderMail = "admin@gmail.com";
                    message.MessageDate = DateTime.Now;
                    messageManager.Add(message);
                    return RedirectToAction("Sendbox");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }

            }
            //Taslaklara kaydet ise
            else if (menuName == "draft")
            {
                if (results.IsValid)
                {
                    //message.SenderMail = "admin@gmail.com";
                    message.isDraft = true;
                    message.MessageDate = DateTime.Now;
                    messageManager.Add(message);
                    return RedirectToAction("DraftMessages");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            //Eğer kullanıcı İptal tuşuna basarsa;
            else if (menuName == "cancel")
            {
                return RedirectToAction("NewMessage");
            }
            return View();


        }
        public ActionResult WriterDraftMessages()
        {
            var result = messageManager.GetDraftList();
            return View(result);
        }
        public ActionResult WriterDeleteMessage(int id)
        {
            var result = messageManager.GetByMessageId(id);
            result.isTrash = true;
            messageManager.Update(result);
            return RedirectToAction("UnReadInbox");
        }
        public ActionResult WriterReadMessage(int id)
        {
            var result = messageManager.GetByMessageId(id);
            result.isRead = true;
            messageManager.Update(result);
            return RedirectToAction("UnReadInbox");
        }
        public ActionResult WriterTrashMessageList()
        {
            var result = messageManager.GetTrashList();
            return View(result);
        }
        
        public PartialViewResult MessageListMenü( )
        {
            string mail = (String)Session["WriterMail"];

            var UnReadInox = messageManager.GetUnReadInboxList(mail).Count;
            var SenderCount = messageManager.GetSendboxList(mail).Count;
            
            var DraftCount = messageManager.GetDraftList().Count;
            var ReadInbox = messageManager.GetReadInboxList(mail).Count;
            var TrashListCount = messageManager.GetTrashList().Count;
            ViewBag.d1 = UnReadInox;
            ViewBag.d2 = SenderCount;
            
            ViewBag.d4 = DraftCount;
            ViewBag.d5 = ReadInbox;
            ViewBag.d6 = TrashListCount;
            return PartialView();
        }
    }
}