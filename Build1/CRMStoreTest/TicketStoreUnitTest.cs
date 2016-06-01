using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRM.Store;
using CRM.Model;
using AutoMapper;
using CRM.Tickets.Interfaces;
using CRM.Store.Entities;
using System.Linq;
namespace CRMStoreTest
{
    [TestClass]
    public class TicketStoreUnitTest
    {
        TicketStore<Ticket> ticketStore;

        [TestInitialize]
        public void Init()
        {
            Mapper.Initialize(cnfg =>
            {
                cnfg.CreateMap<Ticket, TicketEntity>();
                cnfg.CreateMap<TicketEntity, Ticket>();
            }
          );

             ticketStore= new TicketStore<Ticket>();

        }
        [TestMethod]
        public void CreateTicketSuccess()
        {
          
            ticketStore.CreateTicket(new CRM.Model.Ticket() {  TicketNo = 1234 });
            
        }

        [TestMethod]
        public void GetTicketsSuccess()
        {
           IQueryable<Ticket> tickets=  ticketStore.GetTickets();
           Assert.AreNotEqual(0, tickets.Count());
        }
    }
}
