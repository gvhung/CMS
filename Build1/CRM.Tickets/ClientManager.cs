using CRM.Model;
using CRM.Tickets.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CRM.Tickets
{
    public class ClientManager<TClient> where TClient : IClient
    {
        IClientStore<TClient> _clientStore;
        public ClientManager(IClientStore<TClient> clientStore)
        {
            _clientStore = clientStore;
        }

        public void CreateClient(TClient client)
        {

            if (client.Validate())
            {
                _clientStore.CreateClient(client);
                //send email to client

            }
        }

        public IQueryable<TClient> GetClient(SearchCriteria criteria)
        {
            return _clientStore.GetClient(criteria);
        }

        public Client GetClientByID(int id)
        {
            return _clientStore.GetClientByID(id);
        }

        public void UpdateClient(TClient c)
        {
            //validate c
            if (c.Validate())
            {
                _clientStore.UpdateClient(c);
            }
        }


    }
}
