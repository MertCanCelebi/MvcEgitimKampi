using FluentValidation.Results;
using MVC_BusinessLayer.Concrete;
using MVC_BusinessLayer.ValidationRules;
using MVC_DataAccessLayer.Concrete;
using MVC_DataAccessLayer.EntityFramework;
using MVC_EntityLayer.Concrete;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcEgitimKampi.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        Context c = new Context();
        // GET: WriterPanel
        [HttpGet]
        public ActionResult WriterProfile(int id=0)
        {
            string p = (string)Session["WriterMail"];
            id = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();
            var degerler = wm.GetById(id);
            return View(degerler);
        }

        [HttpPost]
        public ActionResult WriterProfile(Writer writer)
        {
            WriterValidator writerValidator = new WriterValidator();
            ValidationResult validationResult = writerValidator.Validate(writer);
            if (validationResult.IsValid)
            {
                wm.WriterUpdateBl(writer);
                return RedirectToAction("AllHeading");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult MyHeading(string p )
        {
            
            p = (string)Session["WriterMail"];
            var writeruserinfo = c.Writers.Where(x => x.WriterMail == p).Select(y=>y.WriterId).FirstOrDefault();
            var values = hm.GetListByWriter(writeruserinfo);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> list = (from x in cm.GetList()
                                         select new SelectListItem
                                         {
                                             Text = x.CategoryName,
                                             Value = x.CategoryId.ToString()
                                         }).ToList();
            ViewBag.vlc = list;
            
            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading p)
        {
            string a = (string)Session["WriterMail"];
            var writeruserinfo = c.Writers.Where(x => x.WriterMail == a).Select(y => y.WriterId).FirstOrDefault();
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterId = writeruserinfo;
            p.HeadingStatus = true;
            hm.HeadingAddBl(p);
            return RedirectToAction("MyHeading");
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
            return RedirectToAction("MyHeading");
        }
        public ActionResult DeleteHeading(int id)
        {
            var heading = hm.GetById(id);
            hm.HeadingDeleteBl(heading);
            return RedirectToAction("MyHeading");
        }
        public ActionResult AllHeading(int p=1)
        {
            var heading = hm.GetList().ToPagedList(p,4);
            return View(heading);
        }

    }
}