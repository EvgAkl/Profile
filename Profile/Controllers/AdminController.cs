using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Profile.Models.Database;

namespace Profile.Controllers
{
    public class AdminController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }


    } // end controller
} // end namespace