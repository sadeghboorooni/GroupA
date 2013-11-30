using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ADVIEWER.BAL;

namespace TestProject2
{
    [TestClass]
    public class BAL_MemberFunction_SetTicketAnswer_Test
    {
        [TestMethod]
        public void TestMethod1()
        {
            ADVIEWER.DAL.ModelContainer m1 = new ADVIEWER.DAL.ModelContainer();
            int TicketID;
            string answer;

            
            TicketID = m1.Tickets1.Where(t => t.ID != null).First().ID;
            answer = "Test new Group name";

            int c1 = m1.Tickets1.Where(t => t.ID == TicketID && t.Answer == answer).Count();
            MemberFunctions.SetTicketAnswer(TicketID, answer);
            int c2 = m1.Tickets1.Where(t => t.ID == TicketID && t.Answer == answer).Count();
            Assert.AreEqual(1, c2 - c1);
            
        }
    }
}
