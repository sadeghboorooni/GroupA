using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ADVIEWER.BAL;

namespace TestProject2
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void TestMethod1()
        {

            int id ; 
            float v = 5;

            

            ADVIEWER.DAL.ModelContainer ml = new ADVIEWER.DAL.ModelContainer();

            id = ml.Groups.Where(t => t.Advertisments != null).First().ID;
            MemberFunctions.SetAdvRate(id,v);

            int groupCount = ml.Rates.Where(t => t.Id == id && t.Value==v).Count();

            Assert.AreEqual(1, groupCount);
        }
    }
}