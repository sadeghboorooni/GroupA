using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ADVIEWER.BAL;


namespace TestProject2
{
    [TestClass]
    public class Bal_MemberFunction_DeleteStateCity_Test
    {
        [TestMethod]
        public void TestMethod1()
        
        {
            ADVIEWER.DAL.ModelContainer m1 = new ADVIEWER.DAL.ModelContainer();
            int sid;
    
            
            


            sid = m1.StateCities.Where(t => t.Id != null).First().Id;

  


            int c1 = m1.StateCities.Where(t => t.Id != null).Count();
            MemberFunctions.DeleteStateCity(sid);
            int c2 = m1.StateCities.Where(t => t.Id != null).Count();

            Assert.AreEqual(1, c1 - c2);
        }

    }
}
