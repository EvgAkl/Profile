using System.Collections.Generic;

namespace Profile.Models.Database.AbstractWorkers
{
    interface IWorkerAdminGroup
    {
        List<Group> GetGroupList();
        void CreateGroup(Group group);
        void RemoveGroup(int id);
    }

} // end namespace
