using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Laboris.Cosan.UI.Controller;
using Laboris.Cosan.Domain;

namespace Laboris.Cosan.UI.ViewWeb.Controls
{
    public partial class NossosParceiros : BaseUserControlView<ucNossosParceirosController>
    {
        public string slideShow;
        public string classe;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AppRelativeTemplateSourceDirectory = "";
            this.ListarParceiros();
            this.SlideShow();
        }

        private void ListarParceiros()
        {
            Controller.CarregarListaParceiros();

            IList<Parceiro> parceiros = Controller.View.Parceiros;

            for (int i = 0; i < parceiros.Count; i++)
            {
                LinkButton linkParceiro = new LinkButton();
                Image imagem = new Image();

                imagem.ImageUrl = parceiros[i].Imagem;
                imagem.ToolTip = parceiros[i].Nome;
                imagem.AlternateText = parceiros[i].Nome;

                linkParceiro.Controls.Add(imagem);
                linkParceiro.ToolTip = parceiros[i].Nome;
                linkParceiro.PostBackUrl = "#";

                //anelListaParceiros.Controls.Add(linkParceiro);

            }
        }

        public void SlideShow()
        {
            IList<Parceiro> parceiros = Controller.View.Parceiros;

            classe += "class=\"active\"";
            for (int i = 0; i < parceiros.Count; i++)
            {
                slideShow += "<a " + classe + " href='Redirect.aspx?idParceiro=" + parceiros[i].IdParceiro + "'><img src='" + parceiros[i].Imagem + "'/></a>";
                //slideShow += "<img " + classe + " src='" + parceiros[i].Imagem + "'/>";
                classe = "";
            }
        }

    }
}
