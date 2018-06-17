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
        DatabaseWorker DBWorker = new DatabaseWorker();
        public ActionResult Index()
        {
            return View(DBWorker.GetGroupList());
        }

    } // end controller
} // end namespace