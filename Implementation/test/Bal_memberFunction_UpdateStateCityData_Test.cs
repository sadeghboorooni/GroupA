using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ADVIEWER.BAL;

namespace TestProject2
{
    [TestClass]
    public class Bal_memberFunction_UpdateStateCityData_Test
    {
        [TestMethod]
        public void TestMethod1()
        {
            ADVIEWER.DAL.ModelContainer m1 = new ADVIEWER.DAL.ModelContainer();

            int StateCityId;
            string Name;
            int? StateId;

            ADVIEWER.DAL.StateCity s = new ADVIEWER.DAL.StateCity();

            s = m1.StateCities.Where(t => t.Id != null).First();

            StateCityId = s.Id;
            Name = s.Name;
            StateId = s.StateId;


            int c1 = m1.StateCities.Where(t => t.Id == StateCityId && t.Name == Name && t.StateId == StateId).Count();
            Name = Name + " Update Test Name";
            MemberFunctions.UpdateStateCityData(StateCityId, Name, StateId);
            int c2 = m1.StateCities.Where(t => t.Id == StateCityId && t.Name == Name && t.StateId == StateId).Count();
            Assert.AreEqual(0, c2 - c1);
        }
    }
}
