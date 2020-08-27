using ExploreNowWeb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExploreNowWeb.Controllers
{ 
    public class HomeController : Controller
    {
        Activity activity = new Activity();

       
        public ActionResult Index()
        {
            ViewBag.Activities = activity.GetActivities();
            //var model = activity.getActivities();
            //activity.getActivities();
            return View(/*model*//*new Activity()*//*activity.getActivities()*/);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}