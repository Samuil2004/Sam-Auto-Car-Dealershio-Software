using Classes;
using System;
using System.Collections.Generic;
using Logic_layer.Enumerations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingTool.ClassTests
{
    [TestClass]
    public class StaffMemberTest
    {
        private StaffMember person;
        [TestInitialize]
        public void Setup()
        {
            person = new StaffMember(15,"Elvis", "Presley", "e.presley@gmail.com", "987678987", DateTime.Today.AddDays(-1),StaffMemberRoles.Manager);
        }

        [TestMethod]
        public void Constructor_InitializesPropertiesCorrectly()
        {
            Assert.AreEqual(15, person.GetId);
            Assert.AreEqual("Elvis", person.GetFirstName);
            Assert.AreEqual("Presley", person.GetLastName);
            Assert.AreEqual("e.presley@gmail.com", person.GetEmail);
            Assert.AreEqual("987678987", person.GetPhoneNumber);
            Assert.AreEqual(DateTime.Today.AddDays(-1), person.GetStartedDate);
            Assert.AreEqual(StaffMemberRoles.Manager, person.GetStaffRole);

        }
        [TestMethod]
        public void GetInfo_ReturnsCorrectInfo()
        {
            string info = person.GetIdentifyingInfo;

            string expectedInfo = "e.presley@gmail.com - Elvis Presley";
            Assert.AreEqual(expectedInfo, info);
        }
    }
}
