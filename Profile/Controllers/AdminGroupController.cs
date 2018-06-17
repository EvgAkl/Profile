using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Profile.Models.Database;

namespace Profile.Controllers
{
    public class AdminGroupController : Controller
    {
        DatabaseWorker DBWorker = new DatabaseWorker();
        public ActionResult Index()
        {
            return View(DBWorker.GetGroupList());
        }

        [HttpPost]
        public ActionResult EditGroup(int id)
        {
            return RedirectToAction("Groups");
        }

    } // end controller
} // end namespace