using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Profile.Models.Database.Context;

namespace Profile.Models.Database
{
    public class DBWorkerAdminGroup
    {
        EFContext database = new EFContext();
        public List<Group> GetGroupList()
        {
            List<Group> dataList = new List<Group>();
            dataList = database.Groups.Select(s => s).ToList();
            return dataList;
        } // end GetGroupList()

        public void AddGroup(Group group)
        {
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
                Group entity = database.Groups.Find(group.GroupId);
                entity.Name = group.Name;
                entity.Rank = group.Rank;
                entity.Karma = group.Karma;
                entity.CountMembers = group.CountMembers;
                entity.CreationDate = group.CreationDate;
                entity.ImagePath = group.ImagePath;
                database.SaveChanges();
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
            }
            catch { }     
        } // end RemoveGroup()

    } // end class
} // end namespace