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
    public partial class NaveguePorTemas : BaseUserControlView<ucNaveguePorTemasController>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AppRelativeTemplateSourceDirectory = "";
            this.ListarParceiros();
        }

        private void ListarParceiros()
        {
            Controller.CarregarListaAmbientes();

            IList<Ambiente> ambientes = Controller.View.Ambientes;
            
            string htmlAmbientes = "";

            for (int i = 0; i < ambientes.Count; i++)
            {
                /*
                Literal li = new Literal();
                LinkButton link = new LinkButton();
                Image imagem = new Image();

                imagem.ImageUrl = ambientes[i].Imagem;
                imagem.ToolTip = ambientes[i].Imagem;
                imagem.AlternateText = ambientes[i].Imagem;

                link.Controls.Add(imagem);
                link.ToolTip = ambientes[i].Descricao;
                link.PostBackUrl = "#";

                li.Controls.Add(link);

                TemasContainer.Controls.Add(li);
                */
                htmlAmbientes += 
                    "<li>" +
                    "   <a href=\"Categoria.aspx?id=" + ambientes[i].IdAmbiente + "\">" +
                    "       <img src=\"" + ambientes[i].ImagemPeq + "\" alt=\"" + ambientes[i].Descricao + "\" />" +
                    //"       <span>" + ambientes[i].Descricao + "</span>" +
					"   </a>" +
				    "</li>";
            }
            TemasContainer.InnerHtml = htmlAmbientes;
        }

    }
}
