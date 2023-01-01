using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Task1.Pages
{
    public class ViewGoodsModel : PageModel
    {
        public List<Good> getClass = new List<Good>();
        public string hasData;
        public static SqlConnection sqlConnect;
        public static SqlCommand sqlCommand;
        public SqlDataReader sqlData;
        public static string query = "";

        public void OnGet()
        {
            try
            {
                Connection conn = new Connection();
                sqlConnect = new SqlConnection(conn.getConnection);

                sqlConnect.Open();
                query = "Select* from AllocateGoods where LOGIN_ID ='"+LoginModel.user_ID+"'";
                sqlCommand = new SqlCommand(query, sqlConnect);
                sqlData = sqlCommand.ExecuteReader();

                while (sqlData.Read())
                {
                    getClass.Add(new Good(sqlData["goodsID"].ToString(), sqlData["Date_OF_Allocation"].ToString(), sqlData["Goods"].ToString()));
                }
                sqlConnect.Close();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
            }
        }

        public void OnPost()
        {
        }
    }
    public class Good
    {
        //AG.Date_OF_Allocation, Ag.Goods, D.DISASTER_DESCRIPTION,D.STARTING_DATE, D.ENDING_DATE,D.LOCATION
        public string ID;
        public string Date_OF_Allocation;
        public string Goods;


        public Good()
        {

        }
        public Good(string ID, string A, string B)
        {
            this.ID = ID;
            this.Date_OF_Allocation = A;
            this.Goods = B;

        }

        public string getID()
        {
            return this.ID;
        }
        public string getDate_OF_Allocation()
        {
            return this.Date_OF_Allocation;
        }
        public string getGoods()
        {
            return this.Goods;
        }
    }
}
