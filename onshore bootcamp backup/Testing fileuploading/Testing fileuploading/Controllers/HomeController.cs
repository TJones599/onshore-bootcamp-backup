using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Testing_fileuploading.Models;

namespace Testing_fileuploading.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }








        [HttpGet]
        public ActionResult About()
        {
            return View();
        }

        //SUPER IMPORTANT******************
        //
        //parameter name MUST match file in the view.
        //
        //SUPER IMPORTANT******************

        [HttpPost]
        public ActionResult About(HttpPostedFileBase file)
        {
            //checks to see if an image was uploaded
            if(file.ContentLength > 0)
            {
                //creates the file path to save the image too
                string path = Path.Combine(Server.MapPath("~/Images"), file.FileName);

                //saves image to the filepath created above
                file.SaveAs(path);
            }

            return RedirectToAction("Index","Home");
        }









        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}