using System.Linq.Expressions;
using agenda_contatos.Models;

namespace agenda_contatos.DataAccess.Repositories
{
    public interface IUsuarioRepository
    {
        Task AdicionarUsuario(Usuario usuario);
        Task ExcluirUsuario(Usuario usuario);
        Task<List<Usuario>> ListarTodosUsuarios();
        Task<Usuario> ListarUsuarioPorEmail(Expression<Func<Usuario,bool>> filter);

    }
}
 