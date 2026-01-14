using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Integration.SM.API.Endpoints.DTOs;
using Microsoft.IdentityModel.Tokens;
using Integration.SM.API.Endpoints.Models;

namespace Integration.SM.API.Endpoints
{
    public static class AuthEndpoint
    {
        const string PATH = "/auth";
        private static readonly Dictionary<string, AutenticadoDTO> usuariosCadastrados = new Dictionary<string, AutenticadoDTO>
        {
            { "admin", new AutenticadoDTO("admin", "senha@123", ["user", "admin"]) },
            { "usuario", new AutenticadoDTO("usuario", "senha@123", ["user"]) }
        };

        public static void MapAuthEndpoint(this WebApplication app, AppSettings config)
        {
            app.MapPost(PATH, (LoginDTO login) =>
            {
                if (usuariosCadastrados.TryGetValue(login.Username, out AutenticadoDTO user))
                {
                    if (user.Password == login.Password)
                    {
                        var token = GerarToken(login, config);
                        return Results.Ok(new { Token = token });
                    }
                }
                return Results.Unauthorized();
            })
            .AllowAnonymous()
            .WithName("Auth")
            .WithOpenApi(info => new (info)
            {
                Summary = "Autenticacao Mock",
                Description = "Endpoint que gera um Token"
            });
        }

        private static string GerarToken(LoginDTO login, AppSettings config)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(config.SecretKey);
            
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, login.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, login.Username),
            };

            if (usuariosCadastrados.TryGetValue(login.Username, out AutenticadoDTO user))
            {
                foreach (var role in user.Role)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = config.Issuer,
                Audience = config.Audience,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), 
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
                    
        }

    }
}