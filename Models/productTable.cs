using System.Data.SqlClient;

namespace CLVD6211_POEPART2.Models
{
    public class productTable
    {
        public static string con_string = "Server=tcp:clvd-sql-khumalocraft.database.windows.net,1433;Initial Catalog=Clvd-db;Persist Security Info=False;User ID=KHUMALOCRAFT;Password=Dead@2424;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public static SqlConnection con = new SqlConnection(con_string);

        public int ProductID { get; set; }

        public string Name { get; set; }

        public string Price { get; set; }

        public string Category { get; set; }

        public int Availability { get; set; }

        public int insert_product(productTable p)
        {

            try
            {
                string sql = "INSERT INTO productTable (productName, productPrice, productCategory, productAvailability) VALUES (@Name, @Price, @Category, @Availability)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Name", p.Name);
                cmd.Parameters.AddWithValue("@Price", p.Price);
                cmd.Parameters.AddWithValue("@Category", p.Category);
                cmd.Parameters.AddWithValue("@Availability", p.Availability);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                // For now, rethrow the exception
                throw ex;
            }


        }

        public static List<productTable> GetAllProducts()
        {
            List<productTable> products = new List<productTable>();

            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT * FROM productTable";
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    productTable product = new productTable();
                    product.ProductID = Convert.ToInt32(rdr["productID"]);
                    product.Name = rdr["productName"].ToString();
                    product.Price = rdr["productPrice"].ToString();
                    product.Category = rdr["productCategory"].ToString();
                    product.Availability = Convert.ToInt32(rdr["productAvailability"]);

                    products.Add(product);
                }
            }

            return products;
        }
    }
}
