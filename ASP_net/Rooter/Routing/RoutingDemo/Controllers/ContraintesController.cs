using Microsoft.AspNetCore.Mvc;

namespace RoutingDemo.Controllers
{
    /// <summary>
    /// Permettre de valider les paramètres
    /// </summary>

    [Route("test")]

    public class ContraintesController : Controller
    {
        [Route("number/{id:int}")]
        public IActionResult Number(int id)
        {
            return Content("ici");
        }

        [Route("range/{value:int:range(1,100)}")]
        public IActionResult Range(int value)
        {
            return Content($"Valeur dans la plage : {value}");
        }

        [Route("name/{value:alpha:minlength(3)}")] //Alpha pour spécifier lettre uniquement
        public IActionResult Name(string value)
        {
            return Content($"Nom Valide : {value}");
        }
    }
}
