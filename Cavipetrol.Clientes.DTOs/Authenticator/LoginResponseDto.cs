namespace Cavipetrol.Clientes.DTOs.Authenticator
{
    public class LoginResponseDto
    {
        public string Token { get; set; }
        public DateTime Expiracion { get; set; }
    }
}
