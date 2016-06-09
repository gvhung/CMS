using System;
using System.Linq;
using CRM.Model;
namespace CRM.Tickets.Interfaces
{
    public interface IClientStore<TClient>
     where TClient : CRM.Model.IClient
    {
        void CreateClient(TClient client);
        IQueryable<TClient> GetClient(SearchCriteria criteria);
        Client GetClientByID(int id);
        void UpdateClient(TClient c);
    }
}
