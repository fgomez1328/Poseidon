using Kendo.Mvc.UI;
using Poseidon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using System.Net.Mail;
using System.Net.Mime;
using System.IO;
using System.Collections;

namespace Poseidon.Controllers
{
    public class StatusController : Controller
    {
        // GET: Status
        public ActionResult ListStatus()
        {
            return View();
        }

        //DATASOURCE LISTA PARA ADMIN 
        public ActionResult ReadStatus([DataSourceRequest] DataSourceRequest request)
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


        //DATASOURCE LISTA PARA ADMIN READY
        public ActionResult ReadStatusOther([DataSourceRequest] DataSourceRequest request)
        {

            return GetViewStatusOther(request);
        }
        private JsonResult GetViewStatusOther(DataSourceRequest request)
        {
            return Json(GetDataStatusOther().ToDataSourceResult(request));
        }
        private IEnumerable<dynamic> GetDataStatusOther()
        {
            poseidon_dbEntities db = new poseidon_dbEntities();

            var result = from a in db.Logger
                         join c in db.User
                           on a.user_instalation equals c.user_id 
                         join b in db.zones
                            on a.zone_id equals b.zone_id into zo
                         from f in zo.DefaultIfEmpty()

                          //from g in zu.DefaultIfEmpty()
                         where a.status == 2 || a.status == 3 || a.status == 4 || a.status == 5 || a.status == 6
                         
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
                             user_instalation = c.user_name,
                             a.approval_date
                         };
            var result2 = result.OrderByDescending(x => x.status);
            return result2;
        }

        
        //DATASOURCE LISTA PARA THECHNICAL PENDING
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
                             f.zone_name,
                             a.instalation_type,
                             a.necessary_key,
                             a.contact_detail,
                             a.status

                         };
           
            return result;
        }

        //DATASOURCE LISTA PARA THECHNICAL ReadProgress
        public ActionResult ReadProgress([DataSourceRequest] DataSourceRequest request)
        {
            return GetViewProgress(request);
        }
        private JsonResult GetViewProgress(DataSourceRequest request)
        {
            return Json(GetDataProgress().ToDataSourceResult(request));
        }
        private IEnumerable<dynamic> GetDataProgress()
        {
            poseidon_dbEntities db = new poseidon_dbEntities();

            var result = from a in db.Logger
                         join c in db.User
                            on a.user_instalation equals c.user_id 
                         join b in db.zones
                            on a.zone_id equals b.zone_id into zo
                         from f in zo.DefaultIfEmpty()
                         
                         where a.status == 2
                         select new
                         {

                             a.logger_id,
                             a.logger_sites_name,
                             a.logger_sms,
                             f.zone_name,
                             user_instalation = c.user_name,
                             a.instalation_type,
                             a.necessary_key,
                             a.user_instalation_start_date,
                             a.contact_detail,
                             a.status
                             
                             //instalador_name = c.user_name

                         };

            return result;
        }


        //DATASOURCE LISTA PARA THECHNICAL READY
        public ActionResult OtherData([DataSourceRequest] DataSourceRequest request)
        {
            return GetView2(request);
        }
        private JsonResult GetView2(DataSourceRequest request)
        {
            return Json(GetData2().ToDataSourceResult(request));
        }

        private IEnumerable<dynamic> GetData2()
        {
            poseidon_dbEntities db = new poseidon_dbEntities();

            var result = from a in db.Logger
                         join c in db.User
                           on a.user_instalation equals c.user_id //into zu
                         join b in db.zones
                            on a.zone_id equals b.zone_id into zo
                         from f in zo.DefaultIfEmpty()
                        
                        // from g in zu.DefaultIfEmpty()
                         where a.status == 3 || a.status == 4 || a.status == 5 || a.status == 6
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
                             a.user_instalation,
                             a.approval_date,
                             instalation_user = c.user_name

                         };
            result = result.OrderByDescending(x => x.status);
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
                        logger_sites_name = lo.logger_sites_name,
                      
                        latitude = lo.latitude,
                        longitute = lo.longitute,
                        creation_date = DateTime.Now,
                        creation_user = Convert.ToInt16(Session["USERID"].ToString()),
                        status = 1,
                        zone_id = lo.zone_id,
                        company_id = Convert.ToInt16(lo.company_id)
                        
                        
                    };

                    northwind.Logger.Add(entity);
                    northwind.SaveChanges();
               
                }
                return RedirectToAction("ListStatus");
            }
            else
            {
                return View();
            }
           
        }

        
        public ActionResult PreviewInstalation(string ID)
        {
            char[] delimiter = {','};
            string[] ids = ID.Split(delimiter);
            string[] new_ids = ID.Split(delimiter);
            ID = null;
            if (ids.Count() == 1)
            {
                Session.Remove("listlogger");
            }
           
            else
            {
                new_ids = ids.Where(w => w != ids[0]).ToArray();
                foreach (string g in new_ids)
                {
                    if (ID == null)
                        ID = g;
                    else
                        ID = ID+","+g;
                }
                Session["listlogger"] = ID;
            }


            int actual_id = Convert.ToInt16(ids[0].ToString());
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
                             dblogger.logger_sites_name = lo.logger_sites_name;
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

        public ActionResult DetailInstalation(int logger_id)
        {
            poseidon_dbEntities db = new poseidon_dbEntities();
            return View("DetailInstalation", db.Logger.Find(logger_id));
          
        }

        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }


        public ActionResult PreviewLoggerFree(int? logger_id)
        {
            poseidon_dbEntities db = new poseidon_dbEntities();

            //var result = from a in db.Logger
            //             join b in db.zones
            //                on a.zone_id equals a.
            //var result= db.Logger.Include()
            return View(db.Logger.Find(logger_id));
        }

        [HttpPost]
        public ActionResult PreviewLoggerFree([DataSourceRequest] DataSourceRequest request, Logger us)
        {

            if (ModelState.IsValid)
            {
                using (var db = new poseidon_dbEntities())
                {
                    var result = from u in db.Logger where (u.logger_id == us.logger_id) select u;
                    if (result.Count() != 0)
                    {
                        var dblogger = result.First();

                        dblogger.logger_sites_name = us.logger_sites_name;
                        //dblogger.necessary_key = us.necessary_key.HasValue;
                        //dblogger.contact_detail = us.contact_detail;
                        //dblogger.key_ball = us.key_ball.HasValue;
                        dblogger.latitude = us.latitude;
                        dblogger.longitute = us.longitute;
                        dblogger.zone_id = us.zone_id;
                 
                        db.SaveChanges();
                    }
                }
            }

            if (Convert.ToInt16(Session["USERTYPE"]) == 1)
                return RedirectToAction("ListStatus", "Status");
            else if (Convert.ToInt16(Session["USERTYPE"]) == 2)
                return RedirectToAction("ListUser", "Status");

            return View();
            
        }


        //DETALLE INSTALACIÓN PARA APROBAR
        public ActionResult InstalationAprobate()
        {
            return View();
        }


        //FORMULARIO PARA COMPLETA INSTALACIÓN
        public ActionResult CreateInstalation(int logger_id)
        {
            poseidon_dbEntities db = new poseidon_dbEntities();
           
            return View("CreateInstalation", db.Logger.Find(logger_id));

        }

        [HttpPost]
        public ActionResult CreateInstalation([DataSourceRequest] DataSourceRequest request, Logger us)
        {

            var errors = ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new { x.Key, x.Value.Errors }).ToArray();

            if (ModelState.IsValid)
            {

                using (var db = new poseidon_dbEntities())
                {
                    var result = from u in db.Logger where (u.logger_id == us.logger_id) select u;
                    if (result.Count() != 0)
                    {
                        var dblogger = result.First();
                        dblogger.logger_id = us.logger_id;
                        dblogger.logger_sites_name = us.logger_sites_name;
                        dblogger.company_id = us.company_id;
                        dblogger.logger_serial_number = us.logger_serial_number;
                        dblogger.necesary_site_enter = us.necesary_site_enter;
                        dblogger.instalation_type_logger = us.instalation_type_logger;
                        dblogger.logger_sms = us.logger_sms;
                        dblogger.type_company_sms = us.type_company_sms;
                        dblogger.conditions_installation = us.conditions_installation;
                        dblogger.logger_outdoor = us.logger_outdoor;


                        dblogger.logger_position = us.logger_position;
                        dblogger.necessary_drain = us.necessary_drain;
                        dblogger.flooded_chamber = us.flooded_chamber;
                        dblogger.necessary_manipulate_traffic = us.necessary_manipulate_traffic;
                        dblogger.chamber_type = us.chamber_type;
                        dblogger.necessary_tool_open_chamber = us.necessary_tool_open_chamber;
                        dblogger.chamber_condition = us.chamber_condition;
                        dblogger.chamber_type_tap = us.chamber_type_tap;
                        dblogger.two_thechnical_open_chamber = us.two_thechnical_open_chamber;

                        
                        dblogger.antenna_position = us.antenna_position;
                        dblogger.antenna_type = us.antenna_type;
                        dblogger.gprs_test_status = us.gprs_test_status;
                        dblogger.can_lamppost_with_antenna = dblogger.can_lamppost_with_antenna;
                        dblogger.final_csq = us.final_csq;
                        dblogger.Csq_outdoor = us.Csq_outdoor;



                        dblogger.instalation_type = us.instalation_type;
                        dblogger.state_flowmeter = us.state_flowmeter;
                        dblogger.manometer_aab_value = us.manometer_aab_value;
                        dblogger.type_flowmeter = us.type_flowmeter;
                        dblogger.logger_aar_value = us.logger_aar_value;
                        dblogger.with_pulser = us.with_pulser;
                        dblogger.manometer_aar_value = us.manometer_aar_value;
                        dblogger.pulser_changed = us.pulser_changed;
                        dblogger.logger_aab_value = us.logger_aab_value;
                        dblogger.liters_per_pulser = us.liters_per_pulser;


                        dblogger.channel_1 = us.channel_1;
                        dblogger.channel_2 = us.channel_2;
                        dblogger.channel_3 = us.channel_3;
                        dblogger.channel_4 = us.channel_4;


                        dblogger.logger_type = us.logger_type;
                        dblogger.battery_installed = us.battery_installed;
                        dblogger.battery_type = us.battery_type;
                        dblogger.battery_serial_number = us.battery_serial_number;



                        if (Session["PictureUrl"] != null)
                        {
                            dblogger.url_image = Convert.ToString(Session["PictureUrl"]);
                            Session.Remove("PictureUrl");
                        }
                        dblogger.notes = us.notes;
                        dblogger.user_instalation_end_date = us.user_instalation_end_date;
                        
                        dblogger.status = 3;
                        dblogger.user_instalation = Convert.ToInt16(Session["USERID"].ToString());

                    
                        db.SaveChanges();

                        //dblogger.elevation = us.elevation;
                        //dblogger.condition_type_instalation = us.condition_type_instalation;

                    }

                }
            }


            return RedirectToAction("ListUser", "Status");
        }


        //FORMULARIO PARA EDITAR COMPLETAR INSTALACIÓN
        public ActionResult EditInstalation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditInstalation([DataSourceRequest] DataSourceRequest request, Logger log)
        {
            // Test if company object and modelstate is valid.

            var db = new poseidon_dbEntities();
            if (log != null && ModelState.IsValid)
            {
                // Update company to UoW.

                // Save updated company to database using UoW.
                db.SaveChanges();
            }
            // Return modelstate info back to client side in json format.
            return Json(ModelState.ToDataSourceResult());
        }

        public ActionResult LoggerApprove(int? logger_id)
        {
            poseidon_dbEntities db = new poseidon_dbEntities();

            

            return View(db.Logger.Find(logger_id));
        }

         [HttpPost]
        public ActionResult LoggerApprove([DataSourceRequest] DataSourceRequest request, Logger us)
        {
            string to_name ="",to_email = "",logger_sites_name = "",zone_name = ""
            , logger_sms = "", logger_csq = "", user_instalation = "", user_instalation_start_date = "", user_instalation_end_date = ""
            , company_name="", url_image ="";
             ArrayList user_cc_list = new ArrayList();
              List<string> list_email = new List<string>();


          if (ModelState.IsValid)
            {
                
                using (var db = new poseidon_dbEntities())
                {
                    var result = from u in db.Logger where (u.logger_id == us.logger_id) select u;
                    if (result.Count() != 0)
                    {
                        var dblogger = result.First();

                        dblogger.status = us.status;
                        dblogger.user_approval_note = us.user_approval_note;
                        dblogger.approval_date = DateTime.Now;
                        
                        
                        db.SaveChanges();

                        logger_sites_name =dblogger.logger_sites_name ;
                        zone_name =dblogger.zones.zone_name;
                        logger_sms = dblogger.logger_sms;
                        user_instalation_start_date= dblogger.user_instalation_start_date.ToString();
                        user_instalation_end_date = dblogger.user_instalation_end_date.ToString();
                        user_instalation= dblogger.User.user_name.ToString();
                        if(dblogger.url_image != null)
                            url_image = dblogger.url_image;
                        else
                            url_image = "noimage.png";

                        logger_csq = dblogger.final_csq.ToString();
                        //COMPANY
                         var company_from = from u in db.Company where (u.company_id == dblogger.company_id) select u;
                            company_name = company_from.First().company_name;

                        //FROM
                        var user_from  = from u in db.Customers where (u.customer_company_id == dblogger.company_id && u.cc == false) select u;
                        var detail_user_from = user_from.First();

                        //CC
                        var user_cc = from u in db.Customers where (u.cc == true && u.customer_company_id == dblogger.company_id || u.customer_company_id == null) select u;
                         list_email = user_cc.Select(x => x.customer_email).Distinct().ToList();
                        user_cc_list = new ArrayList(user_cc.ToList());
                        int d = user_cc.Count();

                        to_name = detail_user_from.customer_name;//"Jonathan"; 
                        to_email = detail_user_from.customer_email; //"jherrera@dnkwater.com";//
                    }
                }
                
                int aprueba = us.status.Value;

                string host = Path.GetFileName(Request.Url.Host);
                host = "http://"+host+"/Poseidon/Images/"+url_image;
                

                    MailMessage mail = new MailMessage();
                 
                    mail.From = new MailAddress("instalaciones@dnkwater.com", "Instalaciones Dnk Water", System.Text.Encoding.UTF8);
                    mail.Subject = "★ Notificación de termino de instalación " + company_name + " - " + logger_sites_name;//titulo
                    mail.SubjectEncoding = System.Text.Encoding.UTF8;
                    string body = "";
                    if (aprueba == 4)
                    {
                        body = @"<div style='padding:10px 0'>
                            <table style='width:100%' cellpadding='0' cellspacing='0'>
                            <tbody>
                                <tr>
                                <td>
                                    <a href='http://www.dnk-water.com' target='_blank'>
                                        <img src='http://158.85.25.234/Poseidon/Content//images/dnk_logo.png' style='border:0;width:150px; height:100px' class='CToWUd'>
                                    </a>
                                 </td>
                                </tr>
                             </tbody>
                            </table>
                        </div>
                        <div style='background-color:#4285f4;color:white;font:20px arial,normal;padding:23px 20px'>La instalación se realizó con éxito</div>
                        <div style='background-color:#f5f5f5;margin-bottom:15px;padding:20px 30px 20px 30px'>
                            <div style='max-width:520px'>
                                <div style='background-color:white;border:1px solid #dadada;border-bottom-width:2px;border-top:none'>
                                    <div style='padding:14px'>
                                         <table>
                                            <tbody>                                                
                                                <tr>
                                                    <td>
                                                    <h3>Cliente: " + company_name + @"</h3>
                                                    <h3>Atn: " + to_name + @"</h3>
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td> 
                                                        <h4>Este correo describe la instalación del siguiente equipo</h4>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>

                                        <table style='width:100%' cellpadding='0' cellspacing='0'>
                                            <tbody>
                                                <tr>
                                                    <td style='width:90px'>Ubicación</td>
                                                    <td>:</td>
                                                    <td style='padding-left:14px'>
                                                       " + logger_sites_name +
                                                  @" </td>
                                                </tr>
                                                <tr>
                                                    <td style='width:90px'>Localidad</td>
                                                    <td>:</td>
                                                    <td style='padding-left:14px'>
                                                         " + zone_name +
                                                  @" </td>
                                                </tr>
                                                <tr>
                                                    <td style='width:90px'>SMS</td>
                                                    <td>:</td>
                                                    <td style='padding-left:14px'>
                                                        " + logger_sms +
                                                   @"</td>
                                                </tr>
                                                <tr>
                                                    <td style='width:90px'>CSQ</td>
                                                    <td>:</td>
                                                    <td style='padding-left:14px'>
                                                        " + logger_csq +
                                                  @" </td>
                                                </tr>
                                        </tbody>
                                    </table>
                     <br />
                                    <table>
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <h4>Detalle de instalación</h4> 
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>

                                     <table style='width:100%' cellpadding='0' cellspacing='0'>
                                                        <tbody>
                                                            <tr>
                                                                <td style='width:150px'>Fecha inicio instalación</td>
                                                                <td>:</td>
                                                                <td style='padding-left:14px'>
                                                                    " + user_instalation_start_date +
                                                                @"</td>
                                                            </tr>
                                                            <tr>
                                                                <td style='width:150px'>Fecha termino instalación</td>
                                                                <td>:</td>
                                                                <td style='padding-left:14px'>
                                                                    " + user_instalation_end_date +
                                                                @"</td>
                                                            </tr>
                                                            <tr>
                                                                <td style='width:150px'>Instalado por</td>
                                                                <td>:</td>
                                                                <td style='padding-left:14px'>
                                                                    " + user_instalation +
                                                               @" </td>
                                                            </tr>
                                                            <tr>
                                                                <td style='width:150px'>Comentario instalación</td>
                                                                <td>:</td>
                                                                <td style='padding-left:14px'>
                                                                    " + us.user_approval_note +
                                                                @" </td>
                                                            </tr>
                                                            <tr>
                                                                <td style='width:150px'>
                                                                    Presione en Ver para visulizar detalle de la instalación
                                                                </td>
                                                                <td>:</td>
                                                                <td>
                                                                    <a href='http://158.85.25.234/Poseidon/Status/DetailInstalation?logger_id=" +us.logger_id +@"'>Ver</a> 
                                                                </td>
                                                            </tr>
                                                           
                                                        </tbody>
                                                    </table>
                                                    <table>
                                                        <tbody>
                                                            <tr>
                                                                <td style='width:150px'>Imagen de instalación</td>
                                                                <td>
                                                                 <br/>
                                                                   <img src='" + host + @"' width='250' height='200'>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                        </div>
                                 </div>
                        </div>
© 2015 - DNK Water - Poseidon System
                </div>

                        ";
                    }
                    else if(aprueba == 5)
                    {
                        body = @"<div style='padding:10px 0'>
                            <table style='width:100%' cellpadding='0' cellspacing='0'>
                            <tbody>
                                <tr>
                                <td>
                                    <a href='http://www.dnk-water.com' target='_blank'>
                                        <img src='http://158.85.25.234/Poseidon/Content//images/dnk_logo.png' style='border:0;width:150px; height:100px' class='CToWUd'>
                                 </td>
                                    </a>
                             </tbody>
                            </table>
                        </div>
                                </tr>
                        <div style='background-color:#F47025;color:white;font:20px arial,normal;padding:23px 20px'>Equipo Instalado pero no Conectado </div>
                        <div style='background-color:#f5f5f5;margin-bottom:15px;padding:20px 30px 20px 30px'>
                            <div style='max-width:520px'>
                                <div style='background-color:white;border:1px solid #dadada;border-bottom-width:2px;border-top:none'>
                                    <div style='padding:14px'>
                                       <table>
                                            <tbody>                                                
                                                <tr>
                                                    <td>
                                                    <h3>Cliente: " + company_name + @"</h3>
                                                    <h3>Atn: " + to_name + @"</h3>
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td> 
                                                        <h4>Este correo describe la instalación del siguiente equipo</h4>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>

                                        <table style='width:100%' cellpadding='0' cellspacing='0'>
                                            <tbody>
                                                <tr>
                                                    <td style='width:90px'>Ubicación</td>
                                                    <td>:</td>
                                                    <td style='padding-left:14px'>
                                                       " + logger_sites_name +
                           @" </td>
                                                </tr>
                                                <tr>
                                                    <td style='width:90px'>Localidad</td>
                                                    <td>:</td>
                                                    <td style='padding-left:14px'>
                                                         " + zone_name +
                           @" </td>
                                                </tr>
                                                <tr>
                                                    <td style='width:90px'>SMS</td>
                                                    <td>:</td>
                                                    <td style='padding-left:14px'>
                                                        " + logger_sms +
                            @"</td>
                                                </tr>
                                                <tr>
                                                    <td style='width:90px'>CSQ</td>
                                                    <td>:</td>
                                                    <td style='padding-left:14px'>
                                                        " + logger_csq +
                           @" </td>
                                                </tr>
                                        </tbody>
                                    </table>
                     <br />
                                    <table>
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <h4>Donde el equipo obtuvo el siguiente resultado:</h4>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>

                                     <table style='width:100%' cellpadding='0' cellspacing='0'>
                                                        <tbody>
                                                            <tr>
                                                                <td style='width:150px'>Fecha inicio instalación</td>
                                                                <td>:</td>
                                                                <td style='padding-left:14px'>
                                                                    " + user_instalation_start_date +
                                         @"</td>
                                                            </tr>
                                                            <tr>
                                                                <td style='width:150px'>Fecha termino instalación</td>
                                                                <td>:</td>
                                                                <td style='padding-left:14px'>
                                                                    " + user_instalation_end_date +
                                         @"</td>
                                                            </tr>
                                                            <tr>
                                                                <td style='width:150px'>Instalado por</td>
                                                                <td>:</td>
                                                                <td style='padding-left:14px'>
                                                                    " + user_instalation +
                                        @" </td>
                                                            </tr>
                                                            <tr>
                                                                <td style='width:150px'>Comentario instalación</td>
                                                                <td>:</td>
                                                                <td style='padding-left:14px'>
                                                                    " + us.user_approval_note +
                                         @" </td>
                                                            </tr>
                                                            <tr>
                                                                <td style='width:150px'>
                                                                    Presione en Ver para visulizar detalle de la instalación
                                                                </td>
                                                                <td>:</td>
                                                                <td>
                                                                    <a href='http://158.85.25.234/Poseidon/Status/DetailInstalation?logger_id=" + us.logger_id + @"'>Ver</a> 
                                                                </td>
                                                            </tr>
                                                           
                                                           
                                                        </tbody>
                                                    </table>
                                                    <table>
                                                        <tbody>
                                                            <tr>
                                                                <td style='width:150px'>Imagen de instalación</td>
                                                                <td>
                                                                   <img src='" + host + @"' width='250' height='200'>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                        </div>
                                    </div>
                                    </div>
                        © 2015 - DNK Water - Poseidon System
                            </div>

                        ";
                    }
                    else if (aprueba == 6)
                    {
                        body = @"<div style='padding:10px 0'>
                            <table style='width:100%' cellpadding='0' cellspacing='0'>
                            <tbody>
                                <tr>
                                <td>
                                    <a href='http://www.dnk-water.com' target='_blank'>
                                        <img src='http://158.85.25.234/Poseidon/Content//images/dnk_logo.png' style='border:0;width:150px; height:100px' class='CToWUd'>
                                    </a>
                                 </td>
                                </tr>
                             </tbody>
                            </table>
                        </div>
                        <div style='background-color:#DC191F;color:white;font:20px arial,normal;padding:23px 20px'>La instalación no pudo Realizarse </div>
                        <div style='background-color:#f5f5f5;margin-bottom:15px;padding:20px 30px 20px 30px'>
                            <div style='max-width:520px'>
                                <div style='background-color:white;border:1px solid #dadada;border-bottom-width:2px;border-top:none'>
                                    <div style='padding:14px'>
                                       <table>
                                            <tbody>                                                
                                                <tr>
                                                    <td>
                                                    <h3>Cliente: " + company_name + @"</h3>
                                                    <h3>Atn: " + to_name + @"</h3>
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td> 
                                                        <h4>Este correo describe la instalación del siguiente equipo</h4>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>

                                        <table style='width:100%' cellpadding='0' cellspacing='0'>
                                            <tbody>
                                                <tr>
                                                    <td style='width:90px'>Ubicación</td>
                                                    <td>:</td>
                                                    <td style='padding-left:14px'>
                                                       " + logger_sites_name +
                           @" </td>
                                                </tr>
                                                <tr>
                                                    <td style='width:90px'>Localidad</td>
                                                    <td>:</td>
                                                    <td style='padding-left:14px'>
                                                         " + zone_name +
                           @" </td>
                                                </tr>
                                                <tr>
                                                    <td style='width:90px'>SMS</td>
                                                    <td>:</td>
                                                    <td style='padding-left:14px'>
                                                        " + logger_sms +
                            @"</td>
                                                </tr>
                                                <tr>
                                                    <td style='width:90px'>CSQ</td>
                                                    <td>:</td>
                                                    <td style='padding-left:14px'>
                                                        " + logger_csq +
                           @" </td>
                                                </tr>
                                        </tbody>
                                    </table>
                     <br />
                                    <table>
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <h4>Donde el equipo obtuvo el siguiente resultado:</h4>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>

                                     <table style='width:100%' cellpadding='0' cellspacing='0'>
                                                        <tbody>
                                                            <tr>
                                                                <td style='width:150px'>Fecha inicio instalación</td>
                                                                <td>:</td>
                                                                <td style='padding-left:14px'>
                                                                    " + user_instalation_start_date +
                                         @"</td>
                                                            </tr>
                                                            <tr>
                                                                <td style='width:150px'>Fecha termino instalación</td>
                                                                <td>:</td>
                                                                <td style='padding-left:14px'>
                                                                    " + user_instalation_end_date +
                                         @"</td>
                                                            </tr>
                                                            <tr>
                                                                <td style='width:150px'>Instalado por</td>
                                                                <td>:</td>
                                                                <td style='padding-left:14px'>
                                                                    " + user_instalation +
                                        @" </td>
                                                            </tr>
                                                            <tr>
                                                                <td style='width:150px'>Comentario instalación</td>
                                                                <td>:</td>
                                                                <td style='padding-left:14px'>
                                                                    " + us.user_approval_note +
                                         @" </td>
                                                            </tr>
                                                            <tr>
                                                                <td style='width:150px'>
                                                                    Presione en Ver para visulizar detalle de la instalación
                                                                </td>
                                                                <td>:</td>
                                                                <td>
                                                                    <a href='http://158.85.25.234/Poseidon/Status/DetailInstalation?logger_id=" + us.logger_id + @"'>Ver</a> 
                                                                </td>
                                                            </tr>
                                                           
                                                           
                                                        </tbody>
                                                    </table>
                                                    <table>
                                                        <tbody>
                                                            <tr>
                                                                <td style='width:150px'>Imagen de instalación</td>
                                                                <td>
                                                                   <img src='" + host + @"' width='250' height='200'>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                        </div>
                                    </div>
                                    </div>
                        © 2015 - DNK Water - Poseidon System
                            </div>

                        ";
                    }

                    AlternateView htmlView = AlternateView.CreateAlternateViewFromString(body, new ContentType("text/html"));

                    mail.AlternateViews.Add(htmlView);
                    mail.To.Add(to_email);

                    if (user_cc_list != null)
                    {
                        for (int i = 0; i < list_email.Count; i++)
                        {
                            mail.CC.Add(list_email[i].ToString());
                        }

                    }
                    mail.Priority = MailPriority.High;

                    SmtpClient smtp = new SmtpClient();
                    smtp.Credentials = new System.Net.NetworkCredential("instalaciones@dnkwater.com", "dnkinstalaciones2015");

                    smtp.Port = 587;//puerto
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    smtp.Send(mail);


                
               
            }

          return RedirectToAction("ListStatus", "Status");
            
        }



    }
}