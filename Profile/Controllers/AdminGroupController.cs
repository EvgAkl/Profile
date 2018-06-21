using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Profile.Models.Database;
using Profile.ViewModels.AdminGroup;

namespace Profile.Controllers
{
    public class AdminGroupController : Controller
    {
        DBWorkerAdminGroup DBWorker = new DBWorkerAdminGroup();
        public ActionResult Index()
        {
            IndexViewModel model = new IndexViewModel();
            //model.GroupsList = new List<Group>();
            //Group grop = new Group() { Name = "Show", CountMembers = 12, CreationDate = DateTime.Now, Karma = -28 };
            //model.GroupsList.Add(grop);
            model.GroupsList = DBWorker.GetGroupList();
            return View(model);
        } // end Index()

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Group.CreationDate = DateTime.Now;
                DBWorker.CreateGroup(model.Group);
                return RedirectToAction("Index");
            }
            else return View(model);
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