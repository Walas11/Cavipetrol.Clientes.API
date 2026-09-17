using Cavipetrol.Clientes.DTOs.Cliente;
using Cavipetrol.Clientes.Repositories.Clientes.Interface;
using Cavipetrol.Clientes.Services.Clientes.Interface;

namespace Cavipetrol.Clientes.Services.Clientes
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<ClienteDto> ObtenerPorIdentificacionAsync(string identificacion)
        {
            var cliente = await _clienteRepository.ObtenerPorIdentificacionAsync(identificacion);

            if (cliente == null)
                return null;

            return new ClienteDto
            {
                ClienteID = cliente.ClienteID,
                Identificacion = cliente.Identificacion,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                Email = cliente.Email,
                Telefono = cliente.Telefono,
                Direccion = cliente.Direccion,
                FechaRegistro = cliente.FechaRegistro
            };
        }
    }
}
