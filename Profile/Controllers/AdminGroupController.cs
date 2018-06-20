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
        public ActionResult Add()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(int id)
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            return RedirectToAction("Index");
        }

    } // end controller
} // end namespace