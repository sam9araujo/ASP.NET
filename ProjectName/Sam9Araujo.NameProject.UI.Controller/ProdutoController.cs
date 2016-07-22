#region Document Header

/******************************************************************************
 * e-Commerce
 * Copyright (C)2010 - NameProject
 * http://www.NameProject.com.br/
 * 
 * Desenvolvido por:
 * Thiago Rodolfo - 18/03/2011
 * Sam9araujo Consultoria Ltda.
 * http://www.Sam9araujo.com.br
 *
 ******************************************************************************/

#endregion

#region Imports
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sam9araujo.NameProject.Domain.DTO;
using Sam9araujo.NameProject.Domain;
using Sam9araujo.NameProject.Repository;
#endregion

namespace Sam9araujo.NameProject.UI.Controller
{
    public sealed class ProdutoController : BaseController<ProdutoDTO>
    {
        public ProdutoController()
        {
            //Utilizando o construtor, existe a possibilidade de pré-carregar propriedades do DTO,
            //como no exemplo abaixo:
            //
            //View.Categorias = CategoriaRepository.Instance.Listar();
        }

        public void Incluir(IList<Produto> produtos)
        {

            DataAccessLayer.DBManager conn = new DataAccessLayer.DBManager();
            try
            {
                //TODO: Precisa verificar a instancia da connection
                conn.BeginTransaction();
                
                for (int i = 0; i < View.Produtos.Count; i++)
                {
                    ProdutoRepository.Instance.Insert(produtos[i]);
                }

                conn.CommitTransaction();
            }
            catch (Exception ex)
            {
                conn.RollbackTransaction();
            }

        }

        public void CarregarListaCategorias()
        {
            View.Categorias = CategoriaRepository.Instance.Listar();
        }

        public void CarregarListaParceiros()
        {
            View.Parceiros = ParceiroRepository.Instance.Listar();
        }
    }
}
