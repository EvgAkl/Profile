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
        DBWorkerAdminGroup DBWorker = new DBWorkerAdminGroup();
        public ActionResult Index()
        {
            List<Group> model = new List<Group>();
            model = DBWorker.GetGroupList();
            return View(model);
        } // end Index()

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Group group)
        {
            if (ModelState.IsValid)
            {
                group.CreationDate = DateTime.Now;
                DBWorker.CreateGroup(group);
                return RedirectToAction("Index");
            }
            else return View(group);
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