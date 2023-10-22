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
        public async Task<IActionResult> GetTodosContatos()
        {
            var data = await _contatoRepository.ListarTodosContatos();
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPost]
        [Route("api/criar")]
        [Consumes("application/json")]
        public async Task<IActionResult> Create(Contato item)
        {
            try
            {
                Console.WriteLine(item.Email);
                if (ModelState.IsValid)
                {
                    await _contatoRepository.AddContato(item);
                    var response = new { message = "O contato foi criado com sucesso." };
                    return Ok(response);
                    _logger.LogInformation("Criação de contato");
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                _logger.LogError(e.Message);
            }
        }

        [HttpPut]
        [Route("api/editar/{id}")]
        [Consumes("application/json")]
        public async Task<IActionResult> Update(int id, [FromBody] Contato obj)
        {
            if (id != obj.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                Contato? contato = await _contatoRepository.ListarContatoPorId(c => c.Id == id);

                if (contato == null)
                {
                    return NotFound();
                }

                contato.Nome = obj.Nome;
                contato.Email = obj.Email;
                contato.Telefone = obj.Telefone;

                await _contatoRepository.UpdateContato(contato);

                var response = new { message = "O contato foi atualizado com sucesso." };
                return Ok(response);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("api/deletar/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Contato? contato = await _contatoRepository.ListarContatoPorId(c => c.Id == id);

                if (contato == null)
                {
                    return NotFound();
                }

                await _contatoRepository.RemoveContato(contato);

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
