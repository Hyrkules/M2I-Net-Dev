using Microsoft.AspNetCore.Mvc;

namespace RoutingDemo.Controllers
{
    /// <summary>
    /// Utiliser des tokens : mots clés remplacable
    /// 
    /// </summary>
    public class DemoController : Controller
    {
        [Route("[controller]/[action]")]
        public IActionResult Index()
        {
            return Content("OK");
        }

        //public IActionResult Test()
        //{
        //    return Content("")
        //}
    }
}
