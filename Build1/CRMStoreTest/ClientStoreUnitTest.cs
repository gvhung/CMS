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

        ClientStore<Client> clientStore;
        [TestInitialize]
        public void Init()
        {
            clientStore = new ClientStore<Client>("CRMContext");

            clientStore = new ClientStore<Client>();
            Mapper.Initialize(cnfg =>
            {
                cnfg.CreateMap<Client, ClientEntity>();
                cnfg.CreateMap<ClientEntity, Client>();
                cnfg.CreateMap<CRMUser, UserProfileEntity>();
                cnfg.CreateMap<UserProfileEntity,CRMUser>();
            });

        }

        [TestMethod]
        public void CreateClientSuccess()
        {
            Client c = new Client();
            c.Name = "IBM";
            
            
            clientStore.CreateClient(c, new CRMUser() { Username = "satees", Password="password"});
        }
        [TestMethod]
        [ExpectedException(typeof(System.Data.Entity.Infrastructure.DbUpdateException))]
        public void CreateClientDuplicateFail()
        {
            Client c = new Client();
            c.Name = "IBM";


            clientStore.CreateClient(c, new CRMUser() { Username = "satees", Password = "password" });
        }

        [TestMethod]
        public void GetClientsSuccess()
        {
            IQueryable<Client> lst = clientStore.GetClients();
            Assert.AreNotEqual(0, lst.Count());
        }
    }
}
