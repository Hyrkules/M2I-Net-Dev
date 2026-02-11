using Articles.Api.Dtos;
using Articles.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Articles.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        //Service d'authentification injecté par DI
        private readonly IAuthService _authService;

        // Constructeur : injecte automatiquement le service
        public AuthController(IAuthService authService)
        {
          _authService = authService;
        }

        /// <summary>
        /// Authentifie un utilisateur et retourne un JWT
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public ActionResult<LoginResponseDto> Login([FromBody] LoginDto dto) 
        {
            //Validation ddu model qui n'est plus obligatoire car APIController
            if(!ModelState.IsValid) return BadRequest(ModelState);

            //Appel au service d'authentification
            //Si succès => retourne le responsedto avec le token
            //Si echec => lance UnauthorizedAccessException => Middleware => 401
            var reponse = _authService.Authenticate(dto);

            return Ok(reponse);
        }
    }
}
