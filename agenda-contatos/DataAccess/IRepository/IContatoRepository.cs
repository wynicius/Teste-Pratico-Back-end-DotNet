using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using agenda_contatos.Models;

namespace agenda_contatos.DataAccess.IRepository
{
    public interface IContatoRepository
    {
        Task<List<Contato>> ListarTodosContatos();
        Task<Contato> ListarContatoPorId(Expression<Func<Contato,bool>> filter);
        Task AddContato(Contato contato);
        Task UpdateContato(Contato contato);
        Task RemoveContato(Contato contato);
    }
}
 