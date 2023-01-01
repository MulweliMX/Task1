using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Task1.Pages
{
    public class Capture_purchaseModel : PageModel
    {
        public static SqlConnection sqlConnect;
        public static SqlCommand sqlCommand;
        public static SqlDataReader data;
        public bool hasData = false;
        public string query = "", date;
        public string goods;
        public double amount;

        public double val1, val2;
        public string q1, q2; 

        public double money()
        {
            try
            {
                Connection conn = new Connection();
                sqlConnect = new SqlConnection(conn.getConnection);
                sqlConnect.Open();
                q1 = "select* from Money_ where LOGIN_ID='"+LoginModel.user_ID+"'";
                sqlCommand = new SqlCommand(q1,sqlConnect);
                data = sqlCommand.ExecuteReader();
                while(data.Read())
                {
                    val1+= Convert.ToDouble(data["amount"].ToString());
                }
                sqlConnect.Close();
               
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
            }

            try
            {
                Connection conn = new Connection();
                sqlConnect = new SqlConnection(conn.getConnection);
                sqlConnect.Open();
                q2 = "select Total_Amount_Captured from CaptureGoods where LOGIN_ID='" + LoginModel.user_ID + "'";
                sqlCommand = new SqlCommand(q2, sqlConnect);
                data = sqlCommand.ExecuteReader();
                while (data.Read())
                {
                    val2 += Convert.ToDouble(data["Total_Amount_Captured"].ToString());
                }
                sqlConnect.Close();

            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
            }
            return Convert.ToDouble(val1-val2);
        }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            String id = Request.Query["id"];

            try
            {
                hasData = true;
                date = Request.Form["dateAll"];
                goods = Request.Form["activeGood"];
                amount = Convert.ToDouble(Request.Form["amountAllocate"]);
                Connection conn = new Connection();
                sqlConnect = new SqlConnection(conn.getConnection);
                sqlConnect.Open();
                query = "INSERT INTO CaptureGoods VALUES('" + date + "','"+amount+"','" + goods + "','" + LoginModel.user_ID + "')";
                sqlCommand = new SqlCommand(query, sqlConnect);
                sqlCommand.ExecuteNonQuery();
                sqlConnect.Close();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
            }
        }
    }
}
