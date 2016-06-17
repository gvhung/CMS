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
    public class CompanyStore<TCompany> : ICompanyStore<TCompany> where TCompany : ICompany
    {
        CRMContext _context;

        public CompanyStore() : this("CRMContext")
        {

        }
        public CompanyStore(string constr)
        {
            _context = new CRMContext(constr);
        }


        public Guid CreateClient<TUser>(TCompany client, TUser user) where TUser : IUser
        {
            try
            {

                ///converting client to cliententity

                CompanyEntity clientEntity = AutoMapper.Mapper.Map<CompanyEntity>(client);

                //set DateCreated to System current date so that even wrong date is coming from TClient, it will not insert wrong date
                clientEntity.DateCreated = DateTime.Now;
                user.UID = Guid.NewGuid();
                user.Status = 0;
                user.UserType = 1;  //Admin of client
                user.DateCreated = DateTime.Now;
                clientEntity.Users = new List<UserProfileEntity>();
                clientEntity.Users.Add(AutoMapper.Mapper.Map<UserProfileEntity>(user));
                _context.Clients.Add(clientEntity);
                _context.SaveChanges();
                return clientEntity.Users.First().UID;
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                throw new Exception("Email Address already exists");
            }
        }

        public IQueryable<TCompany> GetClients(SearchCriteria criteria)
        {

            var res = from c in _context.Clients
                      where c.Name == criteria.Title || String.IsNullOrEmpty(criteria.Title) /*criteria.Title==""*/
                      select c;
            return res.ProjectTo<TCompany>();
        }

        public IQueryable<Company> GetClients()
        {
            throw new NotImplementedException();
        }

        public Company GetClientByID(int id)
        {
            CompanyEntity Clientvalues = _context.Clients.Find(id);
            var Client = (Company)AutoMapper.Mapper.Map<Company>(Clientvalues);
            return Client;
        }

        public void UpdateClient(TCompany c)

        {
            CompanyEntity clientEntity = AutoMapper.Mapper.Map<CompanyEntity>(c);

            _context.Entry(clientEntity).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public IQueryable<TCompany> GetClient()
        {
            return _context.Clients.ProjectTo<TCompany>();
        }

        public List<TCompany> GetClient(TCompany Client)
        {
            throw new NotImplementedException();
        }

    }
}
