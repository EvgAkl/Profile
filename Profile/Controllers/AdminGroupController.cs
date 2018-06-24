using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Profile.Models.Database;
using Profile.ViewModels.Admin.Groups;

namespace Profile.Controllers
{
    public class AdminGroupController : Controller
    {
        DBWorkerAdminGroup DBWorker = new DBWorkerAdminGroup();
        public ActionResult Index()
        {
            List<Group> model = new List<Group>();
            model = DBWorker.GetGroupList();
            var tt = model;
            return View(model);
        } // end Index()

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ViewModel_CreateGroup model)
        {
            if (ModelState.IsValid)
            {
                string PathToSaveImage = Path.Combine(Server.MapPath("~/Content/UserImages/"), model.image.FileName);
                string PathToFindImage = "~/Content/UserImages/" + model.image.FileName;
                model.image.SaveAs(PathToSaveImage);
                model.group.ImagePath = PathToFindImage;
                model.group.CreationDate = DateTime.Now;
                DBWorker.CreateGroup(model.group);
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