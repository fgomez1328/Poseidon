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
                             //b.zone_id,
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
                        status = 1,
                        company_id = Convert.ToInt16(Session["COMPANYID"].ToString())
                        
                        
                    };

                    northwind.Logger.Add(entity);
                    northwind.SaveChanges();
               
                }
            }

            return View();
        }

        public ActionResult PreviewInstalation()
        {
            return View();
        }
    }
}