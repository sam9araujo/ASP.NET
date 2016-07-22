using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sam9araujo.NameProject.Domain.DTO;
using Sam9araujo.NameProject.Repository;

namespace Sam9araujo.NameProject.UI.Controller
{
    public sealed class OfertasController : BaseController<OfertasDTO>
    {
        public OfertasController()
        {
            //Utilizando o construtor, existe a possibilidade de pré-carregar propriedades do DTO,
            //como no exemplo abaixo:
            //
            //View.Categorias = CategoriaRepository.Instance.Listar();
        }

        public void CarregarProdutosOfertas(string ordem, int start, int size, ref int total)
        {
            View.Produtos = ProdutoRepository.Instance.ListarOfertas(ordem, start, size, ref total);
        }
    }
}
