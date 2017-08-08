using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using quoting.Connectors;

namespace quoting.Controllers
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
        [Route("submit")]

        public IActionResult submit(string name, string content)
        {
            string query = $"INSERT INTO quotes (name, content, created_at, updated_at) VALUES ('{name}', '{content}', NOW(), NOW())";
            MySqlConnector.Execute(query);
            string str = "SELECT * FROM quotes";
            var quotes = MySqlConnector.Query(str);
            ViewBag.quotes = quotes;
            return View("quotes");
        }
        [HttpPost]
        [Route("quotes")]
        public IActionResult quote()
        {
            string query = "SELECT * FROM quotes";
            var quotes = MySqlConnector.Query(query);
            ViewBag.quotes = quotes;
            return View("quotes");
        }
    }
}
