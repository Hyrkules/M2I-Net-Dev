using Articles.API.Dtos;
using Articles.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Articles.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _service;

        public ArticleController(IArticleService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<ArticleDto>> GetAll([FromQuery] int? auteurId)
        {
            if (auteurId.HasValue)
            {
                return Ok(_service.GetByAuteurId(auteurId.Value));
            }

            return Ok(_service.GetAll());
        }
        [HttpGet("article/{id}")]
        public ActionResult<ArticleDto> GetById([FromRoute] int id)
        {
            var article = _service.GetById(id);

            if(article == null) return NotFound();

            return Ok(article);
        }

        [Authorize]
        [HttpPost]
        public ActionResult<ArticleDto> Create([FromBody] ArticleCreateDto dto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var articleCree = _service.Add(dto);

            return CreatedAtAction(nameof(GetById), new {Id = articleCree.Id}, articleCree);
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] ArticleUpdateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _service.Update(id, dto);
            
             return NoContent();
        }

        [Authorize(Roles ="Admin")]
        [HttpDelete]
        public IActionResult Delete([FromRoute] int id)
        {
            _service.Delete(id);
            return NoContent();
        }

    }
}
