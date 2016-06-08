using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRM.Tickets;
using CRM.Tickets.Interfaces;
using CRM.Model;
namespace CRMTicketTest
{
    /// <summary>
    /// Summary description for TicketManagerTest
    /// </summary>
    [TestClass]
    public class TicketManagerTest
    {
        public TicketManagerTest()
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
        public void CreateTicketSuccess()
        {
            TicketManager<Ticket> ticketManager = new TicketManager<Ticket>(new DummyTicketStore());
            Ticket t=new Ticket(){Title="not able to login", Description="abla bla", ProductId=1};
            ticketManager.CreateTicket(t);

        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateTicketWithoutTitleFail()
        {
            TicketManager<Ticket> ticketManager = new TicketManager<Ticket>(new DummyTicketStore());
            Ticket t = new Ticket() { Description = "abla bla" };
            ticketManager.CreateTicket(t);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateTicketWithoutProductFail()
        {
            TicketManager<Ticket> ticketManager = new TicketManager<Ticket>(new DummyTicketStore());
            Ticket t = new Ticket() {Title="not able to login", Description = "abla bla" };
            ticketManager.CreateTicket(t);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateTicketWithTicketNoFail()
        {
            TicketManager<Ticket> ticketManager = new TicketManager<Ticket>(new DummyTicketStore());
            Ticket t = new Ticket() { TicketNo=102,Description = "abla bla" };
            ticketManager.CreateTicket(t);
        }
    }
}
