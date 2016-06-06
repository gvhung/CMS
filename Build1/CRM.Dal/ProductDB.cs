using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Model;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace CRM.Dal
{
    public class ProductDB
    {

        public void AddProduct(Product p)
        {
            try
            {
                using (SqlConnection con=new SqlConnection(ConfigurationManager.ConnectionStrings["CRMContext"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("spAddProduct", con);
                    cmd.Parameters.Add("@ProductName", SqlDbType.VarChar, 100).Value=p.Name;
                    cmd.ExecuteNonQuery();

                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
