
using agenda_contatos.Models;
using agenda_contatos.DTOs;
using agenda_contatos.DataAccess.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace agenda_contatos.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _iUsuarioService;
        private readonly IMapper _mapper;
        
        public UsuarioController(IUsuarioService iUsuarioService, IMapper mapper)
        {
            _iUsuarioService = iUsuarioService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("criarUsuario")]
        [Consumes("application/json")]
        public async Task<IActionResult> Criar(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _iUsuarioService.AdicionarUsuario(usuario);
                    var response = new { message = "O usuário foi criado com sucesso." };
                    return Ok(response);
                }
                else
                {
                    return UnprocessableEntity(new {message = "Há algum erro com os dados enviados ou com o processamento deles."});
                }
            }
            catch (Exception)
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        [Route("listar/{email}")]
        public async Task<IActionResult> ListarContatoPorEmail(string email)
        {
            var usuario = await _iUsuarioService.ListarUsuarioPorEmail(c => c.Email == email);
            if (usuario == null)
            {
                return NotFound();
            }

            var usuarioDTO = _mapper.Map<UsuarioDTO>(usuario);

            return Ok(usuarioDTO);
        }

        [HttpDelete]
        [Route("excluir/{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            try
            {
                var usuario = await _iUsuarioService.ListarUsuarioPorEmail(u => u.Id == id);

                if (usuario == null)
                {
                    return NotFound();
                }

                await _iUsuarioService.ExcluirUsuario(usuario);

                var response = new { message = "O usuário foi deletado com sucesso." };
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
