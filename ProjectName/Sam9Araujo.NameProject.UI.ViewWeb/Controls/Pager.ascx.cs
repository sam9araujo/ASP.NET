using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.Web.UI.HtmlControls;

namespace Laboris.Cosan.UI.ViewWeb.Controls
{
    public partial class Pager : System.Web.UI.UserControl
    {
        int _take = 6;
        int _pagina = 1;
        int _totalRegistros;

        public int Take // Registros por página
        {
            get
            {
                return _take;
            }
            set
            {
                _take = value;
            }
        }

        public int Pagina
        {
            get
            {
                int.TryParse(Request.QueryString["pagina"], out _pagina);
                if (_pagina < 1) _pagina = 1;
                return _pagina;
            }
            set
            {
                _pagina = value;
            }
        }
        public int IndicePagina
        {
            get
            {
                int pagina = this.Pagina;

                if (pagina <= 1)
                    return 1;
                else
                    return ((pagina - 1) * _take) + 1;
            }
        }
        public int TotalRegistros
        {
            get
            {
                return _totalRegistros;
            }
            set
            {
                _totalRegistros = value;
                if (value < _take) this.Visible = false;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.AppRelativeTemplateSourceDirectory = "";

            NameValueCollection QS = HttpUtility.ParseQueryString(Request.QueryString.ToString());
            QS.Remove("pagina");

            if (Pagina == 1) LinkAnterior.Visible = false;
            LinkAnterior.HRef = Request.Url.AbsolutePath + "?pagina=" + (_pagina - 1) + "&" + QS;

            if (Take * Pagina >= TotalRegistros) LinkProxima.Visible = false;
            LinkProxima.HRef = Request.Url.AbsolutePath + "?pagina=" + (_pagina + 1) + "&" + QS;

            // Cria numeros de paginas
            int inicioContagem = _pagina - 5 > 0 ? _pagina - 5 : 1;
            int fimContagem = inicioContagem + 10 <= TotalPaginas ? inicioContagem + 6 : TotalPaginas;

            for (int i = inicioContagem; i <= fimContagem; i++)
            {
                if (i != _pagina)
                {
                    HtmlAnchor linkPagina = new HtmlAnchor()
                    {
                        HRef = Request.Url.AbsolutePath + "?pagina=" + i + "&" + QS,
                        InnerHtml = " " + i.ToString() + " "
                    };
                    LinkPaginas.Controls.Add(linkPagina);
                }
                else
                {
                    HtmlAnchor linkPagina = new HtmlAnchor()
                    {
                        InnerHtml = " <b style='font-size:1.2em'>" + i.ToString() + "</b> "
                    };
                    LinkPaginas.Controls.Add(linkPagina);
                }
            }
        }
        public int Skip
        {
            get
            {
                return Take * (Pagina - 1);
            }
        }
        public int TotalPaginas
        {
            get
            {
                return (int)Math.Ceiling((decimal)TotalRegistros / (decimal)Take);
            }
        }
    }
}