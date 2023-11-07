using agenda_contatos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using agenda_contatos.DataAccess.Services;
using agenda_contatos.DataAccess.Repositories;
using System.Text;
using System.Text.Json;
using AutoMapper;
using agenda_contatos.DTOs;

namespace agenda_contatos.Controllers;

[Route("api/autenticacao")]
public class AutenticacaoController : ControllerBase
{
    private readonly IAuthRepository _iAuthRepository;
    private readonly IMapper _mapper;
    public AutenticacaoController(IAuthRepository iAuthRepository, IMapper mapper)
    {
        _iAuthRepository = iAuthRepository;
        _mapper = mapper;
    } 

    [HttpPost]
    [Route("auth")]
    [AllowAnonymous]
    public async Task<ActionResult<dynamic>> Autenticacao([FromBody] AuthDTO dadosAcesso )
    {
        try
        {
            if (ModelState.IsValid)
            {
                var usuario = await _iAuthRepository.GetUsuario( x => 
                    x.Email.ToLower() == dadosAcesso.Email.ToLower() && 
                    x.Senha.ToLower() == dadosAcesso.Senha.ToLower()
                );

                if(usuario == null)
                {
                    return NotFound(new { 
                        message = $"Não encontrou o {dadosAcesso.Email} e a {dadosAcesso.Senha} informados." 
                    });
                }
                var tokenService = new TokenService();
                var token = tokenService.GenerateToken(usuario);
                usuario.Senha = "";
                return Ok(new
                    {
                        usuario = usuario,
                        token = token
                    }
                );
            }
            else
            {
                return BadRequest(new { message = "Não foi possível autenticar o usuário. 1" });
            }
        }
        catch(Exception error)
        {
            Console.WriteLine(error.Message);
            Console.WriteLine(error.StackTrace);
            return BadRequest(error.Message);
        }
    }

    [HttpGet]
    [Route("anonimo")]
    [AllowAnonymous]
    public string Anonimo() => "Anonimo";

    [HttpGet]
    [Route("autenticado")]
    [Authorize]
    public string Autenticado() => String.Format("Autenticado - {0}", User.Identity.Name);

    [HttpGet]
    [Route("usuario")]
    [Authorize(Roles = "usuario, administrador")]
    public string Usuario() => "usuario";

    [HttpGet]
    [Route("administrador")]
    [Authorize(Roles = "administrador")]
    public string Admin() => "Admin";
}
