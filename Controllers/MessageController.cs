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
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        public ActionResult Inbox()
        {
            var degerler = mm.GetListInbox();
            return View(degerler);
        }
        public ActionResult Sendbox()
        {
            var degerler2 = mm.GetListSendbox();
            return View(degerler2);
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            var degerler3 = mm.GetById(id);
            return View(degerler3);
        }
        public ActionResult GetSendboxMessageDetails(int id)
        {
            var degerler3 = mm.GetById(id);
            return View(degerler3);
        }
        [HttpGet]
        public ActionResult AddMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddMessage(Message m)
        {
            
            ValidationResult validationResult = messageValidator.Validate(m);
            if (validationResult.IsValid)
            {
                m.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAddBl(m);
                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(m);
        }
    }
}