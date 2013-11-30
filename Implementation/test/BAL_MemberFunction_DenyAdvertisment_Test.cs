using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ADVIEWER.BAL;


namespace TestProject2
{
    [TestClass]
    public class BAL_MemberFunction_DenyAdvertisment_Test
    {
        [TestMethod]
        public void TestMethod1()
        {

            int id;
            


            ADVIEWER.DAL.ModelContainer ml = new ADVIEWER.DAL.ModelContainer();

            id = ml.Advertisments.Where(t => t.IsRead == false && t.IsConfirmed == false).First().ID;



            int groupCount1 = ml.Advertisments.Where(t => t.IsConfirmed == false && t.IsRead == true).Count();
            MemberFunctions.ConfirmAdvertisment(id);
            int groupCount2 = ml.Advertisments.Where(t => t.IsConfirmed == false && t.IsRead == true).Count();
            Assert.AreEqual(1, groupCount2 - groupCount1);
        }
    }
}



