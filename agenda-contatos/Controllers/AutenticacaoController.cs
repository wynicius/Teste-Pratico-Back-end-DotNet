using agenda_contatos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using agenda_contatos.DataAccess.Services;
using agenda_contatos.DataAccess.Repositories;
using agenda_contatos.DTOs;

namespace agenda_contatos.Controllers
{
    [Route("api/autenticacao")]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        private readonly TokenService _tokenService;

        public AutenticacaoController(IAuthRepository authRepository, TokenService tokenService)
        {
            _authRepository = authRepository;
            _tokenService = tokenService;
        } 

        [HttpPost("auth")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Autenticacao([FromBody] AuthDTO dadosAcesso )
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var usuario = await _authRepository.GetUsuario( x => 
                    x.Email.ToLower() == dadosAcesso.Email.ToLower() && 
                    x.Senha.ToLower() == dadosAcesso.Senha.ToLower()
                );

                var token = _tokenService.GenerateToken(usuario);
                usuario.Senha = "";
                
                return Ok(new
                    {
                        usuario = usuario,
                        token = token
                    }
                );
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("anonimo")]
        [AllowAnonymous]
        public string Anonimo() => "Anonimo";

        [HttpGet("autenticado")]
        [Authorize]
        public string Autenticado() => String.Format("Autenticado - {0}", User.Identity.Name);

        [HttpGet("usuario")]
        [Authorize(Roles = "usuario, administrador")]
        public string Usuario() => "usuario";

        [HttpGet("administrador")]
        [Authorize(Roles = "administrador")]
        public string Admin() => "Admin";
    }
}