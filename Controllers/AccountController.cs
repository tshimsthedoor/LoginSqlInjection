using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginSqlInjection.Models;
using System.Data.SqlClient;

namespace LoginSqlInjection.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        void ConnectionString()
        {
            con.ConnectionString = "Data Source=(LocalDb)\\MSSQLLocalDb;Initial Catalog=BabyStore2;Integrated Security=true;";
        }

        [HttpPost]
        public ActionResult Verify(Account acc)
        {
            ConnectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from tbl_User where name='" + acc.Name + "' and password='" + acc.Password + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View("Create");
            }
            else
            {
                con.Close();
                return View("Error");
            }


        }

        public ActionResult LogOut()
        {
            int userid = (int)Session["ID"];
            Session.Abandon();
            return RedirectToAction("Login", "Account");
        }
    }
}



    

