using Cavipetrol.Clientes.DTOs.Authenticator;

namespace Cavipetrol.Clientes.Services.Authenticator
{
    public interface IAuthService
    {
        bool ValidarCredenciales(string usuario, string password);
        LoginResponseDto GenerarToken(string usuario);
    }
}
