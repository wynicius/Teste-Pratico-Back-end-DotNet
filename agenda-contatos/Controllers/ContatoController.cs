using agenda_contatos.Models;
using agenda_contatos.DataAccess.Services;
using Microsoft.AspNetCore.Mvc;
using agenda_contatos.DTOs;
using AutoMapper;

namespace agenda_contatos.Controllers
{
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoService _contatoService;
        private readonly ILogger<ContatoService> _logger;
        private readonly IMapper _mapper;
        
        public ContatoController(IContatoService contatoService, ILogger<ContatoService> logger, IMapper mapper)
        {
            _contatoService = contatoService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("api/listartodos")]
        public async Task<IActionResult> ListarTodosContatos()
        {
            var contatos = await _contatoService.ListarTodosContatos();
            if (contatos == null)
            {
                return NotFound();
            }

            var contatosDTO = _mapper.Map<ContatoDTO[]>(contatos);

            return Ok(contatosDTO);
        }

        [HttpGet]
        [Route("api/listar/{id}")]
        public async Task<IActionResult> ListarContatoPorId(int id)
        {
            var contato = await _contatoService.ListarContatoPorId(c => c.Id == id);
            if (contato == null)
            {
                return NotFound();
            }

            var clienteDTO = _mapper.Map<ContatoDTO>(contato);

            return Ok(clienteDTO);
        }

        [HttpPost]
        [Route("api/criar")]
        [Consumes("application/json")]
        public async Task<IActionResult> Criar(Contato contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _contatoService.AdicionarContato(contato);
                    var response = new { message = "O contato foi criado com sucesso." };
                    return Ok(response);
                }
                else
                {
                    return UnprocessableEntity(ModelState);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("api/editar/")]
        [Consumes("application/json")]
        public async Task<IActionResult> Atualizar(Contato item)
        {
            if (ModelState.IsValid)
            {
                var contato = await _contatoService.ListarContatoPorId(c => c.Id == item.Id);

                if (contato == null)
                {
                    return NotFound();
                }

                contato.Nome = item.Nome;
                contato.Email = item.Email;
                contato.Telefone = item.Telefone;

                await _contatoService.AtualizarContato(contato);

                var response = new { message = "O contato foi atualizado com sucesso." };
                return Ok(response);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("api/excluir/{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            try
            {
                var contato = await _contatoService.ListarContatoPorId(c => c.Id == id);

                if (contato == null)
                {
                    return NotFound();
                }

                await _contatoService.ExcluirContato(contato);

                var response = new { message = "O contato foi deletado com sucesso." };
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
