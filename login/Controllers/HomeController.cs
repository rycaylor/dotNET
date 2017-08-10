using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using login.Models;
using DbConnection;
namespace login.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("validate")]
        public IActionResult Validate(User newUser)
        {
            TryValidateModel(newUser);
            if(ModelState.IsValid)
            {
                string query = $"INSERT INTO users (first_name, last_name, email, password, created_at, updated_at) VALUES ('{newUser.FirstName}', '{newUser.LastName}', '{newUser.Email}', '{newUser.Password}', NOW(), NOW())";
                DbConnector.Execute(query);
                return View("success");
            }
            else
            {
                return View("Index");

            }
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            return View("login");
        }

        [HttpPost]
        [Route("try")]
        public IActionResult Log(UserTest test)
        {
            TryValidateModel(test);
            if(ModelState.IsValid)
            {
                string query = $"SELECT * FROM users WHERE (email = '{test.Email}' && password = '{test.Password}')";
                List<Dictionary<string, object>> user = DbConnector.Query(query);
                if (user.Count > 0)
                {
                    return View("success");
                }
                else
                {
                    return View("login");
                }

                
            }
            else
            {
                return View("login");

            }
        }

    }
}

