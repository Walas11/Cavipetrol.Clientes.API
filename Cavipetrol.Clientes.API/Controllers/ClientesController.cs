using Cavipetrol.Clientes.Services.Clientes.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cavipetrol.Clientes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet("{identificacion}")]
        public async Task<IActionResult> GetPorIdentificacion(string identificacion)
        {
            var cliente = await _clienteService.ObtenerPorIdentificacionAsync(identificacion);

            if (cliente == null)
                return NotFound(new { mensaje = $"No se encontró un cliente con identificación {identificacion}" });

            return Ok(cliente);
        }
    }
}
