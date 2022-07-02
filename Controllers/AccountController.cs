using Microsoft.AspNetCore.Mvc;
using MVCLoginPage.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace MVCLoginPage.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private SqlDataReader dr;

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Account(Account acc)
        {
            // var users = PutValue();
            // foreach (var user in users)
            // {
            //     if (user.Password == acc.Password)
            //         return View(user);
            // }

            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from Users where Name='" + acc.Name + "' and password='" + acc.Password + "'";
            dr = com.ExecuteReader();
            //var u = PutValue();
            if (dr.Read())
            {

                //dr.GetString(3)
                if (dr.GetString(3)=="1")
                {
                    return View("Admin");
                }
                //Console.WriteLine("{0}\t{1}\t{2}\t{3}", dr.GetInt32(0),
                //    dr.GetString(1), dr.GetString(2), dr.GetString(3));

                con.Close();

                return View("User");
            }
            else
            {
                con.Close();
                ViewBag.Message="Kullanıcı adı veya şifre yanlış.";
                return View("Login");
            }
        }

        // private List<UserModel> PutValue()
        // {
        //     var users = new List<UserModel>
        //     {
        //         new UserModel{Name="admin",Password="123456"},
        //         new UserModel{Name="semih",Password="123456"},
        //     };
        //     return users;
        // }

        void connectionString()
        {
            con.ConnectionString = "Server=DESKTOP-GNT513T; database=penetration;Trusted_Connection=True;user=DESKTOP-GNT513T/Abdullah Taha";
        }
        
    }
}
