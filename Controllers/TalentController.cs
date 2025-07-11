using MVC_BusinessLayer.Concrete;
using MVC_DataAccessLayer.EntityFramework;
using MVC_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcEgitimKampi.Controllers
{
    [AllowAnonymous]
    public class TalentController : Controller
    {
        TalentManager tm = new TalentManager(new EfTalentDal());
        // GET: Talent
        public ActionResult Index()
        {
            var degerler = tm.GetList();
            return View(degerler);
            
        }
        [HttpGet]
        public ActionResult AddTalent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTalent(Talent p)
        {
            tm.TalentAddBl(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditTalent(int id)
        {
            var talent = tm.GetById(id);
            return View(talent);
        }
        [HttpPost]
        public ActionResult EditTalent(Talent p)
        {
            tm.TalentUpdateBl(p);
            return RedirectToAction("Index");
        }
    }
}