﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ADVIEWER.BAL;


namespace TestProject2
{
    [TestClass]
    public class BAL_MemberFunction_AddNewStateCity_Test
    {
        [TestMethod]
        public void TestMethod1()
        {
            ADVIEWER.DAL.ModelContainer m1 = new ADVIEWER.DAL.ModelContainer();
            string name = "Test Name";

           
            int c1 = m1.StateCities.Where(t => t.Id != null).Count();
            MemberFunctions.AddNewStateCity(name,null);
            int c2 = m1.StateCities.Where(t => t.Id != null).Count();

            Assert.AreEqual(1, c2 - c1);

        }
    }
}
