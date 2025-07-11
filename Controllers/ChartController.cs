using MvcEgitimKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcEgitimKampi.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }

        public List<Category> BlogList()
        {
            List<Category> ct = new List<Category>();
            ct.Add(new Category()
            {
                CategoryName = "Yazılım",
                CategoryCount = 8
            });
            ct.Add(new Category()
            {
                CategoryName = "Seyahat",
                CategoryCount = 4
            });
            ct.Add(new Category()
            {
                CategoryName = "Teknoloji",
                CategoryCount = 7
            });
            ct.Add(new Category()
            {
                CategoryName = "Spor",
                CategoryCount = 1
            });
            return ct;
        }
    }
}