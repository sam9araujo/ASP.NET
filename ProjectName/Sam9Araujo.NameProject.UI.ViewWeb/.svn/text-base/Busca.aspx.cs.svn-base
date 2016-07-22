using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Laboris.Cosan.UI.Controller;
using Laboris.Cosan.UI.ViewWeb;
using Laboris.Cosan.Domain;
using Laboris.Cosan.UI.ViewWeb.Common;

namespace Laboris.Cosan.UI.ViewWeb
{
    public partial class Busca : BaseView<BuscaController>
    {
        BuscaRequest busca;

        protected void Page_Load(object sender, EventArgs e)
        {
            PrateleiraProdutos1.Visible = false;

            if (!IsPostBack)
            {
                busca = new BuscaRequest(Request);

                if (busca.AlgumParametroInformado)
                {
                    this.ListarProdutos(busca.Texto, busca.PontosInicial, busca.PontosFinal, busca.ValorInicial,  busca.ValorFinal, busca.BuscarPorOfertas);
                    this.PreencherControles();
                }
                else
                {
                    LiteralMensagem.Text = "<p></p><p><center><strong> FAÇA SUA BUSCA DO SEU JEITO, E ENCONTRE A SUA OPORTUNIDADE.</strong></center></p>";
                    PanelNaveguePorTemas.CssClass = "naveguePorTemasInicialSemBusca";
                }
            }

            if (!CheckBoxponto.Checked)
            {
                TextBoxPontoIn.Text = "";
                TextBoxPontoFin.Text = "";
            }
            if (!CheckBoxpreco.Checked)
            {
                TextBoxprecoInicial.Text = "";
                TextBoxPrecoFinal.Text = "";
            }
        }

        private void ListarProdutos(string busca, int pontoIn, int pontoFi, decimal valorIn, decimal valorFi, bool ofertas)
        {
            int total = 0;

            Controller.CarregarListaProdutos(busca, pontoIn, pontoFi, valorIn, valorFi, ofertas, 1, 12, ref total);

            if (Controller.View.Produtos.Count() == 0)
            {
                LiteralMensagem.Text = "<p></p><p><center><strong>Nenhum resultado encontrado.</strong></center></p>";
                PanelNaveguePorTemas.CssClass = "naveguePorTemasInicialSemBusca";
                PrateleiraProdutos1.Visible = false;
                //Pager1.Visible = false;
            }
            else
            {
                PrateleiraProdutos1.Visible = true;
                //Pager1.Visible = true;
            }
            //Pager1.TotalRegistros = total;
            PrateleiraProdutos1.ListarProdutos(Controller.View.Produtos);
        }

        protected void ImageBusca_Click(object sender, ImageClickEventArgs e)
        {
            string QS = "";

            if (!string.IsNullOrEmpty(TextBoxBusca.Text))
                QS += "busca=" + TextBoxBusca.Text;
            if (!string.IsNullOrEmpty(TextBoxPontoIn.Text))
                QS += "&pontoIn=" + TextBoxPontoIn.Text;
            if (!string.IsNullOrEmpty(TextBoxPontoFin.Text))
                QS += "&pontoFi=" + TextBoxPontoFin.Text;
            if (!string.IsNullOrEmpty(TextBoxprecoInicial.Text))
                QS += "&valorIn=" + TextBoxprecoInicial.Text;
            if (!string.IsNullOrEmpty(TextBoxPrecoFinal.Text))
                QS += "&valorFi=" + TextBoxPrecoFinal.Text;
            if (CheckBoxofertas.Checked)
                QS += "&oferta=" + CheckBoxofertas.Checked;

            Response.Redirect("Busca.aspx?" + QS.Replace(" ", "+"));
        }

        /*
        protected void RetornarDadosControle()
        {
            //DivPontos.Visible = CheckBoxponto.Checked;
            DivPreco.Visible = CheckBoxpreco.Checked;
            bool divVisivel = CheckBoxponto.Checked;
            DivPontos.Visible = divVisivel;

            PreencherControles();
            if (!CheckBoxponto.Checked)
            {
                TextBoxPontoIn.Text = "";
                TextBoxPontoFin.Text = "";
            }
            else if (!CheckBoxpreco.Checked)
            {
                TextBoxprecoInicial.Text = "";
                TextBoxPrecoFinal.Text = "";
            }
            if (CheckBoxponto.Checked)
                CheckBoxponto.Checked = true;

        }
        */

        protected void PreencherControles()
        {
            TextBoxBusca.Text = busca.Texto;
            DivPontos.Visible = busca.BuscarPorPontos;
            CheckBoxponto.Checked = busca.BuscarPorPontos;
            TextBoxPontoIn.Text = busca.PontosInicial.ToString();
            TextBoxPontoFin.Text = busca.PontosFinal.ToString();
            DivPreco.Visible = busca.BuscarPorValor;
            CheckBoxpreco.Checked = busca.BuscarPorValor;
            TextBoxprecoInicial.Text = busca.ValorInicial.ToString();
            TextBoxPrecoFinal.Text = busca.ValorFinal.ToString();
            CheckBoxofertas.Checked = busca.BuscarPorOfertas;
        }

        protected void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            DivPontos.Visible = CheckBoxponto.Checked;
            DivPreco.Visible = CheckBoxpreco.Checked;
        }

   }
}