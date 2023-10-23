using agenda_contatos.Models;
using agenda_contatos.DataAccess.Repository;
using agenda_contatos.DataAccess.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace agenda_contatos.Controllers
{
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly ILogger<ContatoRepository> _logger;
        
        public ContatoController(IContatoRepository repository, ILogger<ContatoRepository> logger)
        {
            _contatoRepository = repository;
            _logger = logger;
        }

        [HttpGet]
        [Route("api/listartodos")]
        public async Task<IActionResult> ListarTodosContatos()
        {
            var data = await _contatoRepository.ListarTodosContatos();
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpGet]
        [Route("api/listar/{id}")]
        public async Task<IActionResult> ListarContatoPorId(int id)
        {
            var data = await _contatoRepository.ListarContatoPorId(c => c.Id == id);
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpPost]
        [Route("api/criar")]
        [Consumes("application/json")]
        public async Task<IActionResult> Criar(Contato item)
        {
            try
            {
                Console.WriteLine(item.Email);
                if (ModelState.IsValid)
                {
                    await _contatoRepository.AdicionarContato(item);
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
            // if (id != obj.Id)
            // {
            //     return BadRequest();
            // }

            if (ModelState.IsValid)
            {
                var contato = await _contatoRepository.ListarContatoPorId(c => c.Id == item.Id);

                if (contato == null)
                {
                    return NotFound();
                }

                contato.Nome = item.Nome;
                contato.Email = item.Email;
                contato.Telefone = item.Telefone;

                await _contatoRepository.AtualizarContato(contato);

                var response = new { message = "O contato foi atualizado com sucesso." };
                return Ok(response);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("api/excluir/[id]")]
        public async Task<IActionResult> Excluir(int id)
        {
            try
            {
                Contato? contato = await _contatoRepository.ListarContatoPorId(c => c.Id == id);

                if (contato == null)
                {
                    return NotFound();
                }

                await _contatoRepository.ExcluirContato(contato);

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
