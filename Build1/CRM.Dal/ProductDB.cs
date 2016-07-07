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
        public List<Product> GetProducts(long startIndex, long endIndex, string prodcutName)
        {
            List<Product> lstproducts = new List<Product>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CRMContext"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("spGetProducts", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@StartIndex", SqlDbType.BigInt).Value = startIndex;
            cmd.Parameters.Add("@endIndex", SqlDbType.BigInt).Value = endIndex;

            cmd.Parameters.Add("@ProductName", SqlDbType.VarChar).Value = prodcutName;


            SqlDataReader dr = cmd.ExecuteReader();  //ExecuteNonQuery ExecuetScalar 
            Product product = null;
            while (dr.Read())
            {
                product= new Product();
                product.Name = dr["ProductName"].ToString();
                product.Id = Convert.ToInt32(dr["ProductId"]);
                product.Versions = Convert.ToString(dr["Version"]);
                product.CompanyName = Convert.ToString(dr["CompanyName"]);
                lstproducts.Add(product);
            }
            return (lstproducts);
        }


        public Product GetProductInfo(int productId)

        {
            SqlConnection con = null;
            try
            {
                
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["CRMContext"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("spGetProductInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductId", SqlDbType.BigInt).Value = productId;
                SqlDataReader dr = cmd.ExecuteReader();  //ExecuteNonQuery ExecuetScalar 
                Product p =null;
                if (dr.Read())
                {
                    p = new Product();
                    p.Name = dr["ProductName"].ToString();
                    p.Id = Convert.ToInt64(dr["ProductId"]);
                    p.Versions = dr["Version"].ToString();
                    p.CompanyId = Convert.ToInt64(dr["CompanyId"]);
                }
                return p;

            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {

                if (con != null && con.State == ConnectionState.Open)
                    con.Close();
            }




        }


        public List<Company> GetCompanies()
        {
            SqlConnection con = null; 
            try
            {
                List<Company> lstcompanies = new List<Company>();
                 con = new SqlConnection(ConfigurationManager.ConnectionStrings["CRMContext"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("spGetCompanies", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();  //ExecuteNonQuery ExecuetScalar 
                Company company = null;
                while (dr.Read())
                {
                    company = new Company();
                    company.Name = dr["CompanyName"].ToString();
                    company.CompanyId = Convert.ToInt32(dr["CompanyId"]);

                    lstcompanies.Add(company);
                }
                return (lstcompanies);
                
            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {

                if (con != null && con.State == ConnectionState.Open)
                    con.Close();
            }


            }
    }
}
