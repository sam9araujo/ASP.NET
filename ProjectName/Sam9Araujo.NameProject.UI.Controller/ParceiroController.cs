using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sam9araujo.NameProject.Domain.DTO;
using Sam9araujo.NameProject.Repository;

namespace Sam9araujo.NameProject.UI.Controller
{
  
    public sealed class ParceiroController : BaseController<ParceirosListaDTO>
    {
        public ParceiroController()
        {
            //Utilizando o construtor, existe a possibilidade de pré-carregar propriedades do DTO,
            //como no exemplo abaixo:
            //
            //View.Categorias = CategoriaRepository.Instance.Listar();
        }

        public void CarregarParceiro(int idParceiro)
        {
            View.Parceiro = ParceiroRepository.Instance.Obter("idParceiro = " + idParceiro);
        }
       
    }
}
