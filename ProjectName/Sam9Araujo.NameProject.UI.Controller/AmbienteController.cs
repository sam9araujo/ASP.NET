using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sam9araujo.NameProject.Domain.DTO;
using Sam9araujo.NameProject.Domain;
using Sam9araujo.NameProject.Repository;

namespace Sam9araujo.NameProject.UI.Controller
{
    public sealed class AmbienteController : BaseController<AmbienteDTO>
    {
        public AmbienteController()
        {
            //Utilizando o construtor, existe a possibilidade de pré-carregar propriedades do DTO,
            //como no exemplo abaixo:
            //
            //View.Categorias = CategoriaRepository.Instance.Listar();
        }

        public void CarregarAmbiente(int idAmbiente)
        {
            View.Ambiente = AmbienteRepository.Instance.Obter("idAmbiente = " + idAmbiente.ToString());
        }

        public void CarregarListaProdutosOfertas(int idAmbiente)
        {
            View.Produtos = ProdutoRepository.Instance.ListarOfertasPorAmbiente(idAmbiente, 1, 12);
        }
    }
}
