using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Task1.Pages
{
    public class Allocate_MoneyModel : PageModel
    {
        public static SqlConnection sqlConnect;
        public static SqlCommand sqlCommand;
        public bool hasData = false;
        public string query = "",date;
        public double amount;

        public void OnPost()
        {
            String id = Request.Query["id"];

            try
            {
                hasData = true;
                date = Request.Form["dateAll"];
                amount =Convert.ToDouble(Request.Form["amountAllocate"]);

                Connection conn = new Connection();
                sqlConnect = new SqlConnection(conn.getConnection);
                sqlConnect.Open();
                query = "INSERT INTO AllocateMoney VALUES('" + date + "','" + amount + "','" + LoginModel.user_ID+ "', '"+Convert.ToInt32(id) +"')";
                sqlCommand = new SqlCommand(query,sqlConnect);
                sqlCommand.ExecuteNonQuery();
                sqlConnect.Close();
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
            }
        }
        public void OnGet()
        {

        }
    }
}
