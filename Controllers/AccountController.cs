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
        public IActionResult Verify(Account acc)
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
                con.Close();

                return View("Verify");
            }
            else
            {
                con.Close();
                // throw Exception();
                // Console.Writeline("Hata oldu yaw");
                ViewBag.Message="Kullanıcı adı veya şifre yanlış.";
                return View("Login");
            }

            // return BadRequest();
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
            con.ConnectionString = "Server=SEMIH; database=penetration;Trusted_Connection=True;user=SEMIH/usluk";
        }
        
    }
}
