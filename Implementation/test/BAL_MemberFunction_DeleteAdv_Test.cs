﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ADVIEWER.BAL;
namespace TestProject2
{
    [TestClass]
    public class BAL_MemberFunction_DeleteAdv_Test
    {
        [TestMethod]
        public void TestMethod1()
        {
            ADVIEWER.DAL.ModelContainer m1 = new ADVIEWER.DAL.ModelContainer();
            int id = m1.Advertisments.Where(t => t.ID != null).First().ID;
            int c1 = m1.Advertisments.Where(t => t.ID == id).Count();
            MemberFunctions.DeleteAdv(id);
            int c2 = m1.Advertisments.Where(t => t.ID == id).Count();
            Assert.AreEqual(1, c2 - c1);

        }
    }
}
