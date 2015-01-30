using Kendo.Mvc.UI;
using Poseidon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;

namespace Poseidon.Controllers
{
    public class StatusController : Controller
    {
        // GET: Status
        public ActionResult ListStatus()
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
                         //join b in db.Zone
                         //   on a.zone_id equals b.zone_id
                         select new
                         {

                             a.logger_id,
                             a.logger_sites_name,
                             a.logger_sms,   
                             //b.zone_name,
                             a.instalation_type,
                             a.necessary_key,
                             a.contact_detail,
                             a.status

                         };
           
            return result;
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Logger lo)
        {

            if (ModelState.IsValid)
            {
                using (var northwind = new poseidon_dbEntities())
                {
                    //Get max ID table loggers
                    var crum = 0;
                    try
                    {
                         crum = northwind.Logger.Max(sd => sd.logger_id);
                    }
                    catch
                    {
                        crum = 0;
                    }

                    int current_id = Convert.ToInt32(crum.ToString());

                    var entity = new Logger
                    {
                        logger_id = current_id+1,
                        logger_sites_name = lo.sites_name,
                        logger_sms = lo.logger_sms,
                        necessary_key = lo.necessary_key,
                        contact_detail = lo.contact_detail,
                        key_ball = lo.key_ball,
                        latitude = lo.latitude,
                        longitute = lo.longitute,
                        creation_date = DateTime.Now,
                        creation_user = Convert.ToInt16(Session["USERID"].ToString()),
                        status = 1,
                        zone_id = lo.zone_id,
                        company_id = Convert.ToInt16(Session["COMPANYID"].ToString())
                        
                        
                    };

                    northwind.Logger.Add(entity);
                    northwind.SaveChanges();
               
                }
            }

            return View();
        }

        
        public ActionResult PreviewInstalation(string ID)
        {

            if (ID.Length == 1)
            {
                Session.Remove("listlogger");
            }
            else if  (ID.Length < 4)
            {
                Session["listlogger"] = ID.Substring(2); 
            }
            else
            {
                Session["listlogger"] = ID.Substring(2, ID.Length - 1);
            }


            int actual_id = Convert.ToInt16(ID[0].ToString());
            poseidon_dbEntities db = new poseidon_dbEntities();

           
            return View(db.Logger.Find(actual_id));
        }

        [HttpPost]
        public ActionResult PreviewInstalation([DataSourceRequest] DataSourceRequest request, Logger lo){
                if (ModelState.IsValid)
                {
                    using (var db = new poseidon_dbEntities())
                    {
                        var result = from u in db.Logger where (u.logger_id == lo.logger_id) select u;
                         if (result.Count() != 0)
                         {
                             var dblogger = result.First();

                             dblogger.status = 2;
                             dblogger.user_instalation = Convert.ToInt16(Session["USERID"].ToString());
                             dblogger.user_instalation_start_date = lo.user_instalation_start_date;
                             dblogger.user_instalation_end_date = lo.user_instalation_end_date;
                             db.SaveChanges();
                         }
                    }
                }

                if (Session["listlogger"] != null)
                {
                    return RedirectToAction("PreviewInstalation", new { ID = Session["listlogger"].ToString() });
                }
                else
                    return RedirectToAction("ListUser");
        }

        public ActionResult ListUser()
        {
            return View();
        }

        public ActionResult DetailInstalation()
        {
            return View();
        }
    }
}