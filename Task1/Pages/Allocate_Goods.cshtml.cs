using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Task1.Pages
{
    public class Allocate_GoodsModel : PageModel
    {
        public static SqlConnection sqlConnect;
        public static SqlCommand sqlCommand;
        public bool hasData = false;
        public string query = "", date;
        public string goods;

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

                Connection conn = new Connection();
                sqlConnect = new SqlConnection(conn.getConnection);
                sqlConnect.Open();
                query = "INSERT INTO AllocateGoods VALUES('" + date + "','" + goods + "','" + LoginModel.user_ID + "', '" + Convert.ToInt32(id) + "')";
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
