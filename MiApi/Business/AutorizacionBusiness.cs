using MiApi.Connection;
using MiApi.Models.Custom;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MiApi.Business
{
    public class AutorizacionBusiness : IAutorizacion
    {
        private readonly ConnectionBD _context;
        private readonly IConfiguration _configuration;

        public AutorizacionBusiness(ConnectionBD context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        private string generarToken(string idUsuario)
        {
            var key = _configuration.GetValue<string>("JwtSettings:Key");
            var keyByte = Encoding.ASCII.GetBytes(key);

            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, idUsuario));

            var credencialesToken = new SigningCredentials(
                new SymmetricSecurityKey(keyByte),
                SecurityAlgorithms.HmacSha256Signature
                );

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = credencialesToken
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

            string tokenCreado = tokenHandler.WriteToken(tokenConfig);
            
            return tokenCreado;
        } 

        public Task<AutorizacionResponse> DevolverToken(AutorizacionRequest autorizacion)
        {
            throw new NotImplementedException();
        }
    }
}
