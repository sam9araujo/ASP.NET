﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sam9araujo.NameProject.Domain.DTO;
using Sam9araujo.NameProject.Domain;
using Sam9araujo.NameProject.Repository;

namespace Sam9araujo.NameProject.UI.Controller
{
    public sealed class TesteController : BaseController<TesteDTO>
    {
        public TesteController()
        {
            //Utilizando o construtor, existe a possibilidade de pré-carregar propriedades do DTO,
            //como no exemplo abaixo:
            //
            //View.Categorias = CategoriaRepository.Instance.Listar();
        }

        public void CarregarListaAmbientes()
        {
            View.Ambientes = AmbienteRepository.Instance.Listar();
        }

        public void CarregarCategoriasPorAmbiente(int idAmbiente)
        {
            View.Categorias = CategoriaRepository.Instance.ListarPorAmbiente(idAmbiente);
        }

    }
}
