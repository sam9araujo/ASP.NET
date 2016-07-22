using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sam9araujo.NameProject.Domain.DTO;
using Sam9araujo.NameProject.Domain;
using Sam9araujo.NameProject.Repository;

namespace Sam9araujo.NameProject.UI.Controller
{
    public sealed class PrateleiraProdutosController : BaseController<PrateleiraProdutosDTO>
    {
        public PrateleiraProdutosController()
        {

        }

        public void CarregarProdutosPorBusca(string busca, int pontoIn, int pontoFi, decimal valorIn, decimal valorFi, bool ofertas, int start, int size)
        {
            int total = 0;
            View.Produtos = ProdutoRepository.Instance.Buscar(busca, pontoIn, pontoFi, valorIn, valorFi, ofertas, start, size, ref total);
        }

        public void CarregarProdutosOfertas(string ordem, int start, int size)
        {
            int total = 0;
            View.Produtos = ProdutoRepository.Instance.ListarOfertas(ordem, start, size, ref total);
        }

        public void CarregarProdutosPorAmbiente(int idAmbiente, int start, int size)
        {
            View.Produtos = ProdutoRepository.Instance.ListarOfertasPorAmbiente(idAmbiente, start, size);
        }
    }
}
