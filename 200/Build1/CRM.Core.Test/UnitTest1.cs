using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoMapper;
using CRM.Core.Model;
using CRM.DAL.Entities;
using CRM.Core.Interfaces;
using CRM.DAL.Interfaces;
using CRM.DAL;
namespace CRM.Core.Test
{
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
            Mapper.Initialize(cnfg =>
            {
                cnfg.CreateMap<CustomerViewModel, Customer>()
                .ForMember(dest=>dest.Country,
                    opts=>opts.MapFrom(
                        src=>new Country { CountryName = src.Country }
                        ));

            });
        }
        [TestMethod]
        public void TestMethod1()
        {
            CRMContext context = new CRMContext("mydb");
            IUnitOfWork uow = new UnitOfWork(context);

           
            ICustomerManager customerManager = new CustomerManager(uow);
            customerManager.Create(new CustomerViewModel {
                CustomerName = "Customer1", EmailId = "sateesh.gompa@gmail.com",
                City = "Hyderabad", Country = "India",
                CustomerType="SUV",
                CustomerAddress = "Hyderabad", ParentId = 0,
                PrimaryContact="986789456",PrimaryEmail="" 
            });
            context.SaveChanges();
        }
    }
}
