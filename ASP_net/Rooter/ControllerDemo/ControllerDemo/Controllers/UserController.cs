using Microsoft.AspNetCore.Mvc;

namespace ControllerDemo.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid user ID.");
            }
            if (id > 100)
            {
                return NotFound("User not found.");
            }
            return View();
        }

        public IActionResult GetUserJson(int id) { 
            var user = new { Id = id, Name = "User", Mail = "gfdfzf@cfez.com" };
            return Json(user);
        }

        public IActionResult Create() { 
            return RedirectToAction("Index");
        }

        public IActionResult AdminPanel(int? id)
        {
            if (id != 1)
            {
                return Forbid();
            }
            return View();
        }
    }
}
