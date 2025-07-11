using MVC_BusinessLayer.Concrete;
using MVC_DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcEgitimKampi.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        ContentManager cm = new ContentManager(new EfContentDal());
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetAllContent()
        {
            var degerler = cm.GetList("");

            return View(degerler);
        }
        [HttpPost]
        public ActionResult GetAllContent(string p)
        {
            var degerler = cm.GetList(p);

            return View(degerler);
        }

        public ActionResult ContentByHeading(int id)
        {
            var degerler = cm.GetListByHeadingId(id);
            return View(degerler);
        }
    }
}