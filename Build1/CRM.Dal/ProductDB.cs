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
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CRMContext"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("spAddProduct", con);
                    cmd.Parameters.Add("@ProductName", SqlDbType.VarChar, 100).Value = p.Name;
                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Product> GetProducts(long startIndex, long endIndex, string prodcutName)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CRMContext"].ConnectionString);
            try
            {
                List<Product> lstproducts = new List<Product>();
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
                    product = new Product();
                    product.Name = dr["ProductName"].ToString();
                    product.Id = Convert.ToInt32(dr["ProductId"]);
                    product.Versions = Convert.ToString(dr["Version"]);
                    product.CompanyName = Convert.ToString(dr["CompanyName"]);
                    product.VersionId = Convert.ToInt32(dr["VersionId"]);
                    lstproducts.Add(product);
                }
                return (lstproducts);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        public List<Product> GetProducts(long companyId)
        {
            List<Product> lstProducts = new List<Product>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CRMContext"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("spBindproducts", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            Product productdto = null;
            while (dr.Read())
            {
                productdto = new Product();

                productdto.Name = Convert.ToString(dr["ProductName"]);
                productdto.Id = Convert.ToInt64(dr["ProductId"]);
                lstProducts.Add(productdto);
            }
            return lstProducts;
        }

        public List<Component> GetComponents(long productId)
        {
            List<Component> lstComponents = new List<Component>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CRMContext"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("spGetComponents", con);
            cmd.Parameters.Add("@ProductId", SqlDbType.BigInt).Value = productId;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            Component componentDto = null;
            while (dr.Read())
            {
                componentDto = new Component();

                componentDto.ComponentName = Convert.ToString(dr["ComponentName"]);
                componentDto.ComponentId = Convert.ToInt64(dr["ComponentId"]);
                lstComponents.Add(componentDto);
            }
            return lstComponents;
        }

        public List<ProductVersion> GetVersions(long productId)
        {
            List<ProductVersion> lstVersions = new List<ProductVersion>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CRMContext"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("spGetVersions", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ProductId", SqlDbType.BigInt).Value = productId;
            SqlDataReader dr = cmd.ExecuteReader();
            ProductVersion versions = null;
            while (dr.Read())
            {
                versions = new ProductVersion();

                versions.VersionName = Convert.ToString(dr["Version"]);
                versions.VersionId = Convert.ToInt64(dr["VersionId"]);
                lstVersions.Add(versions);
            }
            return lstVersions;
        }

        public void UpdateProduct(long productid, string OldVersion, string version)
        {
            SqlConnection con = null;
            try
            {

                con = new SqlConnection(ConfigurationManager.ConnectionStrings["CRMContext"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("spUpdateProduct", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ProductName", SqlDbType.BigInt).Value = productid;
                cmd.Parameters.Add("@Oldversion", SqlDbType.VarChar).Value = OldVersion;
                cmd.Parameters.Add("@Version", SqlDbType.VarChar).Value = version;

                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

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
                Product p = null;
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
        public void CreateProduct(Product product)

        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["CRMContext"].ConnectionString);

                con.Open();
                SqlCommand cmd = new SqlCommand("spCreateProduct", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductName", product.Name);
                cmd.Parameters.AddWithValue("@Version", product.Versions);
                cmd.Parameters.AddWithValue("@CompanyId", product.CompanyId);

                cmd.ExecuteNonQuery();


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


        public void DeleteProduct(long versionId)

        {
            SqlConnection con = null;
            try
            {

                con = new SqlConnection(ConfigurationManager.ConnectionStrings["CRMContext"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("spDeleteProduct", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@versionId", SqlDbType.BigInt).Value = versionId;

                cmd.ExecuteNonQuery();



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