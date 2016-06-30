using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CRM.Model;

namespace CRM.Dal
{
    public class UserDB
    {
        public long CreateCompany(string compnyName)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CRMContext"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spCreateCompany", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ClientName", SqlDbType.VarChar).Value = compnyName;
                cmd.Parameters.Add("@TicketStartNumber", SqlDbType.BigInt).Value = 0;
                cmd.Parameters.Add("@CreatedBy", SqlDbType.BigInt).Value = 0;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = 0;
                cmd.Parameters.Add("@CurrentTicketNumber", SqlDbType.BigInt).Value = 0;

                SqlParameter prmCompanyId = cmd.Parameters.Add("@CompanyId", SqlDbType.BigInt);
                prmCompanyId.Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                return Convert.ToInt64(prmCompanyId.Value);



            }



        }
        public bool IsEmailIdExists(string emailId)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CRMContext"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SpIsEmailIdExists", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@EmailId", SqlDbType.VarChar).Value = emailId;
                SqlParameter prmStatus = cmd.Parameters.Add("@Status", SqlDbType.Bit);
                prmStatus.Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                return Convert.ToBoolean(prmStatus.Value);
            }

        }

        public void Activate(string id)
        {

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CRMContext"].ConnectionString))
            {
                string res = Convert.ToString(Guid.NewGuid());
                con.Open();
                SqlCommand cmd = new SqlCommand("spActiveUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@guid", id);
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }


        public string RegisterUser(CRMUser user)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CRMContext"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spRegisterUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@CompanyName", user.CompanyName);
                SqlParameter prmGuid = cmd.Parameters.Add("@Guid", SqlDbType.UniqueIdentifier);
                prmGuid.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                return Convert.ToString(prmGuid.Value);
            }
        }

    }
}
