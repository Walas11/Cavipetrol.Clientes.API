using Cavipetrol.Clientes.Repositories.Clientes.Entities;
using Cavipetrol.Clientes.Repositories.Clientes.Interface;
using Cavipetrol.Clientes.Repositories.ContextDB;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Cavipetrol.Clientes.Repositories.Clientes
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ClienteEntity> ObtenerPorIdentificacionAsync(string identificacion)
        {
            var parametro = new SqlParameter("@Identificacion", identificacion);

            var cliente = await _context.Clientes
                .FromSqlRaw("EXEC sp_ObtenerCliente @Identificacion", parametro)
                .AsNoTracking()
                .ToListAsync();

            return cliente.FirstOrDefault();
        }
    }
}
