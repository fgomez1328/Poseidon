using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Poseidon.Controllers
{
    public class UserLoggerController : Controller
    {
        // GET: UserLogger
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserLogger/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserLogger/Create

        public ActionResult ListLogger()
        {
           
            
            
            
            return View();
        
        
        
        }




        // POST: UserLogger/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserLogger/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserLogger/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserLogger/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserLogger/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
