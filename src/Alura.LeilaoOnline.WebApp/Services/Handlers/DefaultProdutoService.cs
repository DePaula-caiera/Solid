﻿using Alura.LeilaoOnline.WebApp.Dados;
using Alura.LeilaoOnline.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.WebApp.Services.Handlers
{
    public class DefaultProdutoService : IProdutoService
    {
       ILeilaoDao _leilaoDao;
       ICategoriaDao _categoriaDao;      

       public DefaultProdutoService(ILeilaoDao leilaoDao, ICategoriaDao categoriaDao)
        {
            _leilaoDao = leilaoDao;
            _categoriaDao = categoriaDao;
        }

        public Categoria ConsultaCategoriaPorIdComLeiloesEmPregao(int id)
        {
            return _categoriaDao.BuscarPorId(id);
        }

        public IEnumerable<CategoriaComInfoLeilao>
         ConsultaCategoriaComTotalDeLeiloesEmPregao()
        {
            return _categoriaDao
                .BuscarTodos()
                .Select(c => new CategoriaComInfoLeilao
                 {
                    Id = c.Id,
                    Descricao = c.Descricao,
                    Imagem = c.Imagem,
                    EmRascunho = c.Leiloes.Where(l => l.Situacao == SituacaoLeilao.Rascunho).Count(),
                    EmPregao = c.Leiloes.Where(l => l.Situacao == SituacaoLeilao.Pregao).Count(),
                    Finalizados = c.Leiloes.Where(l => l.Situacao == SituacaoLeilao.Finalizado).Count(),
                 });
        }
 

        public IEnumerable<Leilao> PesquisaLeiloesEmPregaoPorTermo(string termo)
        {
            var termoNormalized = termo.ToUpper();
            var leiloes = _leilaoDao.BuscarTodos()
                .Where(c =>
                    c.Titulo.ToUpper().Contains(termoNormalized) ||
                    c.Descricao.ToUpper().Contains(termoNormalized) ||
                    c.Categoria.Descricao.ToUpper().Contains(termoNormalized));
            return leiloes;               
        }

        public Categoria ConsultaCategoriaComTotalDeLeiloesEmPregao(int id)
        {
            throw new NotImplementedException();
        }
    }
}
