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
        } // end Index()

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Group group)
        {
            DBWorker.AddGroup(group);
            return RedirectToAction("Index");
        } // end Add()

        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                Group group = DBWorker.GetGroupList().Find(f => f.GroupId == id);
            }
            catch
            {
                string[] errorMessages = { "This group not fond" };
                return View("Error", errorMessages);
            }

            return View();
        }
        [HttpPost]
        public ActionResult Edit(Group group)
        {
            DBWorker.EditGroup(group);
            return RedirectToAction("Index");
        } // end Edit

        [HttpPost]
        public ActionResult Delete(int id)
        {
            DBWorker.RemoveGroup(id);
            return RedirectToAction("Index");
        } // end Delete

    } // end controller
} // end namespace