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

        public bool UserLogin(string userName, string pswd, out long UID)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CRMContext"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("IsUserExits", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = userName;
                cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = pswd;
                SqlParameter prmUid = cmd.Parameters.Add("@UID", SqlDbType.BigInt);
                SqlParameter prmStatus = cmd.Parameters.Add("@Status", SqlDbType.Bit);
                prmStatus.Direction = ParameterDirection.Output;
                prmUid.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                UID = Convert.ToInt64(prmUid.Value==DBNull.Value?0:prmUid.Value);
                return Convert.ToBoolean(prmStatus.Value);
            }
        }

        public CRMUser GetUserProfile(long id)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CRMContext"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spGetUserProfilebyId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UID", SqlDbType.BigInt).Value = id;
                SqlDataReader dr = cmd.ExecuteReader();
                CRMUser crmUser = null;
                if (dr.Read())
                {
                    crmUser = new CRMUser();
                    crmUser.CompanyName = Convert.ToString(dr["CompanyName"]);
                    crmUser.Username = Convert.ToString(dr["UserName"]);
                    crmUser.Password = Convert.ToString(dr["Password"]);
                    crmUser.FirstName = Convert.ToString(dr["FirstName"]);
                    crmUser.LastName = Convert.ToString(dr["LastName"]);

                }
                return crmUser;
            }
        }

        public void UpdateUserProfile(CRMUser userProfile)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CRMContext"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spUpdateUserProfile", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UID", SqlDbType.BigInt).Value = userProfile.UID;
                cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = userProfile.FirstName;
                cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = userProfile.Password;
                cmd.Parameters.Add("@Lastname", SqlDbType.VarChar).Value = userProfile.LastName;
                cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = userProfile.Username;
                cmd.Parameters.Add("@CompanyName", SqlDbType.VarChar).Value = userProfile.CompanyName;
                //cmd.Parameters.Add("@DateModifed", SqlDbType.DateTime).Value = DateTime.Now;
                //cmd.Parameters.Add("@UserType", SqlDbType.Bit).Value = userProfile.UserType;
                //cmd.Parameters.Add("@Status", SqlDbType.Int).Value = userProfile.Status;
                cmd.ExecuteNonQuery();

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
