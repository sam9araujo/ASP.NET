using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sam9araujo.NameProject.Domain.DTO;
using Sam9araujo.NameProject.Domain;
using Sam9araujo.NameProject.Repository;

namespace Sam9araujo.NameProject.UI.Controller
{
    public sealed class LojaController : BaseController<LojaDTO>
    {
        public LojaController()
        {
            //Utilizando o construtor, existe a possibilidade de pré-carregar propriedades do DTO,
            //como no exemplo abaixo:
            //
            //View.Categorias = CategoriaRepository.Instance.Listar();
        }

        public void CarregarListaAmbientes()
        {
            View.Ambientes = AmbienteRepository.Instance.ListarPorOrdem();
        }
        public void CarregarAmbiente(int idambiente)
        {
            View.AmbienteAtual = AmbienteRepository.Instance.Obter("idambiente=" + idambiente);
        }
        public void CarregarParceiro(int idParceiro)
        {
            View.Parceiro = ParceiroRepository.Instance.Obter("idParceiro = " + idParceiro);
        }

        public void CarregarListaProdutos(int idParceiro)
        {
            //View.Produtos = ProdutoRepository.Instance.Listar("idParceiro = " + idParceiro);
        }

    }
}
