using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ADVIEWER.BAL;


namespace TestProject2
{
    [TestClass]
    public class BAL_MemberFunction_AddNewTicket_Test
    {
        [TestMethod]
        public void TestMethod1()
        {
            string text="Test Text";
            int userid;
            string title="TEst Title";
            ADVIEWER.DAL.ModelContainer m1 = new ADVIEWER.DAL.ModelContainer();
            userid = m1.Users.Where(t=> t.ID != null).First().ID;
            int c1 = m1.Tickets1.Where(t => t.Title == title).Count();
            MemberFunctions.AddNewTicket(text, title, userid);
            int c2 = m1.Tickets1.Where(t => t.Title == title).Count();
            Assert.AreEqual(1, c2 - c1);



            

        }
    }
}
