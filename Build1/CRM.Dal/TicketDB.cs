using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Model;
using System.Data.SqlClient;
using System.Data;

namespace CRM.Dal
{
    public class TicketDB
    {

        public void AddTicket(Ticket ticket)
        {
            SqlConnection con = new SqlConnection("CRMconstr");
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_Ticket", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Title", ticket.Title);
            cmd.Parameters.AddWithValue("@Description", ticket.Description);
            //cmd.Parameters.AddWithValue("@Priority", ticket.Priority);
            cmd.Parameters.AddWithValue("@Version", ticket.Version);
            cmd.Parameters.AddWithValue("@ProductId", ticket.ProductId);
           // cmd.Parameters.AddWithValue("@ModuleId", ticket.ModuleId);
           // cmd.Parameters.AddWithValue("@TicketType", ticket.TicketType);
            cmd.ExecuteNonQuery();
            con.Close();
        }



        public List<Ticket> GetAllTicket()
        {
            List<Ticket> lstTickets = new List<Ticket>();
            SqlConnection con = new SqlConnection("CRMconstr");
            con.Open();
            SqlCommand cmd = new SqlCommand("spGetAllTickets", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            Ticket ticketModel = null;
            while (dr.Read())
            {
                ticketModel = new Ticket();
                ticketModel.TicketId = Convert.ToInt32(dr["TicketId"]);
                ticketModel.Title = Convert.ToString(dr["Title"]);
               // ticketModel.TicketType = Convert.ToInt32(dr["TicketType"]);
                ticketModel.TicketNo = Convert.ToInt32(dr["TicketNo"]);
                //ticketModel.ProductId = Convert.ToInt32(dr["ProductId"]);
                //ticketModel.ModuleId = Convert.ToInt32(dr["ModuleId"]);
                //ticketModel.Version = Convert.ToString(dr["Version"]);
                //ticketModel.CompanyName = Convert.ToString(dr["ClientName"]);
                //ticketModel.Priority = Convert.ToInt32(dr["Priority"]);
                lstTickets.Add(ticketModel);
            }
            return lstTickets;
        }


        public Ticket GetTicketBy(int id)
        {
            //Ticket tickets = new Ticket();
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CRMDB;Integrated Security=True");
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
