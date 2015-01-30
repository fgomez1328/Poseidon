using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Net;
using System.Diagnostics;
using Poseidon.Models;
using System.Web.Security;

namespace Poseidon.Controllers
{

     [HiddenInput(DisplayValue = false)]
    public class PictureViewModel
    {
        public int PictureId { get; set; }
        public string PictureName { get; set; }
        public string PictureUrl { get; set; }
        public bool Status { get; set; }
    }
    
    
    
    
    
    public class HomeController : Controller
    {

        const string server = "ftp://172.16.189.209/";
        static NetworkCredential credentials = new NetworkCredential("IUSR", "poseidon");

        const string document = "Documento.pdf";
        static string uploads = Environment.CurrentDirectory + @"\Subidas\";
        static string downloads = Environment.CurrentDirectory + @"\Descargas\";



        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

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

                        if (v.user_type_id == 1)
                            return RedirectToAction("ListStatus", "Status");
                        else if (v.user_type_id == 2)
                            return RedirectToAction("ListUser", "Status");
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

        public ActionResult Formulario()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        // Subida de Archivos
        public static void UpLoadImage(Stream image, string target)
        {
            FtpWebRequest req = (FtpWebRequest)WebRequest.Create("ftp://172.16.189.209/ImagenPoseidon/" + target);
            req.UseBinary = true;
            req.Method = WebRequestMethods.Ftp.UploadFile;
            req.Credentials = new NetworkCredential("IUSR", "poseidon");
            byte[] fileBytes = System.IO.File.ReadAllBytes("c:/folder/myfile.ext");

          
            req.ContentLength = fileBytes.Length;
            Stream reqStream = req.GetRequestStream();
            reqStream.Write(fileBytes, 0, fileBytes.Length);
            reqStream.Close();
        }




        // Listado de Directorios
        public static void ListDirectory()
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(server);
            request.Credentials = credentials;
            request.Method = WebRequestMethods.Ftp.ListDirectory;

            using (StreamReader reader = new StreamReader(((FtpWebResponse)request.GetResponse()).GetResponseStream()))
            {
                Console.WriteLine(reader.ReadToEnd());
                reader.Close();
            }

            Console.Read();
        }



        // Descargas de Archivos
        public static void DownloadFile()
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(server + document);
            request.Credentials = credentials;
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            using (MemoryStream stream = new MemoryStream())
            {
                ((FtpWebResponse)request.GetResponse()).GetResponseStream().CopyTo(stream);
               System.IO.File.WriteAllBytes(downloads + document, stream.ToArray());
            }
        }

        // Borrado de Archivos
        public static void DeleteFile()
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(server + document);
            request.Credentials = credentials;
            request.Method = WebRequestMethods.Ftp.DeleteFile;

            request.GetResponse();
        }


        public ActionResult Save(IEnumerable<HttpPostedFileBase> files)
        {
            var pictureViewModel = new PictureViewModel();
            // The Name of the Upload component is "files"
           
            
            if (files != null)
            {
                foreach (var file in files)
                {
                    // Some browsers send file names with full path.
                    // We are only interested in the file name.
                    var fileName = Path.GetFileName(file.FileName);
                    var physicalPath = Path.Combine("C:/ImagenPoseidon", fileName);
                    ViewBag.ImageURL = "C:/ImagenPoseidon" + fileName;
                    // The files are not actually saved in this demo

                 
                    file.SaveAs(physicalPath);

                    string pictureUrl = @"C:/ImagenPoseidon/" + fileName;
                  
                    pictureViewModel.PictureId = 1;
                    pictureViewModel.PictureName = fileName;
                    pictureViewModel.PictureUrl = pictureUrl;
                    pictureViewModel.Status = true;
                }
            }

            // Return an empty string to signify success
         
            return Json(pictureViewModel, JsonRequestBehavior.AllowGet);
        }
 
        public ActionResult Remove(string[] fileNames)
        {
            var pictureViewModel = new PictureViewModel();

            // The parameter of the Remove action must be called "fileNames"

            if (fileNames != null)
            {
                foreach (var fullName in fileNames)
                {
                    var fileName = Path.GetFileName(fullName);
                    var physicalPath = Path.Combine("C:/ImagenPoseidon", fileName);
                   
                  
                    // TODO: Verify user permissions
                    
                    if (System.IO.File.Exists(physicalPath))
                    {
                        // The files are not actually removed in this demo
                        System.IO.File.Delete(physicalPath);

                        string pictureUrl = @"~/Content/Images/loading.gif";

                        pictureViewModel.PictureId = 1;
                        pictureViewModel.PictureName = fileName;
                        pictureViewModel.PictureUrl = pictureUrl;
                        pictureViewModel.Status = false;
                    }
                }
            }

            // Return an empty string to signify success

            return Json(pictureViewModel, JsonRequestBehavior.AllowGet);
        }


    }


}
