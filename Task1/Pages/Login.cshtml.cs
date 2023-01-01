using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;

namespace Task1.Pages
{
    public class LoginModel : PageModel
    {

        public bool hasData = false;
        public string email = "";
        public string password = "";
        public static int user_ID;

        public SqlConnection sqlConnect;
        public SqlCommand sqlCommand;
        public SqlDataReader sqlData;
        public static string query = "";

        public void OnPost()
        {
            hasData = true;
            email = Request.Form["txtEmail"];
            password = Request.Form["txtPassword"];
            Connection conn = new Connection();
            Hash hash = new Hash();
            sqlConnect = new SqlConnection(conn.getConnection);

            sqlConnect.Open();
            query = "SELECT* FROM LOGINS WHERE EMAIL='" + email + "' AND ACCOUNT_PASSWORD='" + hash.getHash(password) + "'";
            sqlCommand = new SqlCommand(query, sqlConnect);
            sqlData = sqlCommand.ExecuteReader();

            if(sqlData.Read())
            {
                user_ID = Convert.ToInt32(sqlData["LOGIN_ID"].ToString());
            }
            else
            {

            }
            sqlConnect.Close();
        }
    }
}
