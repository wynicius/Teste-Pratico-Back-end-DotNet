using System.Linq.Expressions;
using agenda_contatos.Models;
using agenda_contatos.DataAccess.Repositories;
namespace agenda_contatos.DataAccess.Services
{
    public class ContatoService : IContatoService
    {
        private readonly ApplicationDbContext _context;
        private readonly IContatoRepository _contatoRepository;

        public ContatoService(ApplicationDbContext context, IContatoRepository contatoRepository)
        {
            _context = context;
            _contatoRepository = contatoRepository;
        }

        public async Task<List<Contato>> ListarTodosContatos()
        {
            return await _contatoRepository.ListarTodosContatos();
        }

        public async Task<Contato> ListarContatoPorId(Expression<Func<Contato,bool>> filter)
        {
            return await _contatoRepository.ListarContatoPorId(filter);
        }

        public async Task AdicionarContato(Contato contato)
        {
            await _contatoRepository.AdicionarContato(contato);
        }

        public async Task AtualizarContato(Contato contato)
        {
            await _contatoRepository.AtualizarContato(contato);
        }

        public async Task ExcluirContato(Contato contato)
        {
            await _contatoRepository.ExcluirContato(contato);
        }
    }
}
