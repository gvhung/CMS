using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using CRM.Store.Entities;
using CRM.Model;
using CRM.Web.ViewModel;
namespace CRM.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Mapper.Initialize(cnfg =>
            {
                cnfg.CreateMap<UserProfileEntity, CRMUser>();
                cnfg.CreateMap<Ticket, TicketEntity>();
                cnfg.CreateMap<TicketEntity, Ticket>();
                cnfg.CreateMap<Ticket, TicketListModel>();

                cnfg.CreateMap<ClientEntity, Client>();
                cnfg.CreateMap<Client, ClientEntity>();
                cnfg.CreateMap<Client, ClientListModel>();
                cnfg.CreateMap<ClientEditModel, Client>();
                cnfg.CreateMap<Client, ClientEditModel>();

                cnfg.CreateMap<ProductEntity, Product>();
                cnfg.CreateMap<Product, ProductListModel>();
                cnfg.CreateMap<Product, ProductEntity>();


            }
            );
        }


    }      
}
