using Poseidon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Poseidon.Controllers
{
    public class StatusController : Controller
    {
        // GET: Status
        public ActionResult ListStatus()
        {
            DataClasses1DataContext context = new DataClasses1DataContext();

            return View();
        }
    }
}