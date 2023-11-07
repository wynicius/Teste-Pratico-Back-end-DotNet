using System.Linq.Expressions;
using agenda_contatos.DTOs;

namespace agenda_contatos.DataAccess.Repositories
{
    public interface IAuthRepository
    {
        Task<AuthDTO> GetUsuario(Expression<Func<Models.Usuario, bool>> filter);
    }
}