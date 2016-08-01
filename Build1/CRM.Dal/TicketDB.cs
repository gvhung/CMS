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
                cmd.Parameters.Add("@Title", SqlDbType.VarChar, 200).Value = ticket.Title;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar, 400).Value = ticket.Description;
                cmd.Parameters.Add("@ComponentId", SqlDbType.BigInt).Value = ticket.ComponentId;
                cmd.Parameters.Add("@VersionId", SqlDbType.BigInt).Value = ticket.VersionId;
                cmd.Parameters.Add("@ProductId", SqlDbType.BigInt).Value = ticket.ProductId;
                cmd.Parameters.Add("@CompanyId", SqlDbType.BigInt).Value = ticket.CompanyId;
                cmd.Parameters.Add("@CreatedBy", SqlDbType.BigInt).Value = ticket.CreatedBy;
                cmd.Parameters.Add("@SeviorityId", SqlDbType.Int).Value = ticket.SeviorityId;
                cmd.Parameters.Add("@PriorityId", SqlDbType.Int).Value = ticket.PriorityId;
                cmd.Parameters.Add("@TicketTypeId", SqlDbType.Int).Value = ticket.TicketTypeId;

                int i = cmd.ExecuteNonQuery();
                con.Close();
                return i;
            }

        }

        public List<Seviority> GetSeviorities()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CRMContext"].ConnectionString))
                {
                    con.Open();
                    List<Seviority> lstTickets = new List<Seviority>();
                    Seviority seviority = null;
                    SqlCommand cmd = new SqlCommand("spSeviorities", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        seviority = new Seviority();
                        seviority.Id = Convert.ToInt32(dr["SeviorityId"]);
                        seviority.SeviorityName = Convert.ToString(dr["Seviority"]);
                        lstTickets.Add(seviority);
                    }
                    return lstTickets;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Ticket GetTicketNo()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CRMContext"].ConnectionString);
                con.Open();
                Ticket ticketNo = null;
                SqlCommand cmd = new SqlCommand("spGetTicketNo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    ticketNo = new Ticket();
                    ticketNo.TicketNo = Convert.ToInt64(dr["Name"]);
                    
                }
                return ticketNo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Templats GetTemplate()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CRMContext"].ConnectionString);
                con.Open();
                Templats template = null;
                SqlCommand cmd = new SqlCommand("spGetTemplate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    template = new Templats();
                    template.Name = Convert.ToString(dr["Name"]);
                    template.Template = Convert.ToString(dr["Template"]);
                }
                return template;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteTicket(long Id)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CRMContext"].ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("spDeleteTickert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@TicketId", SqlDbType.BigInt).Value = Id;
                if (con.State != ConnectionState.Open)
                    con.Open();
                int i = cmd.ExecuteNonQuery();
                return i;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                    con.Close();
            }

        }

        public List<Priority> GetPriorities()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CRMContext"].ConnectionString);
                con.Open();
                List<Priority> lstPriorities = new List<Priority>();
                Priority priority = null;
                SqlCommand cmd = new SqlCommand("spPriorities", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    priority = new Priority();
                    priority.Id = Convert.ToInt32(dr["PriorityId"]);
                    priority.PriorityName = Convert.ToString(dr["Priority"]);
                    lstPriorities.Add(priority);
                }
                return lstPriorities;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TicketType> GetTicketTypes()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CRMContext"].ConnectionString))
            {
                con.Open();
                List<TicketType> lstTicketTypes = new List<TicketType>();
                TicketType ticketType = null;
                SqlCommand cmd = new SqlCommand("spGetTicketType", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ticketType = new TicketType();
                    ticketType.Id = Convert.ToInt32(dr["TicketTypeId"]);
                    ticketType.Type = Convert.ToString(dr["TicketType"]);
                    lstTicketTypes.Add(ticketType);
                }
                return lstTicketTypes;
            }
        }

        public List<Ticket> GetAllTicket(string clientname, int StartIndex, int EndIndex)
        {
            List<Ticket> lstTickets = new List<Ticket>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CRMContext"].ConnectionString))
            {
                con.Open();
                Ticket ticketModel = null;
                SqlCommand cmd = new SqlCommand("spGetTickets", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyName", clientname);
                cmd.Parameters.AddWithValue("@StartIndex", StartIndex);
                cmd.Parameters.AddWithValue("@EndIndex", EndIndex);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ticketModel = new Ticket();
                    ticketModel.TicketId = Convert.ToInt64(dr["TicketId"]);
                    ticketModel.TicketNo = Convert.ToInt64(dr["TicketNo"]);
                    ticketModel.CompanyName = Convert.ToString(dr["CompanyName"]);
                    ticketModel.ProductName = Convert.ToString(dr["ProductName"]);
                    ticketModel.ComponentName = Convert.ToString(dr["ComponentName"]);
                    ticketModel.Version = Convert.ToString(dr["Version"]);
                    ticketModel.Title = Convert.ToString(dr["Title"]);
                    ticketModel.UserName = Convert.ToString(dr["FirstName"]);
                    ticketModel.Assignee = Convert.ToString(dr["Assignee"]);
                    ticketModel.DateCreated = Convert.ToDateTime(dr["DateCreated"]);
                    lstTickets.Add(ticketModel);
                }
                return lstTickets;
            }
        }

        public List<SelectListDTO> BindCompanies()
        {
            List<SelectListDTO> lstCompanies = new List<SelectListDTO>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CRMContext"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spBindCompanies", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                SelectListDTO companyModel = null;
                while (dr.Read())
                {
                    companyModel = new SelectListDTO();
                    companyModel.Name = Convert.ToString(dr["CompanyName"]);
                    companyModel.ID = Convert.ToInt64(dr["CompanyId"]);
                    lstCompanies.Add(companyModel);
                }
                return lstCompanies;
            }
        }

        public Ticket GetTicketBy(int id)
        {
            //Ticket tickets = new Ticket();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CRMContext"].ConnectionString))
            {
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
                    ticketModel.TicketId = Convert.ToInt64(dr["TicketId"]);
                    ticketModel.Description = Convert.ToString(dr["Description"]);
                    ticketModel.VersionId = Convert.ToInt32(dr["Versionid"]);
                    ticketModel.ProductId = Convert.ToInt64(dr["ProductId"]);
                    ticketModel.ComponentId = Convert.ToInt64(dr["ComponentId"]);
                    ticketModel.CompanyId = Convert.ToInt64(dr["CompanyId"]);
                    ticketModel.TicketTypeId = Convert.ToInt32(dr["TicketTypeId"]);
                    ticketModel.PriorityId = Convert.ToInt32(dr["PriorityId"]);
                    ticketModel.SeviorityId = Convert.ToInt32(dr["SeviorityId"]);
                }
                return ticketModel;
            }
        }

    }

}