using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Model;
using CRM.Store.Entities;
using CRM.Tickets.Interfaces;
using AutoMapper.Mappers;
using AutoMapper.QueryableExtensions;
namespace CRM.Store
{
    public class ClientStore<TClient> : IClientStore<TClient> where TClient:IClient
    {
        CRMContext _context;

        public ClientStore():this("CRMContext")
        {

        }
        public ClientStore(string constr)
        {
            _context = new CRMContext(constr);
        }
        public void CreateClient(TClient client)
        {
            ClientEntity clientEntity=(ClientEntity) AutoMapper.Mapper.Map<ClientEntity>(client);
            _context.Clients.Add(clientEntity);
            _context.SaveChanges();
        }

        public IQueryable<TClient> GetClient(SearchCriteria criteria)
        {

            var res = from c in _context.Clients
                      where c.Name==criteria.Title || String.IsNullOrEmpty(criteria.Title) /*criteria.Title==""*/
                      select c;
            return res.ProjectTo<TClient>();
        }

        public Client GetClientByID(int id)
        {
            ClientEntity Clientvalues = _context.Clients.Find(id);
            var Client = (Client)AutoMapper.Mapper.Map<Client>(Clientvalues);
            return Client;
        }

        public void UpdateClient(TClient c)

        {
            ClientEntity clientEntity = AutoMapper.Mapper.Map<ClientEntity>(c);

            _context.Entry(clientEntity).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }


        
    }
}
