using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRM.Store;
using CRM.Model;
namespace CRMStoreTest
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void CreateTicketSuccess()
        {
            TicketStore<Ticket,Guid> ticketStore = new TicketStore<Ticket, Guid>(new CRMContext("CRMContext"));

            ticketStore.CreateTicket(new CRM.Model.Ticket() { Id = new Guid(), TicketNo = 1234 });
            
        }
    }
}
