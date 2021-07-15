using Business.Concrate;
using DataAccess.EntityFramework;
using Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers.AdminPanelControllers
{
    public class AuthorizationController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());

        // GET: Authorization
        public ActionResult AdminList()
        {
            var result = writerManager.GetList();
            return View(result);
        }
      
      
        public ActionResult AddAdmin(int id)
        {
            var writerinfo = writerManager.GetById(id);
            writerinfo.WriterRole = "M";
            writerManager.Update(writerinfo);
            return RedirectToAction("AdminList");
        }
       
        public ActionResult DeleteAdmin(int id)
        {
            var writerinfo = writerManager.GetById(id);
            writerinfo.WriterRole = "W";
            writerManager.Update(writerinfo);
            return RedirectToAction("AdminList");
        }
        public PartialViewResult PartialWriterList()
        {

            return PartialView(writerManager.GetList());
        }
    }
}