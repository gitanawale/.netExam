using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCApplication.Models
{
    public class DBconn
    {
        SqlConnection cn;

        void OpenConn()
        {
            cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Exam;Integrated Security=True";
            cn.Open();
        }

        public List<Product> GetAll()
        {
            OpenConn();
            SqlCommand cmdget = new SqlCommand
            {
                Connection = cn,
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "GetProducts"
            };

            List<Product> list = new List<Product>();
            SqlDataReader dr;
            try
            {
                dr = cmdget.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new Product
                    {
                        ProductId = (int)dr["ProductId"],
                        ProductName = (string)dr["ProductName"],
                        Rate = (Decimal)dr["Rate"],
                        Description = (string)dr["Description"],
                        CategoryName = (String)dr["CategoryName"]
                    });
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
            return list;

        }

        public void update(int Productid,Product p)
        {

            OpenConn();
            SqlCommand cmd= new SqlCommand
            {
                Connection = cn,
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "UpdateProduct"
            };

            cmd.Parameters.AddWithValue("@ProductId", Productid);
            cmd.Parameters.AddWithValue("@ProductName", p.ProductName);
            cmd.Parameters.AddWithValue("@Rate", p.Rate);
            cmd.Parameters.AddWithValue("@Description",p.Description);
            cmd.Parameters.AddWithValue("@CategoryName", p.CategoryName);

            cmd.ExecuteNonQuery();
            cn.Close();
       

        }
    }
}