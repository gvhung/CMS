using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRM.Store;
using CRM.Model;
using AutoMapper;
using CRM.Store.Entities;
using System.Linq;
namespace CRMStoreTest
{
    [TestClass]
    public class TicketStoreUnitTest
    {
        TicketStore<Ticket, Guid> ticketStore;

        [TestInitialize]
        public void Init()
        {
            Mapper.Initialize(cnfg => cnfg.CreateMap<Ticket, TicketEntity>());
             ticketStore= new TicketStore<Ticket, Guid>(new CRMContext("CRMContext"));

        }
        [TestMethod]
        public void CreateTicketSuccess()
        {
          
            ticketStore.CreateTicket(new CRM.Model.Ticket() { Id = new Guid(), TicketNo = 1234 });
            
        }
        public void GetTicketsSuccess()
        {
           IQueryable<Ticket> tickets=  ticketStore.GetTickets();
           Assert.AreNotEqual(0, tickets.Count());
        }
    }
}
