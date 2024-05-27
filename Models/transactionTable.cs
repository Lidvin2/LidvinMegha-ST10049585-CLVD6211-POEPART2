using System.Data.SqlClient;

namespace CLVD6211_POEPART2.Models
{
    public class transactionTable
    {
        public static string con_string = "Server=tcp:clvd-sql-khumalocraft.database.windows.net,1433;Initial Catalog=Clvd-db;Persist Security Info=False;User ID=KHUMALOCRAFT;Password=Dead@2424;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public static SqlConnection con = new SqlConnection(con_string);

        public int OrderID { get; set; }

        public int UserID { get; set; }

        public int ProductID { get; set; }

        public int insert_transaction(transactionTable t)
        {
            try
            {
                string sql = "INSERT INTO transactionTable (orderID, userID, productID) VALUES (@OrderID, @UserID, @ProductID)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@OrderID", t.OrderID);
                cmd.Parameters.AddWithValue("@UserID", t.UserID);
                cmd.Parameters.AddWithValue("@ProductID", t.ProductID);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
