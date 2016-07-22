#region Document Header

/******************************************************************************
 * e-Commerce
 * Copyright (C)2010 - Cosan
 * http://www.cosan.com.br/
 * 
 * Desenvolvido por:
 * Thiago Rodolfo - 18/03/2011
 * Laboris Consultoria Ltda.
 * http://www.laboris.com.br
 *
 ******************************************************************************/

#endregion

#region Imports
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Laboris.Cosan.UI.Controller;
#endregion

namespace Laboris.Cosan.UI.ViewAdmin
{
    public partial class InsercaoEmMassa : BaseView<ProdutoController>
    {
        #region Page__Load
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region Events
        protected void btnOk_Click(object sender, EventArgs e)
        {
            int contador = 0;
            try
            {
                contador = int.Parse(this.txtQuantidadeProduto.Text);
            }
            catch
            {
                contador = 0;
            }

            criaDataTable(contador);

            this.btnSalvar.Visible = true;
        }

        protected void gvwProdutos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList cmbCategoria = (DropDownList)e.Row.Cells[3].FindControl("cmbCategoria");
                DropDownList cmbParceiro = (DropDownList)e.Row.Cells[4].FindControl("cmbParceiro");

                ListarCategorias(cmbCategoria);
                ListarParceiros(cmbParceiro);
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            Controller.Incluir(this.percorreGrid());
        }
        #endregion

        #region Private Methods
        private void ListarCategorias(DropDownList ddl)
        {
            Controller.CarregarListaCategorias();
            ddl.DataSource = Controller.View.Categorias;
            ddl.DataValueField = "IdCategoria";
            ddl.DataTextField = "Descricao";
            ddl.DataBind();
            ddl.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Selecione --", "-1"));
        }

        private void ListarParceiros(DropDownList ddl)
        {
            Controller.CarregarListaParceiros();
            ddl.DataSource = Controller.View.Parceiros;
            ddl.DataValueField = "IdParceiro";
            ddl.DataTextField = "Nome";
            ddl.DataBind();
            ddl.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Selecione --", "-1"));
        }

        #region DataTable
        private void criaDataTable(int linhas)
        {
            //Create the DataTable
            DataTable dt = new DataTable();

            //Create the columns
            DataColumn dcNome = new DataColumn("Nome", typeof(string));
            DataColumn dcTitulo = new DataColumn("Titulo", typeof(string));
            DataColumn dcDescricao = new DataColumn("Descricao", typeof(string));
            DataColumn dcCategoria = new DataColumn("Categoria", typeof(string));
            DataColumn dcParceiro = new DataColumn("Parceiro", typeof(string));
            DataColumn dcLink = new DataColumn("Link", typeof(string));
            DataColumn dcPrecoCheio = new DataColumn("PrecoCheio", typeof(float));
            DataColumn dcPreco = new DataColumn("Preco", typeof(float));
            DataColumn dcPontos = new DataColumn("Pontos", typeof(int));
            DataColumn dcFrete = new DataColumn("Frete", typeof(float));
            DataColumn dcImagem = new DataColumn("Imagem", typeof(string));
            DataColumn dcObservacao = new DataColumn("Observacao", typeof(string));

            

            //Add the columns to the DataTable's Columns collection
            dt.Columns.Add(dcNome);
            dt.Columns.Add(dcTitulo);
            dt.Columns.Add(dcDescricao);
            dt.Columns.Add(dcCategoria);
            dt.Columns.Add(dcParceiro);
            dt.Columns.Add(dcLink);
            dt.Columns.Add(dcPrecoCheio);
            dt.Columns.Add(dcPreco);
            dt.Columns.Add(dcPontos);
            dt.Columns.Add(dcFrete);
            dt.Columns.Add(dcImagem);
            dt.Columns.Add(dcObservacao);

            DataRow dr = default(DataRow);
            for (int i = 0; i < linhas; i++)
            {
                dr = dt.NewRow();
                
                dr["Nome"] = "";
                dr["Titulo"] = "";
                dr["Descricao"] = "";
                dr["Categoria"] = "";
                dr["Parceiro"] = "";
                dr["Link"] = "";
                dr["PrecoCheio"] = 0.0;
                dr["Preco"] = 0.0;
                dr["Pontos"] = 0;
                dr["Frete"] = 0.0;
                dr["Imagem"] = "";
                dr["Observacao"] = "";

                dt.Rows.Add(dr);
            }

            //Bind the DataTable to the DataGrid
            gvwProdutos.DataSource = dt;
            gvwProdutos.DataBind();
        }

        private IList<Domain.Produto> percorreGrid()
        {
            IList<Domain.Produto> produtos = new List<Domain.Produto>();

            foreach (GridViewRow gvw in gvwProdutos.Rows)
            {

                Domain.Produto produto = new Domain.Produto();

                produto.Nome = ((TextBox)gvw.FindControl("txtNome")).Text;
                produto.Titulo = ((TextBox)gvw.FindControl("txtTitulo")).Text;
                produto.Descricao = ((TextBox)gvw.FindControl("txtDescricao")).Text;
                produto.IdCategoria = int.Parse(((DropDownList)gvw.FindControl("cmbCategoria")).SelectedValue);
                produto.IdParceiro = int.Parse(((DropDownList)gvw.FindControl("cmbParceiro")).SelectedValue);
                produto.Link = ((TextBox)gvw.FindControl("txtLink")).Text;
                produto.PrecoCheio = float.Parse(((TextBox)gvw.FindControl("txtPrecoCheio")).Text);
                produto.Preco = float.Parse(((TextBox)gvw.FindControl("txtPreco")).Text);
                produto.Pontos = int.Parse(((TextBox)gvw.FindControl("txtPontos")).Text);
                produto.Frete = float.Parse(((TextBox)gvw.FindControl("txtFrete")).Text);
                produto.Imagem = new List<string>();
                produto.Imagem.Add(((TextBox)gvw.FindControl("txtImagem")).Text);
                produto.Observacao = ((TextBox)gvw.FindControl("txtObservacao")).Text;

                produtos.Add(produto);
            }

            return produtos;
        }
        #endregion

        #endregion
    }
}