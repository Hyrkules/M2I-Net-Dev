using Articles.Api.Dtos;
using Articles.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Articles.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuteurController : ControllerBase
    {
        private readonly IAuteurService _service;

        public AuteurController(IAuteurService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<AuteurDto>> GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<AuteurDto> GetById([FromRoute] int id)
        {
            var auteur = _service.GetById(id);

            if (auteur == null) return NotFound();

            return Ok(auteur);
        }

        [HttpPost]
        public ActionResult<AuteurDto> Create([FromBody] AuteurCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var auteurCree = _service.Add(dto);

            return CreatedAtAction(nameof(GetById), new { id = auteurCree.Id }, auteurCree);
        }
    }
}
