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
        // Cria uma instância do token, em formato de string, com base na chave de segurança (token).
        var tokenHandler = new JwtSecurityTokenHandler();

        // Encoding.ASCII.GetBytes()  converte a chave de segurança (token) em um array de bytes.
        // Configutation.PrivateKey   é a chave de segurança (token) armazenada na classe Configuration.
        // Cria a chave de segurança (token) com base na chave de segurança (token) armazenada na classe Configuration. Serve para criptografar e descriptografar o token.
        var key = Encoding.ASCII.GetBytes(Configuration.Secret);

        // SigningCredentials é a chave do Token.
        // SigningCredentials( CHAVE , ALGORITMO DE CRIPTOGRAFIA Hmac256 )
        var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
        
        // SecurityTokenDescriptor == é a descrição do token, contendo as informações do usuário.  
        // Subject == é o usuário. 
        // ClaimsIdentity == é a identidade do usuário.
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            SigningCredentials = credentials,
            Subject = new ClaimsIdentity(new Claim[]
            {
                // Claim é uma informação do usuário que será armazenada no token.
                new Claim(ClaimTypes.Name, usuario?.NomeDeUsuario?.ToString()),
                new Claim(ClaimTypes.Email, usuario?.Email?.ToString()),
                new Claim(ClaimTypes.Role, usuario?.Role?.ToString())
            }),

            Expires = DateTime.UtcNow.AddHours(2),

        };

        // Cria a string do token com base nas informações do usuário.
        var token = tokenHandler.CreateToken(tokenDescriptor);

        // Retorna a string do token.
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