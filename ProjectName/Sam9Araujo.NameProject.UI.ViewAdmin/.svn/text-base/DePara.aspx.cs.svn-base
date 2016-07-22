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
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Laboris.Cosan.UI.Controller;
using Laboris.Cosan.Domain;
#endregion

namespace Laboris.Cosan.UI.ViewAdmin
{
    public partial class DePara : BaseView<DeParaController>
    {
        #region Page__Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ListarParceiros();
            }
        }
        #endregion

        #region Private Methods
        private void ListarAmbientes(int idParceiro)
        {
            Controller.CarregarListaAmbientes(idParceiro);

            this.lbxAmbiente.DataSource = Controller.View.Ambientes;
            this.lbxAmbiente.DataValueField = "IdAmbiente";
            this.lbxAmbiente.DataTextField= "Descricao";
            this.lbxAmbiente.DataBind();
        }

        private void ListarCategorias(int idParceiro)
        {
            Controller.CarregarListaCategorias(idParceiro);
            this.lbxCategoria.DataSource = Controller.View.Categorias;
            this.lbxCategoria.DataValueField = "IdCategoria";
            this.lbxCategoria.DataTextField = "Descricao";
            this.lbxCategoria.DataBind();
        }

        private void ListarParceiros()
        {
            Controller.CarregarListaParceiros();
            this.ddlParceiro.DataSource = Controller.View.Parceiros;
            this.ddlParceiro.DataValueField = "IdParceiro";
            this.ddlParceiro.DataTextField = "Nome";
            this.ddlParceiro.DataBind();
            ddlParceiro.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Selecione --", "-1"));
        }

        #endregion

        #region Events
        protected void lkOk_Click(object sender, EventArgs e)
        {
            ListItemCollection itensParaRemover = new ListItemCollection();

            foreach (ListItem lst in this.lbxCategoria.Items)
            {
                if (lst.Selected)
                {
                    this.lbxResultado.Items.Add(new ListItem(lbxAmbiente.SelectedItem.Text + " --> " + lst.Text, lbxAmbiente.SelectedValue + ":" + lst.Value));
                    itensParaRemover.Add(lst);
                }
            }

            foreach (ListItem lst in itensParaRemover)
            {
                this.lbxCategoria.Items.Remove(lst);
            }
        }

        protected void lkRemove_Click(object sender, EventArgs e)
        {
            ListItemCollection itensAddCategoria = new ListItemCollection();
            ListItemCollection itensParaRemover = new ListItemCollection();

            foreach (ListItem lst in this.lbxResultado.Items)
            {
                if (lst.Selected)
                {
                    ListItem categoria = new ListItem();
                    categoria.Text = lst.Text.Split('>')[1];
                    categoria.Value = lst.Value.Split(':')[1];

                    itensAddCategoria.Add(categoria);
                    itensParaRemover.Add(lst);
                }
            }

            foreach (ListItem lst in itensParaRemover)
            {
                this.lbxResultado.Items.Remove(lst);
            }

            foreach (ListItem lst in itensAddCategoria)
            {
                this.lbxCategoria.Items.Add(lst);
            }
        }

        

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            Domain.Ambiente ambiente = new Domain.Ambiente();

            foreach (ListItem lst in this.lbxResultado.Items)
            {
                if (lst.Selected)
                {
                    Domain.Categoria categoria = new Domain.Categoria();
                    categoria.IdCategoria = int.Parse(lst.Value.Split(':')[1]);

                    Domain.Parceiro parceiro = new Domain.Parceiro();
                    parceiro.IdParceiro = int.Parse(this.ddlParceiro.SelectedValue);

                    ambiente.IdAmbiente = int.Parse(lst.Value.Split(':')[0]);

                    if (ambiente.Categorias == null)
                        ambiente.Categorias = new List<Categoria>();

                    ambiente.Categorias.Add(categoria);

                    if (ambiente.Parceiros == null)
                        ambiente.Parceiros = new List<Parceiro>();
                    
                    ambiente.Parceiros.Add(parceiro);
                }
            }
        }

        protected void ddlParceiro_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idParceiro = int.Parse(ddlParceiro.SelectedValue);
            this.ListarCategorias(idParceiro);
            this.ListarAmbientes(idParceiro);
        }
        
        #endregion
    }
}