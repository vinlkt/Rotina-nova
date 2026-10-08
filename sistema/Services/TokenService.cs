using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sistema.Models;
using ClinicaVeterinaria.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace sistema.Services
{
    public class TokenService
    {
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration) => _configuration = configuration;
        public string GeraToken(Usuario usuario)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, usuario.Id.ToString()), new (ClaimTypes.Name, usuario.Nome), new(ClaimTypes.Email, usuario.Email), new(ClaimTypes.Role, usuario.Perfil)
            };
            var keyText = _configuration["Jwt:Key"]
                ?? throw new InvalidOperationException("Jwt:Key não configurada.");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyText));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var minutes = _configuration.GetValue <int> ("Jwt:ExpireMinutes", 30);
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"], audience: _configuration["Jwt:Audience"], claims: claims, notBefore: DateTime.UtcNow, expires: DateTime.UtcNow.AddMinutes(minutes),
                    signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
            
        }
    }
}