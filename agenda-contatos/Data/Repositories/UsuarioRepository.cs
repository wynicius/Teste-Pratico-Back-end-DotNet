using System.Linq.Expressions;
using agenda_contatos.Models;
using Microsoft.EntityFrameworkCore;

namespace agenda_contatos.DataAccess.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<Usuario> dbSet;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
            this.dbSet = _context.Set<Usuario>();    
        }

        public async Task AdicionarUsuario(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirUsuario(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Usuario>> ListarTodosUsuarios()
        {
            var usuarios = await _context.Usuarios.ToListAsync() 
                ?? throw new NullReferenceException("A lista de usuarios está vazia.");
            return usuarios;
        }

        public async Task<Usuario> ListarUsuarioPorEmail(Expression<Func<Usuario, bool>> filter)
        {
            IQueryable<Usuario> query = dbSet;
            query = query.Where(filter);
            var usuario = await query.FirstOrDefaultAsync()
                ?? throw new NullReferenceException("O usuário não foi encontrado.");
            return usuario;
        }

        // public async Task AtualizarUsuario(Usuario usuario)
        // {
        //     _context.Usuarios.Update(usuario);
        //     await _context.SaveChangesAsync();
        // }

    }
}
