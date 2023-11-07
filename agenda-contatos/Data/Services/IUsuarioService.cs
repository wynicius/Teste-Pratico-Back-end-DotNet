using System.Linq.Expressions;
using agenda_contatos.Models;

namespace agenda_contatos.DataAccess.Services
{
    public interface IUsuarioService
    {
        Task AdicionarUsuario(Usuario usuario);
        Task ExcluirUsuario(Usuario usuario);
        Task<List<Usuario>> ListarTodosUsuarios();
        // Task AtualizarContato(Usuario contato);
        Task<Usuario> ListarUsuarioPorEmail(Expression<Func<Usuario,bool>> filter);
    }
}
