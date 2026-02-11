using Articles.API.Dtos;
using Articles.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Articles.API.Controllers
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
        public ActionResult<AuteurDto> GetById(int id)
        {
            var auteur = _service.GetById(id);

            if(auteur == null) return NotFound();
            return Ok(auteur);

        }

        [HttpPost]
        [Authorize]
        public ActionResult<AuteurDto> Create(AuteurCreateDto dto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var auteurCree = _service.Add(dto);

            return CreatedAtAction(nameof(GetById), new {id = auteurCree.Id}, auteurCree);
        }
    }
}
