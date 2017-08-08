using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
namespace dojodachi.Controllers
{
    public class dojoController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult index()
        {
            Dachi meep = new Dachi();
            int en = meep.energy;
            int ful = meep.fullness;
            int me = meep.meals;
            int hap = meep.happy;
            ViewBag.energy = en;
            ViewBag.fullness = ful;
            ViewBag.meals = me;
            ViewBag.happy = hap;
            HttpContext.Session.SetObjectAsJson("dachi", meep);
            return View("index");
        }
        [HttpGet]
        [Route("dojodachi")]
        public IActionResult page()
        {
            Dachi meep = HttpContext.Session.GetObjectFromJson<Dachi>("dachi");
            int en = meep.energy;
            int ful = meep.fullness;
            int me = meep.meals;
            int hap = meep.happy;
            ViewBag.energy = en;
            ViewBag.fullness = ful;
            ViewBag.meals = me;
            ViewBag.happy = hap;
            HttpContext.Session.SetObjectAsJson("dachi", meep);
            return View("index");
            
        }


        [HttpPost]
        [Route("dachi")]
        public IActionResult dachi(string button)
        {
            Dachi meep = HttpContext.Session.GetObjectFromJson<Dachi>("dachi");
            if (button == "Feed")
            {
                meep.feed(meep);
                List<string> check = meep.status(meep);
                if(check.Contains("fine")){
                    HttpContext.Session.SetObjectAsJson("dachi", meep);
                    return RedirectToAction("page");
                }
                else if(check.Contains("win"))
                {
                    return View("win");
                }
                else if(check.Contains("dead"))
                {
                    return View("dead");
                }
            }
            else if(button == "Play")
            {
                meep.play(meep);
                List<string> check = meep.status(meep);
                if(check.Contains("fine")){
                    HttpContext.Session.SetObjectAsJson("dachi", meep);
                    return RedirectToAction("page");
                }
                else if(check.Contains("win"))
                {
                    return View("win");
                }
                else if(check.Contains("dead"))
                {
                    return View("dead");
                }
            }
            else if(button == "Work")
            {
                meep.work(meep);
                List<string> check = meep.status(meep);
                if(check.Contains("fine")){
                    HttpContext.Session.SetObjectAsJson("dachi", meep);
                    return RedirectToAction("page");
                }
                else if(check.Contains("win"))
                {
                    return View("win");
                }
                else if(check.Contains("dead"))
                {
                    return View("dead");
                }
            }
            else if (button == "Sleep")
            {
                meep.sleep(meep);
                List<string> check = meep.status(meep);
                if(check.Contains("fine")){
                    HttpContext.Session.SetObjectAsJson("dachi", meep);
                    return RedirectToAction("page");
                }
                else if(check.Contains("win"))
                {
                    return View("win");
                }
                else if(check.Contains("dead"))
                {
                    return View("dead");
                }
            }
            
            return View("index");
            
        }
    }
}