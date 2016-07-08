using CRM.Tickets.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Model;

namespace CRMTicketTest
{
    class DummyClientStore : ICompanyStore<Company>
    {
        List<Company> _mycontext = new List<Company>();
        public DummyClientStore()
        {
            List<Company> _mycontext = new List<Company>();
        }

        public Guid CreateClient<TUser>(Company client, TUser user) where TUser : IUser
        {
            throw new NotImplementedException();
        }

        public IQueryable<Company> GetClients(SearchCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public Company GetClientByID(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateClient(Company c)
        {
            Company tempClient = _mycontext.Find(cl => cl.CompanyId == c.CompanyId);
            if (tempClient == null)
                throw new Exception("Client not found");
            else
                tempClient = c;
        }

        public List<Company> GetClient(Company Client)
        {
            throw new NotImplementedException();
        }

        public List<Company> GetAllClients()
        {
            throw new NotImplementedException();
        }
    }
}
