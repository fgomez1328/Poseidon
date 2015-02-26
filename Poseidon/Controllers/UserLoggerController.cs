using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using Poseidon.Models;
using System;
using Kendo.Mvc.Extensions;
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


        public ActionResult ListLoggerTot()
        {




            return View();



        }










        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return GetView(request);
        }
        private JsonResult GetView(DataSourceRequest request)
        {
            return Json(GetData().ToDataSourceResult(request));
        }
        private IEnumerable<dynamic> GetData()
        {
            poseidon_dbEntities db = new poseidon_dbEntities();

            var result = from a in db.Logger
                         join b in db.zones
                            on a.zone_id equals b.zone_id into zo
                         from f in zo.DefaultIfEmpty()
                         where a.status == 1
                         select new
                         {

                             a.logger_id,
                             a.logger_sites_name,
                             a.logger_sms,
                             f.zone_name,
                             a.instalation_type,
                             a.necessary_key,
                             a.contact_detail,
                             a.status

                         };

            return result;
        }

        public ActionResult Read1([DataSourceRequest] DataSourceRequest request)
        {
            return GetView1(request);
        }
        private JsonResult GetView1(DataSourceRequest request)
        {
            return Json(GetData1().ToDataSourceResult(request));
        }
        private IEnumerable<dynamic> GetData1()
        {
            poseidon_dbEntities db = new poseidon_dbEntities();

            var result = from a in db.Logger
                         join b in db.zones
                            on a.zone_id equals b.zone_id into zo
                         from f in zo.DefaultIfEmpty()
                         where a.status == 1
                         select new
                         {

                             a.logger_id,
                             a.logger_sites_name,
                             a.logger_sms,
                             f.zone_name,
                             a.instalation_type,
                             a.necessary_key,
                             a.contact_detail,
                             a.status

                         };

            return result;
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
