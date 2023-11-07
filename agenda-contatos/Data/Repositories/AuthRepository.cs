using System.Linq.Expressions;
using agenda_contatos.DTOs;
using agenda_contatos.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace agenda_contatos.DataAccess.Repositories;
public class AuthRepository : IAuthRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    internal DbSet<Models.Usuario> dbSet;

    public AuthRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        this.dbSet = _context.Set<Models.Usuario>();
        _mapper = mapper;
    }

    public async Task<AuthDTO> GetUsuario(Expression<Func<Models.Usuario, bool>> filter)
    {
        var usuario = await dbSet.Where(filter).FirstOrDefaultAsync() 
            ?? throw new NullReferenceException("O usuário não foi encontrado.");

        return _mapper.Map<AuthDTO>(usuario);
    }
}