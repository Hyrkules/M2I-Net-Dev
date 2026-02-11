using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VueDemo.Models;

namespace VueDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var message = "Hello from HomeController.Index!";
            return View((object)message);
        }

        public IActionResult ifElse()
        {
            return View();
        }
        public IActionResult forEach()
        {
            return View();
        }
        public IActionResult avecModeleSimple()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
