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
            Mapper.Initialize(cnfg => cnfg.CreateMap<Client, ClientEntity>());
        }

        [TestMethod]
        public void CreateClientSuccess()
        {
            clientStore.CreateClient(new Client() { Name = "IBM" });
        }
    }
}
