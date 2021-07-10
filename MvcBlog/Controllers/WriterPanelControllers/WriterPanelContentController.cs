using Business.Concrate;
using DataAccess.Concrate;
using DataAccess.EntityFramework;
using Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers.WriterPanelControllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        // GET: WriterPanelContent
        public ActionResult MyContent(String mail)
        {
            //Mimariye taşınacak
            //Context c = new Context();
            //session = (string)Session["WriterMail"];
            //var writeridinfo = c.Writers.Where(x => x.WriterMail == session).Select(y => y.WriterID).FirstOrDefault();

            int id;
            mail = (string)Session["WriterMail"];
            var writerinfo = writerManager.GetWriterMail(mail);
            id = writerinfo.WriterID;
            var result = contentManager.ContentListByWriter(id);
            return View(result);
        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.hid = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            int id;
            string mail = (string)Session["WriterMail"];
            var writerinfo = writerManager.GetWriterMail(mail);
            id = writerinfo.WriterID;
            content.WriterID = id;
            content.ContentDate = DateTime.Now;
            content.isActive = true;
            contentManager.Add(content);
            return RedirectToAction("MyContent");
        }

    }
}