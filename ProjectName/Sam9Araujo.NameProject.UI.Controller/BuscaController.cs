using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sam9araujo.NameProject.Domain.DTO;
using Sam9araujo.NameProject.Repository;

namespace Sam9araujo.NameProject.UI.Controller
{
    public sealed class BuscaController : BaseController<BuscaDTO>
    {
        public BuscaController()
        {
            //Utilizando o construtor, existe a possibilidade de pré-carregar propriedades do DTO,
            //como no exemplo abaixo:
            //
            //View.Categorias = CategoriaRepository.Instance.Listar();
        }

        public void CarregarListaProdutos(string busca, int pontoIn,int pontoFi, decimal valorIn, decimal valorFi,bool ofertas,int start, int size, ref int total)
        {
            View.Produtos = ProdutoRepository.Instance.Buscar(busca, pontoIn,pontoFi,valorIn,valorFi,ofertas, start, size, ref total);
        }
    }
}
