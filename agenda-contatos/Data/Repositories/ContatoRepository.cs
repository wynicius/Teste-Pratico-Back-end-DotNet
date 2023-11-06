using System.Linq.Expressions;
using agenda_contatos.Models;
using Microsoft.EntityFrameworkCore;

namespace agenda_contatos.DataAccess.Repositories
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<Contato> dbSet;

        public ContatoRepository(ApplicationDbContext context)
        {
            _context = context;
            this.dbSet = _context.Set<Contato>();    
        }

        public async Task<List<Contato>> ListarTodosContatos()
        {
            var contatos = await _context.Contatos.ToListAsync() 
                ?? throw new NullReferenceException("A lista de contatos está vazia.");
            return contatos;
        }

        public async Task<Contato> ListarContatoPorId(Expression<Func<Contato, bool>> filter)
        {
            IQueryable<Contato> query = dbSet;
            query = query.Where(filter);
            var contato = await query.FirstOrDefaultAsync()
                ?? throw new NullReferenceException("O contato não foi encontrado.");
            return contato;
        }

        public async Task AdicionarContato(Contato contato)
        {
            await _context.Contatos.AddAsync(contato);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarContato(Contato contato)
        {
            _context.Contatos.Update(contato);
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirContato(Contato contato)
        {
            _context.Contatos.Remove(contato);
            await _context.SaveChangesAsync();
        }
    }
}
