using CRM.Model;
using CRM.Tickets.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Utility;
using System.Configuration;


namespace CRM.Tickets
{
    public class CompanyManager<TClient> where TClient : ICompany
    {
        ICompanyStore<TClient> _clientStore;
        public CompanyManager(ICompanyStore<TClient> clientStore)
        {
            _clientStore = clientStore;
        }
        public void CreateClient<TUser>(TClient client, TUser user) where TUser : IUser
        {
            try
            {
                if (client == null) throw new Exception("Client information is missing");
                if (user == null) throw new Exception("User information is missing");
                if (client.Validate() && user.Validate())
                {
                    Guid userId = _clientStore.CreateClient<TUser>(client, user);
                    //send email to client
                    //string message = "Dear " + client.Name + "<br/> Thank you ";
                    string fromAddress = ConfigurationManager.AppSettings["SUPPORTMAILID"];
                    string Msg = "Dear Customer,<br/><br/> Thank you for Registring with us<br/>" +
                        "Plese Click below link for Activation<br/><br/>" +
                        "<a href='http://localhost:51291/User/Activate?id=" + userId +
                        "' > http://localhost:51291/User/Activate?id=" + userId + "</a><br/><br />" +
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

        public Company GetClientByID(int id)
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
