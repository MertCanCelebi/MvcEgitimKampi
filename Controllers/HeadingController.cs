using FluentValidation.Results;
using MVC_BusinessLayer.Concrete;
using MVC_BusinessLayer.ValidationRules;
using MVC_DataAccessLayer.EntityFramework;
using MVC_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcEgitimKampi.Controllers
{
    public class HeadingController : Controller
    {
        // GET: Heading
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());

        public ActionResult Index()
        {
            var degerler = hm.GetList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> list = (from x in cm.GetList()
                                         select new SelectListItem
                                         {
                                             Text = x.CategoryName,
                                             Value = x.CategoryId.ToString()
                                         }).ToList();
            List<SelectListItem> list2 = (from x in wm.GetList()
                                         select new SelectListItem
                                         {
                                             Text = x.WriterName + " " + x.WriterSurname,
                                             Value = x.WriterId.ToString()
                                         }).ToList();
            ViewBag.vlc = list;
            ViewBag.vlw = list2;
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading c)
        {
            c.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingAddBl(c);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateHeading(int id)
        {
            List<SelectListItem> list = (from x in cm.GetList()
                                         select new SelectListItem
                                         {
                                             Text = x.CategoryName,
                                             Value = x.CategoryId.ToString()
                                         }).ToList();
            ViewBag.vlc = list;
            var heading = hm.GetById(id);
            return View(heading);
        }
        [HttpPost]
        public ActionResult UpdateHeading(Heading h)
        {
            
            hm.HeadingUpdateBl(h);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteHeading(int id)
        {
            var heading = hm.GetById(id);
            hm.HeadingDeleteBl(heading);
            return RedirectToAction("Index");
        }
    }
}