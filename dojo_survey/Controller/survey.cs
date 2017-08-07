using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
 
namespace dojo_survey.Controllers
{
    public class surveyController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult index()
        {   
            return View("index");
        }

        [HttpPost]
        [Route("form")]
        public IActionResult form(string name, string location, string language, string comment)
        {   
            ViewBag.name = name;
            ViewBag.location = location;
            ViewBag.language = language;
            ViewBag.comment = comment;
            return View("result");

        }
    }

}