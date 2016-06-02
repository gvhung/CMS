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
<<<<<<< .mine
            clientStore = new ClientStore<Client>("CRMContext");
||||||| .r60
            clientStore = new ClientStore<Client>(new CRMContext("CRMContext"));
=======
            clientStore = new ClientStore<Client>();
>>>>>>> .r75
            Mapper.Initialize(cnfg => cnfg.CreateMap<Client, ClientEntity>());
        }

        [TestMethod]
        public void CreateClientSuccess()
        {
            clientStore.CreateClient(new Client() { Name = "IBM" });
        }
    }
}
