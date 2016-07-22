#region Document Header

/******************************************************************************
 * e-Commerce
 * Copyright (C)2010 - Cosan
 * http://www.cosan.com.br/
 * 
 * Desenvolvido por:
 * Thiago Rodolfo - 03/04/2011
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
#endregion

namespace Laboris.Cosan.UI.ViewAdmin
{
    public partial class UsuarioLista : BaseView<UsuarioController>
    {
        #region Page__Load
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region Events
        protected void gvwUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvwUsuarios.PageIndex = e.NewPageIndex;
            carregarGrid();
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            this.carregarGrid();
        }
        #endregion

        #region Private Methods
        private void carregarGrid()
        {
            
            //lblQuantidadeEncontrada.Text = string.Format("Período: <span style='color: red;'>{0}</span> a <span style='color: red;'>{1}</span>", periodoInicial.ToShortDateString(), periodoFinal.ToShortDateString());

            System.Text.StringBuilder where = new System.Text.StringBuilder();

            if (!string.IsNullOrEmpty(this.txtNome.Text))
            {
                where.Append(" nome like '%" + this.txtNome.Text + "%'");
            }

            if (!string.IsNullOrEmpty(this.txtEmail.Text))
            {
                if (where.Length > 1)
                {
                    where.Append(" AND email like '%" + this.txtEmail.Text + "%'");
                }
                else
                {
                    where.Append(" email like '%" + this.txtEmail.Text + "%'");
                }
            }

            if (!string.IsNullOrEmpty(this.txtLogin.Text))
            {
                if (where.Length > 1)
                {
                    where.Append(" AND login like '%" + this.txtLogin.Text + "%'");
                }
                else
                {
                    where.Append(" login like '%" + this.txtLogin.Text + "%'");
                }
            }

            if (this.chkAtivo.Checked)
            {
                if (where.Length > 1)
                {
                    where.Append(" AND isAtivo = 1");
                }
                else
                {
                    where.Append(" isAtivo = 1");
                }
            }

            Controller.Listar(where.ToString());

            if (Controller.View.Usuarios != null && Controller.View.Usuarios.Count > 0)
            {

                lblPeriodo.Text = string.Format("Total de registros encontrados: <span style='color: red;'>{0}</span>", Controller.View.Usuarios.Count);

                gvwUsuarios.DataSource = Controller.View.Usuarios;
                gvwUsuarios.DataBind();
            }
            else
            { 
                gvwUsuarios.Visible = false;
                lblPeriodo.Text = "Não foi encontrado nenhum registro";
            }
        }
        #endregion

       
    }
}