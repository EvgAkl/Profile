using System;
using System.Collections.Generic;
using System.Linq;
using Profile.Models.Database.Context;
using Profile.Models.Database.AbstractWorkers;
using System.IO;

namespace Profile.Models.Database
{
    public class DBWorkerAdminGroup : IWorkerAdminGroup
    {
        EFContext database = new EFContext();
        public List<Group> GetGroupList()
        {
            List<Group> dataList = new List<Group>();
            dataList = database.Groups.Select(s => s).ToList();
            return dataList;
        } // end GetGroupList()

        public void CreateGroup(Group group)
        {
            group.DateOfChange = DateTime.Now;
            database.Groups.Add(group);
            try
            {
                database.SaveChanges();
            }
            catch { }
        } // end AddGroup()

        public void EditGroup(Group group)
        {
            try
            {
                string OldImageFileSystemPath;
                Group entity = database.Groups.Find(group.GroupId);
                entity.Name = group.Name;
                entity.Rank = group.Rank;
                entity.Karma = group.Karma;
                entity.CountMembers = group.CountMembers;
                entity.DateOfChange = DateTime.Now;
                OldImageFileSystemPath = entity.ImageFileSystemPath;
                entity.ImageFileSystemPath = group.ImageFileSystemPath;
                entity.ImageProgectLinkPath = group.ImageProgectLinkPath;
                database.SaveChanges();
                if (OldImageFileSystemPath != group.ImageFileSystemPath && File.Exists(OldImageFileSystemPath))
                    File.Delete(OldImageFileSystemPath);
            }
            catch { }
        } // end EditGroup()

        public void RemoveGroup(int id)
        {
            try
            {
                Group group = database.Groups.Find(id);
                database.Groups.Remove(group);
                database.SaveChanges();
                if (group.ImageFileSystemPath != null && File.Exists(group.ImageFileSystemPath))
                    File.Delete(group.ImageFileSystemPath);
            }
            catch { }     
        } // end RemoveGroup()

    } // end class
} // end namespace