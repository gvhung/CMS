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
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CRMDB;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_Ticket", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Title", ticket.Title);
            cmd.Parameters.AddWithValue("@Description", ticket.Description);
            cmd.Parameters.AddWithValue("@Priority", ticket.Priority);
            cmd.Parameters.AddWithValue("@Version", ticket.Version);
            cmd.Parameters.AddWithValue("@ProductId", ticket.ProductId);
            cmd.Parameters.AddWithValue("@ModuleId", ticket.ModuleId);
            cmd.Parameters.AddWithValue("@TicketType", ticket.TicketType);
            cmd.ExecuteNonQuery();
            con.Close();
        }


        public List<Ticket> GetAllTicket()
        {
            List<Ticket> lstTickets = new List<Ticket>();
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CRMDB;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_GetAllTickets",con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            Ticket ticketModel = null;
            while (dr.Read())
            {
                ticketModel = new Ticket();
                ticketModel.Title = Convert.ToString(dr["Title"]);
                ticketModel.TicketType = Convert.ToInt32(dr["TicketType"]);
                ticketModel.TicketNo = Convert.ToInt32(dr["TicketNo"]);
                ticketModel.ProductId = Convert.ToInt32(dr["ProductId"]);
                ticketModel.ModuleId = Convert.ToInt32(dr["ModuleId"]);
                ticketModel.Version = Convert.ToString(dr["Version"]);
                lstTickets.Add(ticketModel);
            }
            return lstTickets;
        }
    }
}
