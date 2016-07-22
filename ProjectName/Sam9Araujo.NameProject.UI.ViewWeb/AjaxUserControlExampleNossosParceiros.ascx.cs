using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Laboris.Cosan.UI.Controller;
using Laboris.Cosan.Domain;

namespace Laboris.Cosan.UI.ViewWeb
{
    public partial class AjaxTestNossosParceiros : BaseUserControlView<ucNossosParceirosController>
    {
        private int pageCurrent = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            //this.ListarParceiros();
            this.Controller.CarregarListaParceiros();

            this.ListarParceiro(pageCurrent);
        }

         private void ListarParceiro(int page)
        {
            Parceiro parceiro = Controller.View.Parceiros[page];

            LinkButton linkParceiro = new LinkButton();
            Image imagem = new Image();

            imagem.ImageUrl = parceiro.Imagem;
            imagem.ToolTip = parceiro.Nome;
            imagem.AlternateText = parceiro.Nome;

            linkParceiro.Controls.Add(imagem);
            linkParceiro.ToolTip = parceiro.Nome;
            linkParceiro.PostBackUrl = "#";

            panelListaParceiros.Controls.Clear();
            panelListaParceiros.Controls.Add(linkParceiro);
        }

        protected void btPrevious_Click(object sender, EventArgs e)
        {
            if (pageCurrent > 1)
                pageCurrent--;

            this.ListarParceiro(pageCurrent);
        }

        protected void btNext_Click(object sender, EventArgs e)
        {
            if (pageCurrent < this.Controller.View.Parceiros.Count)
                pageCurrent++;

            this.ListarParceiro(pageCurrent);
        }
    }
}