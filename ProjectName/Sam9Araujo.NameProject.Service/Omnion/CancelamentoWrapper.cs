using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace Sam9araujo.NameProject.Service.Omnion
{
    public class OmnionCancelamentoWrapper
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
        /// Grava e recupera o Parceiro
        /// </summary>
        public int Parceiro { get; set; }

        #endregion

        #region Constructors
        /// <summary>
        /// Construtor padrão
        /// ; Inicializa o objeto HttpWebRequest com o URL do webservice de 'Login' do Omnion
        /// ; Inicializa o método de request como 'POST'
        /// ; Inicializa o tipo de conteúdo como 'application/x-www-form-urlencoded'
        /// </summary>
        public OmnionCancelamentoWrapper()
        {
            this._httpWebRequest = WebRequest.Create(AppSettingsObject.Instance[AppSettingsObjectOption.OmnionCancelamentoURL]) as HttpWebRequest;
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
            string queryString = "id=" + this.OrderId + "&parceiro=" + this.Parceiro;

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

    public class OmnionCancelamentoEngine
    {
        #region Singleton
        private static readonly OmnionCancelamentoEngine _instance = new OmnionCancelamentoEngine();

        /// <summary>
        /// Instância do objeto singleton
        /// </summary>
        public static OmnionCancelamentoEngine Instance
        {
            get { return _instance; }
        }

        /// <summary>
        /// Construtor privado do Singleton
        /// </summary>
        private OmnionCancelamentoEngine() { }
        #endregion

        #region Public Methods
        public Omnion.Cancelamento Get(long orderId, int parceiro)
        {
            OmnionCancelamentoWrapper OmnionPedidoWS = new OmnionCancelamentoWrapper { OrderId = orderId, Parceiro = parceiro };
            return XmlToObject<Omnion.Cancelamento>.Convert(OmnionPedidoWS.GetResponse());
        }
        #endregion
    }

}
