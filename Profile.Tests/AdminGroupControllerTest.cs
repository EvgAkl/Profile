using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using Moq;
using Profile.Controllers;
using Profile.Models.Database;
using Profile.Models.Database.AbstractWorkers;


namespace Profile.Tests
{
    [TestClass]
    public class AdminGroupControllerTest
    {
        private List<Group> testList = new List<Group>()
        {
            new Group
                {
                    GroupId = 1,
                    Name = "Group 1",
                    CountMembers = 11,
                    Karma = 111,
                    Rank = Rank.Tiny,
                    ImageFileSystemPath = "D:/Profile/Content/UserImage/Image1.jpeg",
                    ImageProgectLinkPath = "~/Content/UserImage/Image1.jpeg"
                },
                new Group
                {
                    GroupId = 2,
                    Name = "Group 2",
                    CountMembers = 22,
                    Karma = 222,
                    Rank = Rank.Middle,
                    ImageFileSystemPath = "D:/Profile/Content/UserImage/Image2.jpeg",
                    ImageProgectLinkPath = "~/Content/UserImage/Image2.jpeg"
                }
        };

        private Group testGroup = new Group
        {
            GroupId = 1,
            Name = "Group 1",
            CountMembers = 11,
            Karma = 111,
            Rank = Rank.Tiny,
            ImageFileSystemPath = "D:/Profile/Content/UserImage/Image1.jpeg",
            ImageProgectLinkPath = "~/Content/UserImage/Image1.jpeg"
        };

        [TestMethod]
        public void Can_Show_Groups_List()
        {
            // Arrange
            Mock<IWorkerAdminGroup> mock = new Mock<IWorkerAdminGroup>();
            mock.Setup(m => m.GetGroupList()).Returns(testList);
            AdminGroupController controller = new AdminGroupController(mock.Object);
            // Act
            List<Group> result = ((IEnumerable<Group>)controller.Index().ViewData.Model).ToList();
            // Assert
            Assert.AreEqual(result.Count, 2);
            Assert.AreEqual(result[0].GroupId, 1);
            Assert.AreEqual(result[0].Name, "Group 1");
            Assert.AreEqual(result[0].CountMembers, 11);
            Assert.AreEqual(result[0].Karma, 111);
            Assert.AreEqual(result[0].Rank, Rank.Tiny);
            Assert.AreEqual(result[0].ImageFileSystemPath, "D:/Profile/Content/UserImage/Image1.jpeg");
            Assert.AreEqual(result[0].ImageProgectLinkPath, "~/Content/UserImage/Image1.jpeg");
            Assert.AreEqual(result[1].GroupId, 2);
            Assert.AreEqual(result[1].Name, "Group 2");
            Assert.AreEqual(result[1].CountMembers, 22);
            Assert.AreEqual(result[1].Karma, 222);
            Assert.AreEqual(result[1].Rank, Rank.Middle);
            Assert.AreEqual(result[1].ImageFileSystemPath, "D:/Profile/Content/UserImage/Image2.jpeg");
            Assert.AreEqual(result[1].ImageProgectLinkPath, "~/Content/UserImage/Image2.jpeg");
        } // end Can_Show_Groups_List()

        [TestMethod]
        public void Can_Create_Valid_Group()
        {
            // Arrange
            Mock<IWorkerAdminGroup> mock = new Mock<IWorkerAdminGroup>();
            Mock<HttpPostedFileBase> mockImage = new Mock<HttpPostedFileBase>();
            AdminGroupController controller = new AdminGroupController(mock.Object);
            // Act
            ActionResult result = controller.Create(testGroup, mockImage.Object);
            // Assert
            mock.Verify(m => m.CreateGroup(testGroup));
            Assert.IsNotInstanceOfType(result, typeof(ViewResult));
        } // end Can_Create_Valid_Group()

        [TestMethod]
        public void Cannot_Create_Invalid_Group()
        {
            // Arrange
            Mock<IWorkerAdminGroup> mock = new Mock<IWorkerAdminGroup>();
            Mock<HttpPostedFileBase> mockImage = new Mock<HttpPostedFileBase>();
            AdminGroupController controller = new AdminGroupController(mock.Object);
            controller.ModelState.AddModelError("error", "error");
            // Act
            ActionResult result = controller.Create(testGroup, mockImage.Object);
            // Assert
            mock.Verify(m => m.CreateGroup(testGroup), Times.Never());
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        } // end Cannot_Create_Invalid_Group()











    } // end class
} // end namespace
