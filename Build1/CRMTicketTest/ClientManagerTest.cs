using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRM.Tickets;
using CRM.Model;

namespace CRMTicketTest
{
    /// <summary>
    /// Summary description for ClientManagerTest
    /// </summary>
    [TestClass]
    public class ClientManagerTest
    {
        public ClientManagerTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

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
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void CreateClientSuccess()
        {
            ClientManager<Client> clientManager = new ClientManager<Client>(new DummyClientStore());
            Client c = new Client() { Name = "not able to login",TicketStartNumber = 001};
            clientManager.CreateClient(c);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateClientWithoutNameFail()
        {
            ClientManager<Client> clientManager = new ClientManager<Client>(new DummyClientStore());
            Client c = new Client() {TicketStartNumber = 001 };
            clientManager.CreateClient(c);
        }
    }
}
