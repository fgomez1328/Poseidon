using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using Poseidon.Models;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using System.Diagnostics;
using System.Data;
using Kendo.Mvc.Extensions;
using System.Net.Mail;
using System.Net.Mime;


namespace Poseidon.Controllers
{
    public class UserLoggerController : Controller
    {
        // GET: UserLogger
        List<Logger> datamap1;


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
            int company_id =Convert.ToInt32(Session["COMPANYID"].ToString());

            var result = from a in db.Logger
                         join b in db.zones
                            on a.zone_id equals b.zone_id into zo
                         from f in zo.DefaultIfEmpty()
                         join c in db.User
                            on a.user_instalation equals c.user_id into zu
                            from g in zu.DefaultIfEmpty()
                         where a.company_id == company_id
                         select new
                         {
                             a.logger_id,
                             a.logger_sites_name,
                             a.logger_sms,
                             f.zone_name,
                             a.instalation_type,
                             a.necessary_key,
                             a.contact_detail,
                             a.status,
                             a.user_instalation_start_date,
                             a.user_instalation_end_date,
                             a.approval_date,
                             user_instalation = g.user_name

                         };

            return result;
        }

        public List<Logger> DatMapaZona()
        {

            datamap1 = new System.Collections.Generic.List<Logger>();
            DataSet ds = new DataSet();

            int company_id = 3;//Convert.ToInt16(Session["COMPANYID"].ToString());

            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
            {
                using (SqlCommand cmd1 = new SqlCommand())
                {

                    cmd1.CommandText = @" SELECT a.latitude,a.longitute,a.status ,a.logger_sites_name, b.company_name
                    From Logger a left outer join Company b on a.company_id = b.company_id
                    WHERE  a.latitude IS NOT NULL and a.longitute IS NOT NULL 
                    and a.status IS NOT NULL
                    and a.company_id ="+company_id+@"";


                    cmd1.Connection = con1;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd1))
                    {

                        da.Fill(ds, "MapsGraph1");

                    }

                }

            }


            if (ds != null)
            {

                if (ds.Tables.Count > 0)
                {

                    if (ds.Tables["MapsGraph1"].Rows.Count > 0)
                    {

                        foreach (DataRow dr in ds.Tables["MapsGraph1"].Rows)
                        {

                                datamap1.Add(new Logger
                                {
                                    latitude = (dr["latitude"].ToString()),
                                    longitute = (dr["longitute"].ToString()),
                                    status = Convert.ToInt16(dr["status"].ToString()),
                                    logger_sites_name = (dr["logger_sites_name"].ToString()),
                                    logger_serial_number = (dr["company_name"].ToString()),

                                });

                        }

                    }

                }

            }


            return datamap1;

        }


        [HttpPost]
        public ActionResult MapDetail()
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(DatMapaZona());


            return Json(DatMapaZona(), JsonRequestBehavior.AllowGet);

        }



        public ActionResult MapAll()
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
                             a.latitude,
                             a.longitute,
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

        //ERROR CORRECTION
        public ActionResult ErrorCorrection(int logger_id)
        {
            poseidon_dbEntities db = new poseidon_dbEntities();
            return View("ErrorCorrection", db.Logger.Find(logger_id));
            
        }

         [HttpPost]
         public ActionResult ErrorCorrection([DataSourceRequest] DataSourceRequest request, Logger us, FormCollection colletion)
        {
            if (ModelState.IsValid)
            {
                string to_name = "", to_email = "", logger_sites_name = "", zone_name = ""
           , logger_sms = "", company_name = "";

                using (var db = new poseidon_dbEntities())
                {
                    string myCheckBoxValue = Request.Form["Check"].ToString();
                    string[] selectedList = myCheckBoxValue.Split(',');
                    Boolean error_value = Convert.ToBoolean(selectedList[0]);

                    if (error_value == true)
                    {
                        var result = from u in db.Logger where (u.logger_id == us.logger_id) select u;
                        if (result.Count() != 0)
                        {
                            var dblogger = result.First();
                            dblogger.status = 1;
                            
                            db.SaveChanges();

                            logger_sites_name = dblogger.logger_sites_name;
                            zone_name = dblogger.zone_name;
                            logger_sms = dblogger.logger_sms.ToString();

                            var company_from = from u in db.Company where (u.company_id == dblogger.company_id) select u;
                            company_name = company_from.First().company_name;

                            var user_from = from u in db.Customers where (u.customer_company_id == dblogger.company_id && u.cc.HasValue == true) select u;
                            var detail_user_from = user_from.First();

                            to_name = "Jonathan"; //detail_user_from.customer_name;
                            to_email = "jherrera@dnkwater.com";// detail_user_from.customer_email;
                        }
                    }
                }

                MailMessage mail = new MailMessage();

                mail.From = new MailAddress("instalaciones@dnkwater.com", "Instalaciones", System.Text.Encoding.UTF8);
                mail.Subject = "Notificación Corrección de problema - "+company_name;//titulo
                mail.SubjectEncoding = System.Text.Encoding.UTF8;
                string body = "";


                    body = @"<p><h3>Estimado(a) " + to_name + ",</h3><p>" +
                          "<p></p><p>Se ha generado el siguiente email para notificar que el problema de instalación detectado se ha solucionado:" +
                          "<p>Ubicación:" + logger_sites_name +
                          "<p>Localidad:" + logger_sites_name +
                          "<p>Región:" + zone_name +
                          "<p>SMS:" + logger_sms;

                    AlternateView htmlView = AlternateView.CreateAlternateViewFromString(body, new ContentType("text/html"));

                    mail.AlternateViews.Add(htmlView);
                    mail.To.Add(to_email);
                    mail.CC.Add("jo.herrera.gomez@gmail.com");
                    mail.Priority = MailPriority.High;

                    SmtpClient smtp = new SmtpClient();
                    smtp.Credentials = new System.Net.NetworkCredential("instalaciones@dnkwater.com", "dnkinstalaciones2015");

                    smtp.Port = 587;//puerto
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
            }


            return RedirectToAction("ListLogger", "UserLogger");
        }
    }
}
