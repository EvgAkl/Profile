using System.Collections.Generic;

namespace Profile.Models.Database.AbstractWorkers
{
    public interface IWorkerAdminGroup
    {
        List<Group> GetGroupList();
        void CreateGroup(Group group);
        void EditGroup(Group group);
        void RemoveGroup(int id);
    }

} // end namespace
