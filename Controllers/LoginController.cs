using MVC_DataAccessLayer.Concrete;
using MVC_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcEgitimKampi.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            Context c = new Context();
            var admininfo = c.Admins.FirstOrDefault(x=>x.AdminUserName == p.AdminUserName && x.AdminPassword==p.AdminPassword);
            if (admininfo != null)
            {
                FormsAuthentication.SetAuthCookie(admininfo.AdminUserName,false);
                Session["AdminUserName"]=admininfo.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }
                
        }
    }
}