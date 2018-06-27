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
        public ActionResult Create(Group group, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                try
                {   // Save new avatar
                    group.ImageFileSystemPath = Path.Combine(Server.MapPath("~/Content/UserImages/"), image.FileName);
                    group.ImageProgectLinkPath = "~/Content/UserImages/" + image.FileName;
                    image.SaveAs(group.ImageFileSystemPath);
                }
                catch (NullReferenceException)
                {   // Save without avatar
                    group.ImageFileSystemPath = "~/";
                    group.ImageProgectLinkPath = "~/";
                }
                DBWorker.CreateGroup(group);
                return RedirectToAction("Index");
            }
            else return View(group);
        } // end Add()

        [HttpPost]
        public ActionResult Edit(Group group)
        {
            return View();
        } 

        [HttpPost]
        public ActionResult EditGroup(ViewModel_CreateOrEditGroup model)
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