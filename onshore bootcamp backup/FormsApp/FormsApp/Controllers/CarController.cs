using FormsApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormsApp.Controllers
{
    public class CarController : Controller
    {
        //get vs. post
        //  gets are typically called from links and are meant to OBTAIN a view.
        //  gets can have parameters but are primative in nature. ie ints, strings
        
        //  Posts will send a filled out form back to the server.
        //  typically at the same end point name.

        /// <summary>
        /// View all cars in the database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        //Create
        [HttpGet]
        public ActionResult CreateCar()
        {
            //provide a form
            
            return View();
        }

        [HttpPost]
        public ActionResult CreateCar(Car form)
        {
            ActionResult response;
            //Filled out data correctly
            if(ModelState.IsValid)
            {
                try
                {
                    //make a data call to perform our action. in this case, Create
                    response = RedirectToAction("Index", "Car");
                }
                catch(SqlException sqlEx)
                {
                    //log
                    //redirect to an error page if you want
                    response = View(form);
                }

            }
            //Did not fill out correctly
            else
            {

                response = View(form);
            }

            return response;
        }

        //Read
        //Update
        //Delete
    }
}