using Poseidon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Poseidon.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           //ViewBag.Message = "Welcome to ASP.NET MVC!";
            
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Index(User u)
        {
            // this action is for handle post (login)
            if (ModelState.IsValid) // this is check validity
            {
                using (poseidon_dbEntities dc = new poseidon_dbEntities())
                {
                    
                    var v = dc.User.Where(a => a.user_login.Equals(u.user_login) && a.user_pass.Equals(u.user_pass)).FirstOrDefault();
                    if (v != null)
                    {
                        Session["USERID"] = v.user_id.ToString();
                        Session["USERNAME"] = v.user_name.ToString();
                        Session["COMPANYID"] = v.company_id.ToString();
                        FormsAuthentication.SetAuthCookie(v.user_name.ToString(), true);
                        return RedirectToAction("ListStatus", "Status");
                    }
                    else
                        ModelState.AddModelError("", "Usuario Invalido");
                }
            }
            return View(u);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

     
    }
}
