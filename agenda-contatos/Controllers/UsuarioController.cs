// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Configuration;
// using Microsoft.IdentityModel.Tokens;
// using System;
// using System.IdentityModel.Tokens.Jwt;
// using System.Security.Claims;
// using System.Text;
// using System.Threading.Tasks;

// namespace agenda_contatos.Controllers
// {
//     [ApiController]
//     [Route("[controller]")]
//     public class UsuarioController : ControllerBase
//     {
//         private readonly IConfiguration _config;
        

//         public UsuarioController(IConfiguration config)
//         {
//             _config = config;
//         }

//         [HttpPost("criar")]
//         public async Task<IActionResult> CriarUsuario([FromBody] Usuario usuario)
//         {
//             // TODO: Implement user creation logic here

//             return Ok();
//         }

//         [HttpPost("login")]
//         public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
//         {
//             // TODO: Implement login logic here

//             // Check if user exists
//             if (loginRequest.Username == "exampleuser" && loginRequest.Password == "examplepassword")
//             {
//                 // Create JWT token
//                 var tokenHandler = new JwtSecurityTokenHandler();
//                 var key = Encoding.ASCII.GetBytes(_config["Jwt:Secret"]);
//                 var tokenDescriptor = new SecurityTokenDescriptor
//                 {
//                     Subject = new ClaimsIdentity(new Claim[]
//                     {
//                         new Claim(ClaimTypes.Name, loginRequest.Username)
//                     }),
//                     Expires = DateTime.UtcNow.AddDays(7),
//                     SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
//                 };
//                 var token = tokenHandler.CreateToken(tokenDescriptor);
//                 var tokenString = tokenHandler.WriteToken(token);

//                 return Ok(new { Token = tokenString });
//             }
//             else
//             {
//                 return Unauthorized();
//             }
//         }
//     }

// }
