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
    public class ProductController : Controller
    {
        Productoperation res = new Productoperation();
        Categoryoperation ress = new Categoryoperation();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Getallproduct()
        {
            var result = res.Getallproduct();
            
            return PartialView(result);
        }
        [HttpGet]
        public ActionResult Saveproduct()
        {
            var result = ress.Getallcategory();
            ViewBag.msg = new SelectList(result,"Id","Name");

            return View();
        }
        [HttpPost]
        public ActionResult Saveproduct(Productmodel model)
        {
            if (ModelState.IsValid)
            {
                int id = res.Saveproduct(model);
                if (id > 0)
                {
                    ModelState.Clear();

                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id) 
        {
            var result = res.Getcategory(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult Edit(Productmodel model)
        {
            if (ModelState.IsValid) 
            {
                res.updateproduct(model.Id, model);
            }
            return RedirectToAction("getallproduct");
        }
        public ActionResult Delete(int id) 
        {
            res.deleteproduct(id);
            return RedirectToAction("Getallproduct");
        }
        public ActionResult Deleteid(int id)
        {

            return View();
        }

    }
}