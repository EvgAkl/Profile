using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Profile.Models.Database.Context;

namespace Profile.Models.Database
{
    public static class DatabaseWorker
    {
        public static List<Group> GetGroupList()
        {
            List<Group> dataList = new List<Group>();
            using (EFContext database = new EFContext())
            {
                dataList = database.Groups.Select(s => s).ToList();
            }
            return dataList;
        } // end GetGroupList()

    } // end class
} // end namespace