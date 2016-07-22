using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sam9araujo.NameProject.Domain.DTO;
using Sam9araujo.NameProject.Domain;
using Sam9araujo.NameProject.Repository;

namespace Sam9araujo.NameProject.UI.Controller
{
    public sealed class ucNaveguePorTemasController : BaseController<ucNaveguePorTemasDTO>
    {
        public ucNaveguePorTemasController()
        {

        }

        public void CarregarListaAmbientes()
        {
            View.Ambientes = AmbienteRepository.Instance.Listar();
        }
    }
}
