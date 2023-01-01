using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Task1.Pages
{
    public class Donate_MoneyModel : PageModel
    {
        public bool hasData = false;
        public string date = "";
        public string anonymous = "";
        public string comment = "";
        public double amount = 0.0;

        //connections 
        public static SqlConnection sqlConnect;
        public static SqlCommand sqlCommand;
        public static string query = "";

        public void OnGet()
        {
        }
        public void OnPost()
        {
            try
            {
                hasData = true;
                date = Request.Form["fDate"];
                amount =Convert.ToDouble(Request.Form["fAmount"]);
                anonymous = Request.Form["fAno"];
                comment = Request.Form["fComment"];
                Connection conn = new Connection();
                sqlConnect = new SqlConnection(conn.getConnection);

                sqlConnect.Open();
                query = "INSERT INTO MONEY_ VALUES('" + date + "','"+amount+"','" + anonymous + "','" + comment + "','" + LoginModel.user_ID + "')";
                sqlCommand = new SqlCommand(query, sqlConnect);
                sqlCommand.ExecuteNonQuery();
                sqlConnect.Close();
            }
            catch
            {
                Console.WriteLine("Please start by login first");
            }
        }
    }
}
