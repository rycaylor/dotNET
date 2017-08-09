using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using form.Models;

namespace form.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.errors = ModelState.Values;
            return View();
        }

        [HttpPost]
        [Route("validate")]
        public IActionResult validate(User newUser)
        {
            TryValidateModel(newUser);
            if(ModelState.IsValid)
            {
                return View("success");
            }
            else
            {
                ViewBag.errors = ModelState.Values;
                return View("Index");

            }
        }
    }
}
