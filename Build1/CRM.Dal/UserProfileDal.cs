using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Model;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace CRM.Dal
{
    public class UserProfileDal
    {
        public void Create(CRMUser user)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CRMconstr"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spUserProfileCreate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@Guid", Guid.NewGuid());
                cmd.Parameters.AddWithValue("@UserType", user.UserType);
                cmd.Parameters.AddWithValue("@CompanyId", user.CompanyId);
                cmd.Parameters.AddWithValue("Password", user.Password);
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }
    }

}
