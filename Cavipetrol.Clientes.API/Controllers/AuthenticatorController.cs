using Cavipetrol.Clientes.DTOs.Authenticator;
using Cavipetrol.Clientes.Services.Authenticator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cavipetrol.Clientes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticatorController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthenticatorController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestDto request)
        {
            if (!_authService.ValidarCredenciales(request.Usuario, request.Password))
                return Unauthorized(new { mensaje = "Usuario o contraseña incorrectos" });

            var response = _authService.GenerarToken(request.Usuario);
            return Ok(response);
        }
    }
}
