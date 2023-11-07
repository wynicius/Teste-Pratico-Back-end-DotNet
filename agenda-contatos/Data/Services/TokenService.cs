using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using agenda_contatos.DTOs;
using agenda_contatos.Models;
using Microsoft.IdentityModel.Tokens;

namespace agenda_contatos.DataAccess.Services;
public class TokenService
{
    public string GenerateToken(AuthDTO usuario)

    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var key = Encoding.ASCII.GetBytes(Configuration.Secret);

        var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            SigningCredentials = credentials,
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, usuario?.NomeDeUsuario?.ToString()),
                new Claim(ClaimTypes.Email, usuario?.Email?.ToString()),
                new Claim(ClaimTypes.Role, usuario?.Role?.ToString())
            }),

            Expires = DateTime.UtcNow.AddHours(2),

        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }

    public static ClaimsIdentity GenerateClaims(Usuario usuario)
    {
        var ci = new ClaimsIdentity();
        ci.AddClaim(
            new Claim(ClaimTypes.Name, usuario.Email)
        );
            ci.AddClaim(new Claim(ClaimTypes.Role, usuario.Role));

        return ci;
    }
}