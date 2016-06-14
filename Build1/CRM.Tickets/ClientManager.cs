using CRM.Model;
using CRM.Tickets.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace CRM.Tickets
{
    public class ClientManager<TClient> where TClient : IClient
    {
        IClientStore<TClient> _clientStore;
        public ClientManager(IClientStore<TClient> clientStore)
        {
            _clientStore = clientStore;
        }

      
        public void CreateClient<TUser>(TClient client, TUser user) where TUser:IUser
        {
            if (client == null) throw new Exception("Client information is missing");
            if (user == null) throw new Exception("User information is missing");

            

            if (client.Validate() && user.Validate())
            {
                _clientStore.CreateClient<TUser>(client, user);
                //send email to client
                string messgae = "Dear " + client.Name + "<br/> Thank you ";
                EmailUtilty.SendEmail(user.Username, "mkbondada@gmail.com", "Company Registration", message, true);

            }
        }

        public IQueryable<TClient> GetClient(SearchCriteria criteria)
        {
            return _clientStore.GetClients(criteria);
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
