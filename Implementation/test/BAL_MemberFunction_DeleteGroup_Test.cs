using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ADVIEWER.BAL;

namespace TestProject2
{
    [TestClass]
    public class BAL_MemberFunction_DeleteGroup_Test
    {
        [TestMethod]
        public void TestMethod1()
        {
            ADVIEWER.DAL.ModelContainer m1 = new ADVIEWER.DAL.ModelContainer();
            int GID;
            string answer;


            GID = m1.Groups.Where(t => t.ID != null).First().ID;
            answer = "Test new Group name";

            int c1 = m1.Groups.Where(t => t.ID != null).Count();
            MemberFunctions.DeleteGroup(GID);
            int c2= m1.Groups.Where(t => t.ID != null).Count();
            Assert.AreEqual(1, c1 - c2);
        }
    }
}
