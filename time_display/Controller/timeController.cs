using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace time_display.Controllers
{
    public class timeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {

        return View("index");
        }
    }
}