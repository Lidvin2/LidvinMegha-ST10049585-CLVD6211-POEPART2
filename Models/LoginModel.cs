﻿using System.Data.SqlClient;

namespace CLVD6211_POEPART2.Models
{
    public class LoginModel
    {
        public static string con_string = "Server=tcp:clvd-sql-khumalocraft.database.windows.net,1433;Initial Catalog=Clvd-db;Persist Security Info=False;User ID=KHUMALOCRAFT;Password=Dead@2424;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public int SelectUser(string email, string name)
        {
            int userID = -1;
            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT userID FROM userTable WHERE userEmail = @Email AND userName = @Name";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Name", name);
                try
                {
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        userID = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return userID;
        }
    }
}
