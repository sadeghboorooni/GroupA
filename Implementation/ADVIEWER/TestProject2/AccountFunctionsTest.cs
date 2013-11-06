using ADVIEWER.BAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using ADVIEWER.DAL;

namespace TestProject2
{
    
    
    /// <summary>
    ///This is a test class for AccountFunctionsTest and is intended
    ///to contain all AccountFunctionsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AccountFunctionsTest
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
        ///A test for AccountFunctions Constructor
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\HP\\Documents\\GitHub\\GroupA\\Implementation\\ADVIEWER\\ADVIEWER", "/")]
        [UrlToTest("http://localhost:15402/")]
        public void AccountFunctionsConstructorTest()
        {
            AccountFunctions target = new AccountFunctions();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for GetUserInformation
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\HP\\Documents\\GitHub\\GroupA\\Implementation\\ADVIEWER\\ADVIEWER", "/")]
        [UrlToTest("http://localhost:15402/")]
        public void GetUserInformationTest()
        {
            int UserID = 0; // TODO: Initialize to an appropriate value
            User expected = null; // TODO: Initialize to an appropriate value
            User actual;
            actual = AccountFunctions.GetUserInformation(UserID);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for UpdateUserInfo
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\HP\\Documents\\GitHub\\GroupA\\Implementation\\ADVIEWER\\ADVIEWER", "/")]
        [UrlToTest("http://localhost:15402/")]
        public void UpdateUserInfoTest()
        {
            int id = 0; // TODO: Initialize to an appropriate value
            string fullName = string.Empty; // TODO: Initialize to an appropriate value
            string about = string.Empty; // TODO: Initialize to an appropriate value
            string address = string.Empty; // TODO: Initialize to an appropriate value
            string fax = string.Empty; // TODO: Initialize to an appropriate value
            string mobile = string.Empty; // TODO: Initialize to an appropriate value
            string tell = string.Empty; // TODO: Initialize to an appropriate value
            string yahooId = string.Empty; // TODO: Initialize to an appropriate value
            AccountFunctions.UpdateUserInfo(id, fullName, about, address, fax, mobile, tell, yahooId);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for currentUserId
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\HP\\Documents\\GitHub\\GroupA\\Implementation\\ADVIEWER\\ADVIEWER", "/")]
        [UrlToTest("http://localhost:15402/")]
        public void currentUserIdTest()
        {
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = AccountFunctions.currentUserId();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for loginUser
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\HP\\Documents\\GitHub\\GroupA\\Implementation\\ADVIEWER\\ADVIEWER", "/")]
        [UrlToTest("http://localhost:15402/")]
        public void loginUserTest()
        {
            Guid UserId = new Guid(); // TODO: Initialize to an appropriate value
            AccountFunctions.loginUser(UserId);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for newUser
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\HP\\Documents\\GitHub\\GroupA\\Implementation\\ADVIEWER\\ADVIEWER", "/")]
        [UrlToTest("http://localhost:15402/")]
        public void newUserTest()
        {
            Guid UserId = new Guid(); // TODO: Initialize to an appropriate value
            string UserFullName = string.Empty; // TODO: Initialize to an appropriate value
            string mail = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = AccountFunctions.newUser(UserId, UserFullName, mail);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
