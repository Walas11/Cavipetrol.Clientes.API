using Cavipetrol.Clientes.DTOs.Cliente;

namespace Cavipetrol.Clientes.Services.Clientes.Interface
{
    public interface IClienteService
    {
        Task<ClienteDto> ObtenerPorIdentificacionAsync(string identificacion);
    }
}
