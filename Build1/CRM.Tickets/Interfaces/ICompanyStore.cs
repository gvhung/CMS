using System;
using System.Linq;
using CRM.Model;
using System.Collections.Generic;

namespace CRM.Tickets.Interfaces
{
    public interface ICompanyStore<TClient> where TClient : CRM.Model.ICompany
    {
        Guid CreateClient<TUser>(TClient client, TUser user) where TUser:IUser ;
        IQueryable<TClient> GetClients(SearchCriteria criteria);
        Company GetClientByID(int id);
        void UpdateClient(TClient c);
        List<TClient> GetClient(TClient Client);
       
    }
}
