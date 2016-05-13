using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRM.Store;

namespace CRMStoreTest
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void CreateTicketSuccess()
        {
            TicketStore ticketStore = new TicketStore(new CRMContext("CRMContext"));

            ticketStore.CreateTicket(new CRM.Model.Ticket() { Id = new Guid(), TicketNo = 1234 });
            ticketStore.SaveChanges();
        }
    }
}
