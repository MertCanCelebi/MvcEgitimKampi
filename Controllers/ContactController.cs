using MVC_BusinessLayer.Concrete;
using MVC_DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcEgitimKampi.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager cm = new ContactManager(new EfContactDal());
        public ActionResult Index()
        {
            var degerler = cm.GetList();
            return View(degerler);
        }
        public ActionResult GetContactDetails(int id)
        {
            var detaylar2 = cm.GetById(id);
            return View(detaylar2);
        }
        public PartialViewResult ContactPartial()
        {
            return PartialView();
        }
    }
}