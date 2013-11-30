using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ADVIEWER.BAL;

namespace TestProject2
{
    [TestClass]
    public class BAL_MemberFunction_AddNewGroup_test
    {
        [TestMethod]
        public void TestMethod1()
        {
            ADVIEWER.DAL.ModelContainer m1 = new ADVIEWER.DAL.ModelContainer();
            
            string groupName="Test name";
            int c1=m1.Groups.Where(t=> t.ID != null).Count();
            MemberFunctions.AddNewGroup(groupName,null);
            int c2= m1.Groups.Where(t => t.ID != null).Count();
            Assert.AreEqual(1,c2,c1);


        }
    }
}
