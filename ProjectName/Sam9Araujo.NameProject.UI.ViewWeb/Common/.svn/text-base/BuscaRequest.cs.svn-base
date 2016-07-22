using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboris.Cosan.UI.ViewWeb.Common
{
    public class BuscaRequest
    {
        private bool _buscarPorTexto = false;

        private string _texto;
        private bool _buscarPorPontos = false;
        private int _pontosInicial;
        private int _pontosFinal;
        private bool _buscarPorValor = false;
        private decimal _valorInicial;
        private decimal _valorFinal;
        private bool _buscarPorOfertas = false;

        public BuscaRequest(HttpRequest Request)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["busca"]))
            {
                _buscarPorTexto = true;
                _texto = Request.QueryString["busca"];
            }
            if (!string.IsNullOrEmpty(Request.QueryString["pontoIn"]) && !string.IsNullOrEmpty(Request.QueryString["pontoFi"]))
            {
                _buscarPorPontos = true;
                int.TryParse(Request.QueryString["pontoIn"], out _pontosInicial);
                //_pontosInicial = int.Parse(Request.QueryString["pontoIn"]);
                int.TryParse(Request.QueryString["pontoFi"], out _pontosFinal);
                //_pontosFinal = int.Parse(Request.QueryString["pontoFi"]);
            }
            if (!string.IsNullOrEmpty(Request.QueryString["valorIn"]) && !string.IsNullOrEmpty(Request.QueryString["valorFi"]))
            {
                _buscarPorValor = true;
                decimal.TryParse(Request.QueryString["valorIn"], out _valorInicial);
                decimal.TryParse(Request.QueryString["valorFi"], out _valorFinal);
                //_valorInicial = int.Parse(Request.QueryString["valorIn"]);
                //_valorFinal = int.Parse(Request.QueryString["valorFi"]);
            }
            if (!string.IsNullOrEmpty(Request.QueryString["oferta"]))
            {
                _buscarPorOfertas = true;
                _buscarPorOfertas = bool.Parse(Request.QueryString["oferta"]);
            }
        }

        public bool BuscarPorTexto
        {
            get { return _buscarPorTexto; }
        }

        public string Texto
        {
            get { return _texto; }
        }

        public bool BuscarPorValor
        {
            get { return _buscarPorValor; }
        }

        public decimal ValorInicial
        {
            get { return _valorInicial; }
        }

        public decimal ValorFinal
        {
            get { return _valorFinal; }
        }

        public bool BuscarPorPontos
        {
            get { return _buscarPorPontos; }
        }

        public int PontosInicial
        {
            get { return _pontosInicial; }
        }

        public int PontosFinal
        {
            get { return _pontosFinal; }
        }

        public bool BuscarPorOfertas
        {
            get { return _buscarPorOfertas; }
        }

        public bool AlgumParametroInformado
        {
            get { return this.BuscarPorOfertas || this.BuscarPorPontos || this.BuscarPorTexto || this.BuscarPorValor; }
        }
    }
}