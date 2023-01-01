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
    public class DisasterModel : PageModel
    {

        public bool hasData = false;

        public string startDate="";
        public string endDate = "";
        public string location="";
        public string description="";
        public string aid="";
        public string newAid="";
        public string erro = "";
        public string userId="";
        public SqlConnection sqlConnect;
        public SqlCommand sqlCommand;
        public SqlDataReader sqlData;
        public static string query = "";
        public void OnGet()
        {
        }
        public void OnPost()
        {
              
                try
                {
                    hasData = true;
                    startDate = Request.Form["SDate"];
                    endDate = Request.Form["EDate"];
                    location = Request.Form["txtAddress"];
                    description = Request.Form["txtDescription"];
                    aid = Request.Form["aid"];
                    newAid = "";

                    if (aid.Equals("Other"))
                    {
                        newAid = Request.Form["txtNewAid"];
                    }

                    Connection conn = new Connection();
                    sqlConnect = new SqlConnection(conn.getConnection);

                    sqlConnect.Open();
                    query = "INSERT INTO DISASTER VALUES('" + startDate + "','" + endDate + "','" + location + "','" + description + "','" + aid + "','" + newAid + "','" + LoginModel.user_ID + "')";
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
