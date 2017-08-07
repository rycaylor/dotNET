using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace calling_card.Controllers
{
    public class HelloController : Controller
    {
        [HttpGet]
        [Route("card/{first}/{last}/{age}/{fav}")]
        public JsonResult card(string first, string last, int num, string fav)
        {
            
            return Json(new {first = first, last = last, num = num, fav = fav });
        }
    }
}