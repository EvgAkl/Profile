using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Profile.Controllers;
using Profile.Models.Database;
using Profile.Models.Database.AbstractWorkers;


namespace Profile.Tests
{
    [TestClass]
    public class AdminGroupControllerTest
    {
        [TestMethod]
        public void Can_Show_Groups_List()
        {
            // Arrange
            Mock<IWorkerAdminGroup> mock = new Mock<IWorkerAdminGroup>();
            mock.Setup(m => m.GetGroupList()).Returns(new List<Group>
            {
                new Group
                {
                    GroupId = 1,
                    Name = "Group 1",
                    CountMembers = 1,
                    Karma = 1,
                    Rank = Rank.Tiny,
                    ImageFileSystemPath = "~/Content/UserImage/Image1.png",
                    ImageProgectLinkPath = "~/Content/UserImage/Image1.png"
                },
                new Group
                {
                    GroupId = 2,
                    Name = "Group 2",
                    CountMembers = 222,
                    Karma = 2,
                    Rank = Rank.Middle,
                    ImageFileSystemPath = "~/Content/UserImage/Image2.png",
                    ImageProgectLinkPath = "~/Content/UserImage/Image2.png"
                }
            });
            AdminGroupController controller = new AdminGroupController(mock.Object);
            // Act
            List<Group> result = ((IEnumerable<Group>)controller.Index().ViewData.Model).ToList();
            // Assert







        }

    } // end class
} // end namespace
