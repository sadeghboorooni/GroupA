using ADVIEWER.BAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using ADVIEWER.DAL;
using System.Data;

namespace TestProject2
{
    
    
    /// <summary>
    ///This is a test class for MemberFunctionsTest and is intended
    ///to contain all MemberFunctionsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MemberFunctionsTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for MemberFunctions Constructor
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\HP\\Documents\\GitHub\\GroupA\\Implementation\\ADVIEWER\\ADVIEWER", "/")]
        [UrlToTest("http://localhost:15402/")]
        public void MemberFunctionsConstructorTest()
        {
            MemberFunctions target = new MemberFunctions();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for AddNewGroup
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\HP\\Documents\\GitHub\\GroupA\\Implementation\\ADVIEWER\\ADVIEWER", "/")]
        [UrlToTest("http://localhost:15402/")]
        public void AddNewGroupTest()
        {
            string groupName = string.Empty; // TODO: Initialize to an appropriate value
            Nullable<int> parentId = new Nullable<int>(); // TODO: Initialize to an appropriate value
            MemberFunctions.AddNewGroup(groupName, parentId);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AddNewTicket
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\HP\\Documents\\GitHub\\GroupA\\Implementation\\ADVIEWER\\ADVIEWER", "/")]
        [UrlToTest("http://localhost:15402/")]
        public void AddNewTicketTest()
        {
            string text = string.Empty; // TODO: Initialize to an appropriate value
            string title = string.Empty; // TODO: Initialize to an appropriate value
            int userId = 0; // TODO: Initialize to an appropriate value
            MemberFunctions.AddNewTicket(text, title, userId);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ConfirmAdvertisment
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\HP\\Documents\\GitHub\\GroupA\\Implementation\\ADVIEWER\\ADVIEWER", "/")]
        [UrlToTest("http://localhost:15402/")]
        public void ConfirmAdvertismentTest()
        {
            int AdvID = 0; // TODO: Initialize to an appropriate value
            MemberFunctions.ConfirmAdvertisment(AdvID);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DenyAdvertisment
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\HP\\Documents\\GitHub\\GroupA\\Implementation\\ADVIEWER\\ADVIEWER", "/")]
        [UrlToTest("http://localhost:15402/")]
        public void DenyAdvertismentTest()
        {
            int AdvID = 0; // TODO: Initialize to an appropriate value
            string reason = string.Empty; // TODO: Initialize to an appropriate value
            MemberFunctions.DenyAdvertisment(AdvID, reason);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetAdvByGroupID
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\HP\\Documents\\GitHub\\GroupA\\Implementation\\ADVIEWER\\ADVIEWER", "/")]
        [UrlToTest("http://localhost:15402/")]
        public void GetAdvByGroupIDTest()
        {
            int ID = 0; // TODO: Initialize to an appropriate value
            Advertisment[] expected = null; // TODO: Initialize to an appropriate value
            Advertisment[] actual;
            actual = MemberFunctions.GetAdvByGroupID(ID);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetAdvertismentData
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\HP\\Documents\\GitHub\\GroupA\\Implementation\\ADVIEWER\\ADVIEWER", "/")]
        [UrlToTest("http://localhost:15402/")]
        public void GetAdvertismentDataTest()
        {
            int id = 0; // TODO: Initialize to an appropriate value
            Advertisment expected = null; // TODO: Initialize to an appropriate value
            Advertisment actual;
            actual = MemberFunctions.GetAdvertismentData(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetGroupData
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\HP\\Documents\\GitHub\\GroupA\\Implementation\\ADVIEWER\\ADVIEWER", "/")]
        [UrlToTest("http://localhost:15402/")]
        public void GetGroupDataTest()
        {
            int groupId = 0; // TODO: Initialize to an appropriate value
            Group expected = null; // TODO: Initialize to an appropriate value
            Group actual;
            actual = MemberFunctions.GetGroupData(groupId);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetParentGroups
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\HP\\Documents\\GitHub\\GroupA\\Implementation\\ADVIEWER\\ADVIEWER", "/")]
        [UrlToTest("http://localhost:15402/")]
        public void GetParentGroupsTest()
        {
            Group[] expected = null; // TODO: Initialize to an appropriate value
            Group[] actual;
            actual = MemberFunctions.GetParentGroups();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetSubGroups
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\HP\\Documents\\GitHub\\GroupA\\Implementation\\ADVIEWER\\ADVIEWER", "/")]
        [UrlToTest("http://localhost:15402/")]
        public void GetSubGroupsTest()
        {
            Group[] expected = null; // TODO: Initialize to an appropriate value
            Group[] actual;
            actual = MemberFunctions.GetSubGroups();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetSubGroupsByID
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\HP\\Documents\\GitHub\\GroupA\\Implementation\\ADVIEWER\\ADVIEWER", "/")]
        [UrlToTest("http://localhost:15402/")]
        public void GetSubGroupsByIDTest()
        {
            int ID = 0; // TODO: Initialize to an appropriate value
            Group[] expected = null; // TODO: Initialize to an appropriate value
            Group[] actual;
            actual = MemberFunctions.GetSubGroupsByID(ID);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetTicketData
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\HP\\Documents\\GitHub\\GroupA\\Implementation\\ADVIEWER\\ADVIEWER", "/")]
        [UrlToTest("http://localhost:15402/")]
        public void GetTicketDataTest()
        {
            int id = 0; // TODO: Initialize to an appropriate value
            Ticket expected = null; // TODO: Initialize to an appropriate value
            Ticket actual;
            actual = MemberFunctions.GetTicketData(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetUserAdvs
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\HP\\Documents\\GitHub\\GroupA\\Implementation\\ADVIEWER\\ADVIEWER", "/")]
        [UrlToTest("http://localhost:15402/")]
        public void GetUserAdvsTest()
        {
            int UserID = 0; // TODO: Initialize to an appropriate value
            Advertisment[] expected = null; // TODO: Initialize to an appropriate value
            Advertisment[] actual;
            actual = MemberFunctions.GetUserAdvs(UserID);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetUserConfirmedAdvs
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\HP\\Documents\\GitHub\\GroupA\\Implementation\\ADVIEWER\\ADVIEWER", "/")]
        [UrlToTest("http://localhost:15402/")]
        public void GetUserConfirmedAdvsTest()
        {
            int UserID = 0; // TODO: Initialize to an appropriate value
            Advertisment[] expected = null; // TODO: Initialize to an appropriate value
            Advertisment[] actual;
            actual = MemberFunctions.GetUserConfirmedAdvs(UserID);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MakeNewAdvertisment
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\HP\\Documents\\GitHub\\GroupA\\Implementation\\ADVIEWER\\ADVIEWER", "/")]
        [UrlToTest("http://localhost:15402/")]
        public void MakeNewAdvertismentTest()
        {
            int starCount = 0; // TODO: Initialize to an appropriate value
            int advDuration = 0; // TODO: Initialize to an appropriate value
            string title = string.Empty; // TODO: Initialize to an appropriate value
            string shortdescription = string.Empty; // TODO: Initialize to an appropriate value
            string description = string.Empty; // TODO: Initialize to an appropriate value
            string keywordStr = string.Empty; // TODO: Initialize to an appropriate value
            string price = string.Empty; // TODO: Initialize to an appropriate value
            string link = string.Empty; // TODO: Initialize to an appropriate value
            string fullName = string.Empty; // TODO: Initialize to an appropriate value
            string mobile = string.Empty; // TODO: Initialize to an appropriate value
            string tell = string.Empty; // TODO: Initialize to an appropriate value
            string telltime = string.Empty; // TODO: Initialize to an appropriate value
            string email = string.Empty; // TODO: Initialize to an appropriate value
            string yahooid = string.Empty; // TODO: Initialize to an appropriate value
            string address = string.Empty; // TODO: Initialize to an appropriate value
            int userId = 0; // TODO: Initialize to an appropriate value
            string tempAdd = string.Empty; // TODO: Initialize to an appropriate value
            string mainAdd = string.Empty; // TODO: Initialize to an appropriate value
            string fileName = string.Empty; // TODO: Initialize to an appropriate value
            int groupId = 0; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = MemberFunctions.MakeNewAdvertisment(starCount, advDuration, title, shortdescription, description, keywordStr, price, link, fullName, mobile, tell, telltime, email, yahooid, address, userId, tempAdd, mainAdd, fileName, groupId);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ParseKeyWords
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\HP\\Documents\\GitHub\\GroupA\\Implementation\\ADVIEWER\\ADVIEWER", "/")]
        [UrlToTest("http://localhost:15402/")]
        public void ParseKeyWordsTest()
        {
            string keywordStr = string.Empty; // TODO: Initialize to an appropriate value
            int[] expected = null; // TODO: Initialize to an appropriate value
            int[] actual;
            actual = MemberFunctions.ParseKeyWords(keywordStr);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SaveImage
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\HP\\Documents\\GitHub\\GroupA\\Implementation\\ADVIEWER\\ADVIEWER", "/")]
        [UrlToTest("http://localhost:15402/")]
        public void SaveImageTest()
        {
            string tempAdd = string.Empty; // TODO: Initialize to an appropriate value
            string mainAdd = string.Empty; // TODO: Initialize to an appropriate value
            string filename = string.Empty; // TODO: Initialize to an appropriate value
            MemberFunctions.SaveImage(tempAdd, mainAdd, filename);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for UnconfirmedFreeAdvertismentsDataTable
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\HP\\Documents\\GitHub\\GroupA\\Implementation\\ADVIEWER\\ADVIEWER", "/")]
        [UrlToTest("http://localhost:15402/")]
        public void UnconfirmedFreeAdvertismentsDataTableTest()
        {
            DataTable expected = null; // TODO: Initialize to an appropriate value
            DataTable actual;
            actual = MemberFunctions.UnconfirmedFreeAdvertismentsDataTable();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for UpdateGroupData
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\HP\\Documents\\GitHub\\GroupA\\Implementation\\ADVIEWER\\ADVIEWER", "/")]
        [UrlToTest("http://localhost:15402/")]
        public void UpdateGroupDataTest()
        {
            int Id = 0; // TODO: Initialize to an appropriate value
            string groupName = string.Empty; // TODO: Initialize to an appropriate value
            Nullable<int> parentId = new Nullable<int>(); // TODO: Initialize to an appropriate value
            MemberFunctions.UpdateGroupData(Id, groupName, parentId);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
