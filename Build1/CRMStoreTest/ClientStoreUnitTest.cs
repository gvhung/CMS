using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Store;
using CRM.Store.Entities;
using CRM.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoMapper;
namespace CRMStoreTest
{

    [TestClass]
    public class ClientStoreUnitTest
    {

        CompanyStore<Company> clientStore;
        [TestInitialize]
        public void Init()
        {
            clientStore = new CompanyStore<Company>("CRMContext");

            clientStore = new CompanyStore<Company>();
            Mapper.Initialize(cnfg =>
            {
                cnfg.CreateMap<Company, CompanyEntity>();
                cnfg.CreateMap<CompanyEntity, Company>();
                cnfg.CreateMap<CRMUser, UserProfileEntity>();
                cnfg.CreateMap<UserProfileEntity,CRMUser>();
            });

        }

        [TestMethod]
        public void CreateClientSuccess()
        {
            Company c = new Company();
            c.Name = "IBM";
            
            
            clientStore.CreateClient(c, new CRMUser() { Username = "satees", Password="password"});
        }
        [TestMethod]
        [ExpectedException(typeof(System.Data.Entity.Infrastructure.DbUpdateException))]
        public void CreateClientDuplicateFail()
        {
            Company c = new Company();
            c.Name = "IBM";


            clientStore.CreateClient(c, new CRMUser() { Username = "satees", Password = "password" });
        }

        [TestMethod]
        public void GetClientsSuccess()
        {
            IQueryable<Company> lst = clientStore.GetClients();
            Assert.AreNotEqual(0, lst.Count());
        }
       
    }
}
