using System.Linq.Expressions;
using agenda_contatos.DTOs;
using agenda_contatos.Models;
using Microsoft.AspNetCore.Mvc;

namespace agenda_contatos.DataAccess.Repositories
{
    public interface IUsuarioRepository
    {
        Task<UsuarioAuthDTO> GetUsuario(Expression<Func<Usuario, bool>> filter);
    }
}