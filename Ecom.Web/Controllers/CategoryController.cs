using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecom.Db;
using Ecom.Models;
using Ecom.Db.Dboperation;

namespace Ecom.Web.Controllers
{
    public class CategoryController : Controller
    {
        Categoryoperation res = new Categoryoperation();
        public ActionResult Index()
        {
            var result = res.Getallcategory();
            return View(result);
        }
        public ActionResult Addcategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Addcategory(Categorymodel model)
        {
            if (ModelState.IsValid) 
            {
                int id = res.savecategory(model);
                if (id > 0) 
                {
                    ModelState.Clear();
                    ViewBag.msg = "insert successfully...";
                }
            }
            return View();
        }
        public ActionResult Details(int id) 
        {
            var category = res.Getcategory(id);
            return View(category);
        }
        public ActionResult Edit(int id)
        {
            var category = res.Getcategory(id);
            return View(category);
        }
        [HttpPost]
        public ActionResult Edit(Categorymodel model)
        {
            if (ModelState.IsValid) 
            {
                res.updatecategory(model.Id, model);
                return RedirectToAction("Index");
            }
            return View();
        }
        
        public ActionResult Delete(int id) 
        {
            res.deletecategory(id);
            return RedirectToAction("Index");
        }
    }
}