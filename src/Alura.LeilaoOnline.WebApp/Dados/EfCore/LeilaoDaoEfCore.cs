using Alura.LeilaoOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


namespace Alura.LeilaoOnline.WebApp.Dados.EfCore
{
    public class LeilaoDaoEfCore : ILeilaoDao
    {
        AppDbContext _context;

        public LeilaoDaoEfCore(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Leilao> BuscarTodos()
        {
            return _context.Leiloes.Include(l => l.Categoria);
        }
        public Leilao BuscarPorId(int id)
        {
            return _context.Leiloes.Find(id);
        }

        public IEnumerable<Categoria> BuscarCategorias()
        {
            return _context.Categorias.ToList();
        }      

        public void Incluir(Leilao leilao)
        {
            _context.Leiloes.Add(leilao);
            _context.SaveChanges();
        }

        public void Alterar(Leilao leilao)
        {
            _context.Leiloes.Update(leilao);
            _context.SaveChanges();
        }

        public void Excluir(Leilao leilao)
        {
            _context.Leiloes.Remove(leilao);
            _context.SaveChanges();
        }
    }
}
