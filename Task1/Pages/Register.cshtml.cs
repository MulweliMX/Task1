using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace Task1.Pages
{
    public class RegisterModel : PageModel
    {

        public bool hasData = false;
        public string first_name="";
        public string second_name="";
        public string gender="";
        public string email="";
        public string password="";

        //connections 
        public static SqlConnection sqlConnect;
        public static SqlCommand sqlCommand;
        public static string query = "";

        public void OnPost()
        {
            hasData = true;
            first_name = Request.Form["fname"];
            second_name= Request.Form["sname"];
            gender= Request.Form["txtGender"];
            email= Request.Form["txtEmail"];
            password= Request.Form["txtPassword"];

            Connection conn = new Connection();
            Hash hash = new Hash();
            sqlConnect = new SqlConnection(conn.getConnection);

            sqlConnect.Open();
            query = "INSERT INTO LOGINS VALUES('" + first_name + "','" + second_name + "','" + gender + "','" + email + "','" + hash.getHash(password) + "')";
            sqlCommand = new SqlCommand(query, sqlConnect);
            sqlCommand.ExecuteNonQuery();
            sqlConnect.Close();
        }
        public void OnGet()
        {

        }
    }
      
}
