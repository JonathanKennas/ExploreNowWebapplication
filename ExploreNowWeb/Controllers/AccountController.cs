using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExploreNowWeb.Models;


namespace ExploreNowWeb.Controllers
{
    public class AccountController : Controller
    {
        User user = new User();
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(string email, string password)
        {          
            return View();        
        }
        public ActionResult Register(string firstname, string lastname, string email, string password)
        {
            
            return View();
        }
        public ActionResult ForgotPassword(string email)
        {
            return View();
        }
        public ActionResult LoginCompany(string email, string password)
        {
            return View();
        }
        public ActionResult RegisterCompany(string name, string email, string password)
        {
            return View();
        }
        public ActionResult ForgotPasswordCompany(string email)
        {
            return View();
        }
    }
}