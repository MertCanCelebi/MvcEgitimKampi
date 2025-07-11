using MVC_BusinessLayer.Concrete;
using MVC_DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcEgitimKampi.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        ContentManager cm = new ContentManager(new EfContentDal());
        // GET: Default
        public PartialViewResult Index(int id = 0)
        {
            var contentList = cm.GetListByHeadingId(id);
            return PartialView(contentList);
        }
        public ActionResult Headings()
        {
            var headingList = hm.GetList();
            return View(headingList);
        }
    }
}