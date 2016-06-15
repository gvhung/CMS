using CRM.Tickets.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Model;

namespace CRMTicketTest
{
    class DummyClientStore : IClientStore<Client>
    {
        List<Client> _mycontext = new List<Client>();
        public DummyClientStore()
        {
            List<Client> _mycontext = new List<Client>();
        }

        public long CreateClient<TUser>(Client client, TUser user) where TUser : IUser
        {
            throw new NotImplementedException();
        }

        public IQueryable<Client> GetClients(SearchCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public Client GetClientByID(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateClient(Client c)
        {
            Client tempClient = _mycontext.Find(cl => cl.ClientId == c.ClientId);
            if (tempClient == null)
                throw new Exception("Client not found");
            else
                tempClient = c;
        }

        public List<Client> GetClient(Client Client)
        {
            throw new NotImplementedException();
        }

        public List<Client> GetAllClients()
        {
            throw new NotImplementedException();
        }
    }
}
