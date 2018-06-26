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
            return View(new ViewModel_CreateOrEditGroup());
        }
        [HttpPost]
        public ActionResult Create(ViewModel_CreateOrEditGroup model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.group.ImageFileSystemPath = Path.Combine(Server.MapPath("~/Content/UserImages/"), model.image.FileName);
                    model.group.ImageProgectLinkPath = "~/Content/UserImages/" + model.image.FileName;
                    model.image.SaveAs(model.group.ImageFileSystemPath);
                }
                catch (NullReferenceException)
                {
                    model.group.ImageFileSystemPath = "~/";
                    model.group.ImageProgectLinkPath = "~/";
                }
                model.group.CreationDate = DateTime.Now.ToShortDateString();
                DBWorker.CreateGroup(model.group);
                return RedirectToAction("Index");
            }
            else return View(model);
        } // end Add()

        /*
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            ViewModel_CreateOrEditGroup model = new ViewModel_CreateOrEditGroup();
            try
            {
                model.group = DBWorker.GetGroupList().Find(f => f.GroupId == ID);
            }
            catch
            {
                string[] errorMessages = { "This group not fond" };
                return View("Error", errorMessages);
            }

            return View("Create", model);
        } 
        */

        [HttpPost]
        public ActionResult Edit(ViewModel_CreateOrEditGroup model)
        {
            try
            {
                if (model.image.FileName != null && System.IO.File.Exists(model.group.ImageFileSystemPath))
                {
                    System.IO.File.Delete(model.group.ImageFileSystemPath);
                    model.group.ImageFileSystemPath = Path.Combine(Server.MapPath("~/Content/UserImages/"), model.image.FileName);
                    model.group.ImageProgectLinkPath = "~/Content/UserImages/" + model.image.FileName;
                    model.image.SaveAs(model.group.ImageFileSystemPath);
                }              
            }
            catch (NullReferenceException) { }
            DBWorker.EditGroup(model.group);
            return RedirectToAction("Index");
        } // end Edit

        [HttpPost]
        public ActionResult Delete(Group group)
        {
            DBWorker.RemoveGroup(group.GroupId);
            return RedirectToAction("Index");
        } // end Delete

    } // end controller
} // end namespace