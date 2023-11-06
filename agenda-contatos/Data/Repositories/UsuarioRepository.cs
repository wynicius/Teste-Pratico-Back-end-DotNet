using System.Linq.Expressions;
using agenda_contatos.DTOs;
using agenda_contatos.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace agenda_contatos.DataAccess.Repositories;
public class UsuarioRepository : IUsuarioRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    internal DbSet<Usuario> dbSet;

    public UsuarioRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        this.dbSet = _context.Set<Usuario>();
        _mapper = mapper;
    }

    public async Task<UsuarioAuthDTO> GetUsuario(Expression<Func<Usuario, bool>> filter)
    {
        var usuario = await dbSet.Where(filter).FirstOrDefaultAsync() 
            ?? throw new NullReferenceException("O usuário não foi encontrado.");
            
        return _mapper.Map<UsuarioAuthDTO>(usuario);
    }
}