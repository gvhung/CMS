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

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CRMconstr"].ConnectionString))
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




        public string Create(CRMUser user)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CRMconstr"].ConnectionString))
            {
                string res = Convert.ToString(Guid.NewGuid());
                con.Open();
                SqlCommand cmd = new SqlCommand("spUserCreate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@Guid", res);
                cmd.Parameters.AddWithValue("@UserType", user.UserType);
                cmd.Parameters.AddWithValue("@CompanyId", user.CompanyId);
                cmd.Parameters.AddWithValue("Password", user.Password);
                cmd.ExecuteNonQuery();
                con.Close();
                return res;
            }
        }

    }
}
