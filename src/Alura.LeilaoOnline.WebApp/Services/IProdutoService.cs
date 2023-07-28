using Alura.LeilaoOnline.WebApp.Models;
using System.Collections;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Services
{
    public interface IProdutoService
    {
        IEnumerable<Leilao> PesquisaLeiloesEmPregaoPorTermo(string termo);
        IEnumerable<CategoriaComInfoLeilao>
            ConsultaCategoriaComTotalDeLeiloesEmPregao();
        Categoria ConsultaCategoriaComTotalDeLeiloesEmPregao(int id);
    }
}
