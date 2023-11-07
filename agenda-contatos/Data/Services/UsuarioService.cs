using System.Linq.Expressions;
using agenda_contatos.Models;
using agenda_contatos.DataAccess.Repositories;
namespace agenda_contatos.DataAccess.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly ApplicationDbContext _context;
        private readonly IUsuarioRepository _iUsuarioRepository;

        public UsuarioService(ApplicationDbContext context, IUsuarioRepository iUsuarioRepository)
        {
            _context = context;
            _iUsuarioRepository = iUsuarioRepository;
        }

        public async Task AdicionarUsuario(Usuario usuario)
        {
            await _iUsuarioRepository.AdicionarUsuario(usuario);
        }

        public async Task ExcluirUsuario(Usuario usuario)
        {
            await _iUsuarioRepository.ExcluirUsuario(usuario);
        }

        public async Task<List<Usuario>> ListarTodosUsuarios()
        {
            return await _iUsuarioRepository.ListarTodosUsuarios();
        }

        public async Task<Usuario> ListarUsuarioPorEmail(Expression<Func<Usuario,bool>> filter)
        {
            return await _iUsuarioRepository.ListarUsuarioPorEmail(filter);
        }

        // public async Task AtualizarContato(Contato contato)
        // {
        //     await _contatoRepository.AtualizarContato(contato);
        // }
    }
}
