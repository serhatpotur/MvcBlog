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
    //[Authorize]
    public class MessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        MessageValidator messageValidator = new MessageValidator();
        // GET: Message

        public ActionResult UnReadInbox()
        {
            string mail = (String)Session["WriterMail"];
            var results = messageManager.GetUnReadInboxList(mail);
            return View(results);
        }
        public ActionResult ReadInbox( )
        {
            string mail = (String)Session["WriterMail"];
            var results = messageManager.GetReadInboxList(mail);
            return View(results);
        }
        public ActionResult Sendbox( )
        {
            string mail = (String)Session["WriterMail"];
            var results = messageManager.GetSendboxList(mail);
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
        public ActionResult NewMessage(Message message, string menuName)
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
        public ActionResult DraftMessages()
        {
            var result = messageManager.GetDraftList();
            return View(result);
        }
        public ActionResult DeleteMessage(int id)
        {
            var result = messageManager.GetByMessageId(id);
            result.isTrash = true;
            messageManager.Update(result);
            return RedirectToAction("UnReadInbox");
        }
        public ActionResult ReadMessage(int id)
        {
            var result = messageManager.GetByMessageId(id);
            result.isRead = true;
            messageManager.Update(result);
            return RedirectToAction("UnReadInbox");
        }
        public ActionResult TrashMessageList()
        {
            var result = messageManager.GetTrashList();
            return View(result);
        }
    }
}