using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ADVIEWER.BAL;

namespace TestProject2
{
    [TestClass]
    public class BAL_MemberFunction_UpdateGroupData_Test
    {
        [TestMethod]
        public void TestMethod1()
        {
            ADVIEWER.DAL.ModelContainer m1 = new ADVIEWER.DAL.ModelContainer();

            ADVIEWER.DAL.Group g = new ADVIEWER.DAL.Group();
            g = m1.Groups.Where(t => t.ParentID != null).First();
            string groupName = "Test new Group name";
            int c1 = m1.Groups.Where(t => t.ID == g.ID && t.GroupName == g.GroupName && t.ParentID == g.ParentID).Count();
            MemberFunctions.UpdateGroupData(g.ID, groupName, g.ParentID);
            int c2 = m1.Groups.Where(t => t.ID == g.ID && t.GroupName == groupName && t.ParentID == g.ParentID).Count();
            Assert.AreEqual(0, c2 - c1);
            
        }
    }
}
