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
    public partial class _Default : BaseView<TesteController>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int idAmbiente = 0;

            if (IsPostBack)
            {
                idAmbiente = int.Parse(ddlAmbientes.SelectedValue);
                CarregarComboCategorias(idAmbiente);
            }
            else
            {
                CarregarComboAmbientes();
                idAmbiente = int.Parse(ddlAmbientes.SelectedValue);
                CarregarComboCategorias(idAmbiente);
            }
        }

        private void CarregarComboCategorias(int idAmbiente)
        {
            Controller.CarregarCategoriasPorAmbiente(idAmbiente);

            ddlCategorias.DataTextField = "Descricao";
            ddlCategorias.DataValueField = "IdCategoria";

            ddlCategorias.DataSource = Controller.View.Categorias;

            ddlCategorias.DataBind();
        }

        private void CarregarComboAmbientes()
        {
            Controller.CarregarListaAmbientes();

            ddlAmbientes.DataTextField = "Descricao";
            ddlAmbientes.DataValueField = "IdAmbiente";

            ddlAmbientes.DataSource = Controller.View.Ambientes;

            ddlAmbientes.DataBind();
        }
    }
}
