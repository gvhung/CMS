using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
namespace CRM.Dal
{
   public  class UserDB
    {
        public bool IsEmailIdExists(string emailId)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CRMContext"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SpIsEmailIdExists", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@EmailId", SqlDbType.VarChar).Value = emailId;
                SqlParameter prmStatus= cmd.Parameters.Add("@Status", SqlDbType.Bit);
                prmStatus.Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                return Convert.ToBoolean(prmStatus.Value);



            }

        }
    }
}
