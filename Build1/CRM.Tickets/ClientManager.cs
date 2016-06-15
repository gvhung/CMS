using CRM.Model;
using CRM.Tickets.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;
using System.Configuration;

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
            try
            {

                if (client == null) throw new Exception("Client information is missing");
                if (user == null) throw new Exception("User information is missing");



                if (client.Validate() && user.Validate())
                {
                    long clientId = _clientStore.CreateClient<TUser>(client, user);
                    //send email to client
                    //string message = "Dear " + client.Name + "<br/> Thank you ";
                    string fromAddress = ConfigurationManager.AppSettings["SUPPORTMAILID"];
                    string Msg = "Dear Customer,<br/><br/> Thank you for Registring with us<br/>" +
                        "Plese Click below link for Activation<br/><br/>" +
                        "<a href='http://localhost:2340/user/activate?id=" + clientId +
                        "' >http://localhost:2340/user/activate?id=" + clientId + "</a><br/><br />" +
                        "Thanks and Regards<br/>CRM Admin";
                    EmailUtilty.SendEmail(user.Username, fromAddress, "Company Registration", Msg, true);


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       public void Getclient()
        {

        }

        public IQueryable<TClient> GetClient(SearchCriteria criteria)
        {
            return _clientStore.GetClients(criteria);
        }

        public List<TClient> GetClient(TClient client)
        {
            return _clientStore.GetClient(client);
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

        public List<TClient> GetAllClients()
        {

            return _clientStore.GetClients(new SearchCriteria() { Title = "" }).ToList();
        }

    }
}
