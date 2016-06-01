﻿using System;
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
        ICRMContext _context;
        public ClientStore(ICRMContext context)
        {
            _context = context;
        }
        public void CreateClient(TClient client)
        {
            ClientEntity clientEntity=(ClientEntity) AutoMapper.Mapper.Map<ClientEntity>(client);
            _context.Clients.Add(clientEntity);
            _context.SaveChanges();
        }

        public IQueryable<TClient> GetClient()
        {
            return _context.Clients.ProjectTo<TClient>();
        }


    }
}
