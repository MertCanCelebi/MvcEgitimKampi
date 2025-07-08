using FluentValidation.Results;
using Microsoft.Ajax.Utilities;
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
    public class AdminCategoryController : Controller
    {
        // GET: AdminCategory
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        [Authorize(Roles ="B")]
        public ActionResult Index()
        {
            var degerler = cm.GetList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category c)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult validationResult = categoryValidator.Validate(c);
            if (validationResult.IsValid)
            {
                cm.CategoryAddBl(c);
                return RedirectToAction("Index");
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
        public ActionResult DeleteCategory(int id)
        {
            var category = cm.GetById(id);
            cm.CategoryDeleteBl(category);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var category = cm.GetById(id);
            return View(category);
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            cm.CategoryUpdateBl(category);
            return RedirectToAction("Index");
        }
    }
}