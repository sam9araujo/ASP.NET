#region Document Header

/******************************************************************************
 * e-Commerce
 * Copyright (C)2010 - NameProject
 * http://www.NameProject.com.br/
 * 
 * Desenvolvido por:
 * Thiago Rodolfo - 25/08/2010
 * Sam9araujo Consultoria Ltda.
 * http://www.Sam9araujo.com.br
 *
 ******************************************************************************/

#endregion

#region Imports
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
#endregion

namespace Sam9araujo.NameProject.Service.Omnion
{
    public class PedidoWrapper
    {
        #region Fields
        private HttpWebRequest _httpWebRequest;
        private HttpWebResponse _httpWebResponse;
        #endregion

        #region Automatic Properties

        /// <summary>
        /// Grava e recupera o Pedido
        /// </summary>
        public long OrderId { get; set; }

        /// <summary>
        /// Grava e recupera os Pontos
        /// </summary>
        public string Pontos { get; set; }

        /// <summary>
        /// Grava e recupera o Valor
        /// </summary>
        public string Valor { get; set; }

        /// <summary>
        /// Grava e recupera o CPF
        /// </summary>
        public string CPF { get; set; }


        /// <summary>
        /// Grava e recupera o Parceiro
        /// </summary>
        public int Parceiro { get; set; }

        /// <summary>
        /// Grava e recupera o XML de Troca
        /// </summary>
        public string XML { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Construtor padrão
        /// ; Inicializa o objeto HttpWebRequest com o URL do webservice de 'Login' do Omnion
        /// ; Inicializa o método de request como 'POST'
        /// ; Inicializa o tipo de conteúdo como 'application/x-www-form-urlencoded'
        /// </summary>
        public PedidoWrapper()
        {
            this._httpWebRequest = WebRequest.Create(AppSettingsObject.Instance[AppSettingsObjectOption.OmnionPedidoURL]) as HttpWebRequest;
            this._httpWebRequest.Method = "POST";
            this._httpWebRequest.ContentType = "application/x-www-form-urlencoded";
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Recupera o XML do webservice
        /// </summary>
        /// <returns>XmlReader com o stream do HttpWebResponse</returns>
        public XmlReader GetResponse()
        {
            string queryString = "id=" + this.OrderId + "&pontos=" + this.Pontos + "&valor=" + this.Valor + "&cpf=" + this.CPF + "&parceiro=" + this.Parceiro;

            if (XML != null && XML != string.Empty)
            {
                queryString += "&XML=" + XML;
            }

            ASCIIEncoding asciiEncoding = new ASCIIEncoding();
            byte[] data = asciiEncoding.GetBytes(queryString);
            this._httpWebRequest.ContentLength = data.Length;
            Stream stream = this._httpWebRequest.GetRequestStream();
            stream.Write(data, 0, data.Length);
            stream.Close();
            this._httpWebResponse = this._httpWebRequest.GetResponse() as HttpWebResponse;
            return XmlTextReader.Create(this._httpWebResponse.GetResponseStream());
        }
        #endregion
    }

    public class OmnionPedidoEngine
    {
        #region Singleton
        private static readonly OmnionPedidoEngine _instance = new OmnionPedidoEngine();

        /// <summary>
        /// Instância do objeto singleton
        /// </summary>
        public static OmnionPedidoEngine Instance
        {
            get { return _instance; }
        }

        /// <summary>
        /// Construtor privado do Singleton
        /// </summary>
        private OmnionPedidoEngine() { }
        #endregion

        #region Public Methods
        public Omnion.Pedido Get(long orderId, string pontos, string valor, string cpf, int parceiro)
        {
            PedidoWrapper OmnionPedidoWS = new PedidoWrapper { OrderId = orderId, Pontos = pontos, Valor = valor, CPF = cpf, Parceiro = parceiro };
            return XmlToObject<Omnion.Pedido>.Convert(OmnionPedidoWS.GetResponse());
        }

        public Omnion.Pedido Get(long orderId, string pontos, string valor, string cpf, int parceiro, string xml)
        {
            PedidoWrapper OmnionPedidoWS = new PedidoWrapper { OrderId = orderId, Pontos = pontos, Valor = valor, CPF = cpf, Parceiro = parceiro, XML = xml };
            return XmlToObject<Omnion.Pedido>.Convert(OmnionPedidoWS.GetResponse());
        }

        #endregion
    }

}
