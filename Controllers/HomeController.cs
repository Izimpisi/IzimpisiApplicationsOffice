using IzimpisiApplicationsOffice.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IzimpisiApplicationsOffice.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            var userEmail = User.Identity.Name; // Get the current logged-in user's ID
            return View((object)userEmail);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Izimpisi Applications Office is one of the leading digital application systems. It is based on all public higher education institutions in the Gauteng Province.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}