using System;
namespace CRM.Tickets.Interfaces
{
    public interface IClientStore<TClient>
     where TClient : CRM.Model.IClient
    {
        void CreateClient(TClient client);
    }
}
