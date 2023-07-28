using Alura.LeilaoOnline.WebApp.Dados;
using Alura.LeilaoOnline.WebApp.Dados.EfCore;
using Alura.LeilaoOnline.WebApp.Models;
using Alura.LeilaoOnline.WebApp.Services.Handlers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.WebApp
{
    public class CategoriaDaoComEfCore : ICategoriaDao
    {
        AppDbContext _context;

        public CategoriaDaoComEfCore(AppDbContext context)
        {
            _context = context;
        }

        public Categoria BuscarPorId(int id) 
        {
            return _context.Categorias
                .Include(c => c.Leiloes)
                .First(c => c.Id == id);
        }

        public IEnumerable<Categoria> BuscarTodos()
        {
            return _context.Categorias
                .Include(c => c.Leiloes);
        }            
    }
}