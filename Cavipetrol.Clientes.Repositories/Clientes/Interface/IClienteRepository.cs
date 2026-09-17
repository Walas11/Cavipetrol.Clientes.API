using Cavipetrol.Clientes.Repositories.Clientes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cavipetrol.Clientes.Repositories.Clientes.Interface
{
    public interface IClienteRepository
    {
        Task<ClienteEntity> ObtenerPorIdentificacionAsync(string identificacion);
    }
}
