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

        public IQueryable<TClient> GetClient()
        {
            return _clientStore.GetClient();
        }


    }
}
