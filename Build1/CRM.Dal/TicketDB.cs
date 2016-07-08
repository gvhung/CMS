using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Model;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace CRM.Dal
{
    public class TicketDB
    {

        public int AddTicket(Ticket ticket)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CRMContext"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spInsertTicket", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TicketNo", ticket.TicketNo);
                cmd.Parameters.AddWithValue("@Title", ticket.Title);
                cmd.Parameters.AddWithValue("@Description", ticket.Description);
                cmd.Parameters.AddWithValue("@ComponentId", ticket.ComponentId);
                cmd.Parameters.AddWithValue("@Version", ticket.Version);
                cmd.Parameters.AddWithValue("@ProductId", ticket.ProductId);
                cmd.Parameters.AddWithValue("@CompanyId", ticket.CompanyId);
                cmd.Parameters.AddWithValue("@CreatedBy", ticket.CreatedBy);
                int i = cmd.ExecuteNonQuery();
                con.Close();
                return i;
            }
           
        }



        public List<Ticket> GetAllTicket(string clientname, int StartIndex, int EndIndex)
        {
            List<Ticket> lstTickets = new List<Ticket>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CRMContext"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("spGetTickets", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ClientName", clientname);
            cmd.Parameters.AddWithValue("@StartIndex", StartIndex);
            cmd.Parameters.AddWithValue("@EndIndex", EndIndex);
            SqlDataReader dr = cmd.ExecuteReader();
            Ticket ticketModel = null;
            while (dr.Read())
            {
                ticketModel = new Ticket();
                ticketModel.TicketNo = Convert.ToInt64(dr["TicketNo"]);
                ticketModel.CompanyName = Convert.ToString(dr["ClientName"]);
                ticketModel.ProductName = Convert.ToString(dr["ProductName"]);
                ticketModel.ComponentName = Convert.ToString(dr["ComponentName"]);
                ticketModel.Version = Convert.ToString(dr["Version"]);
                ticketModel.Title = Convert.ToString(dr["Title"]);
                ticketModel.Assignee = Convert.ToString(dr["Assignee"]);
                ticketModel.DateCreated = Convert.ToDateTime(dr["DateCreated"]);
                lstTickets.Add(ticketModel);
            }
            return lstTickets;
        }

        public List<Company> BindCompanies()
        {
            List<Company> lstCompanies = new List<Company>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CRMContext"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("spBindCompanies", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            Company companyModel = null;
            while (dr.Read())
            {
                companyModel = new Company();

                companyModel.CompanyName = Convert.ToString(dr["ClientName"]);
                companyModel.CompanyId = Convert.ToInt64(dr["CompanyId"]);
                lstCompanies.Add(companyModel);
            }
            return lstCompanies;
        }

        public List<Product> BindProducts()
        {
            List<Product> lstProducts = new List<Product>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CRMContext"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("spBindproducts", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            Product productModel = null;
            while (dr.Read())
            {
                productModel = new Product();

                productModel.Name = Convert.ToString(dr["ProductName"]);
                productModel.Id = Convert.ToInt64(dr["ProductId"]);
                lstProducts.Add(productModel);
            }
            return lstProducts;
        }

        public List<Component> BindComponent()
        {
            List<Component> lstComponent = new List<Component>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CRMContext"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("spBindComponents", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            Component componentModel = null;
            while (dr.Read())
            {
                componentModel = new Component();

                componentModel.ComponentName = Convert.ToString(dr["ComponentName"]);
                componentModel.ComponentId = Convert.ToInt64(dr["ComponentId"]);
                lstComponent.Add(componentModel);
            }
            return lstComponent;
        }


        public Ticket GetTicketBy(int id)
        {
            //Ticket tickets = new Ticket();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CRMContext"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("spGetTicketById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TicketId", id);
            SqlDataReader dr = cmd.ExecuteReader();
            Ticket ticketModel = null;
            if (dr.Read())
            {
                ticketModel = new Ticket();
                ticketModel.Title = Convert.ToString(dr["Title"]);
                ticketModel.Description = Convert.ToString(dr["Description"]);
                //ticketModel.ModuleId= Convert.ToInt32(dr["ModuleId"]);
                //ticketModel.TicketType = Convert.ToInt32(dr["TicketType"]);
                ticketModel.TicketNo = Convert.ToInt32(dr["TicketNo"]);
                ticketModel.Version = Convert.ToString(dr["Version"]);
                //ticketModel.Priority = Convert.ToInt32(dr["Priority"]);

            }
            return ticketModel;
        }

    }
}
