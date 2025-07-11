using MVC_BusinessLayer.Concrete;
using MVC_DataAccessLayer.Concrete;
using MVC_DataAccessLayer.EntityFramework;
using MVC_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcEgitimKampi.Controllers
{
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent
        ContentManager cm = new ContentManager(new EfContentDal());
        Context c = new Context();
        public ActionResult MyContent(string p)
        {
            
            p = (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x=>x.WriterMail== p).Select(y=>y.WriterId).FirstOrDefault();
            var degerler = cm.GetListByWriter(writeridinfo);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {           
            ViewBag.d=id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content p)
        {
            string a = (string)Session["WriterMail"];
            var writeruserinfo = c.Writers.Where(x => x.WriterMail == a).Select(y => y.WriterId).FirstOrDefault();
            p.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterId = writeruserinfo;
            p.ContentStatus = true;
            cm.ContentAddBl(p);
            return RedirectToAction("MyContent");
        }
    }
}