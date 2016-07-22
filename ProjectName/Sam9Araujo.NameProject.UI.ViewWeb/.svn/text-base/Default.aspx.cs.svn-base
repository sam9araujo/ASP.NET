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
    public partial class Default : BaseView<HomeController>
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            ListarAmbientes();

            if (IsPostBack)
            {

            }
            else
            {

            }
        }

        private void ListarAmbientes()
        {
            Controller.CarregarListaAmbientes();

            IList<Ambiente> ambientes = Controller.View.Ambientes;

            for (int i = 0; i < ambientes.Count; i++)
            {
                //LinkButton linkAmbiente = new LinkButton();
                HyperLink linkAmbiente = new HyperLink();

                linkAmbiente.Text = ambientes[i].Descricao;
                linkAmbiente.ToolTip = ambientes[i].Descricao;
                linkAmbiente.NavigateUrl = "Categoria.aspx?id=" + ambientes[i].IdAmbiente;
                //linkAmbiente.Attributes["href"] = "#";
                linkAmbiente.CssClass = ambientes[i].CssClassStyle;
                
                if (i <= 2 || i % 2 == 0)
                {
                    divAmbienteEsq.Controls.Add(linkAmbiente);
                }
                else
                {
                    divAmbienteDir.Controls.Add(linkAmbiente);
                }
            }
        }
    }
}