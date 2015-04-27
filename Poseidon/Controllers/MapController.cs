using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Poseidon.Models;

namespace Poseidon.Controllers
{
    public class MapController : Controller
    {
        // GET: Map
        public ActionResult LoggerList()
        {
            return View();
        }

        //DATASOURCE LISTA PARA ADMIN 
        public ActionResult ReadLogger([DataSourceRequest] DataSourceRequest request)
        {
            return GetViewStatus(request);
        }
        private JsonResult GetViewStatus(DataSourceRequest request)
        {
            return Json(GetDataStatus().ToDataSourceResult(request));
        }
        private IEnumerable<dynamic> GetDataStatus()
        {
            poseidon_dbEntities db = new poseidon_dbEntities();

            var result = from a in db.Logger
                         join b in db.zones
                            on a.zone_id equals b.zone_id into zo
                         from f in zo.DefaultIfEmpty()
                         join c in db.User
                            on a.user_instalation equals c.user_id into zu
                         from g in zu.DefaultIfEmpty()
                         join d in db.Company
                            on a.company_id equals d.company_id
                         select new
                         {
                             a.logger_id,
                             a.logger_sites_name,
                             f.zone_name,
                             a.status,
                             a.user_instalation_start_date,
                             a.approval_date,
                             user_instalation = g.user_name,
                             company_id = d.company_name,

                         };

            return result;
        }
    }
}