using Poseidon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Poseidon.Controllers
{
    public class HelperController : Controller
    {
        // GET: Helper
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetZone()
        {
            var db = new poseidon_dbEntities();

            var rol_result = from a in db.zones

                             select new
                             {
                                 a.zone_id,
                                 a.zone_name
                             };

            return Json(rol_result.Select(o => new { o.zone_id, o.zone_name }), JsonRequestBehavior.AllowGet);
        }
    }
}