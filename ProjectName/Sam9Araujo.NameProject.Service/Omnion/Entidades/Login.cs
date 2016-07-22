using System.Xml.Serialization;

namespace Sam9araujo.NameProject.Service.Omnion
{
    /// <summary>
    /// Classe da entidade OmnionLogin
    /// </summary>
    [XmlRoot("EXTRATO")]
    public class Login
    {
        #region Automatic Properties
        /// <summary>
        /// Grava e recupera o código de erro
        /// </summary>
        [XmlElement("CODIGOERRO")]
        public int CodigoErro { get; set; }

        /// <summary>
        /// Grava e recupera o código
        /// </summary>
        [XmlElement("CODIGO")]
        public int Codigo { get; set; }

        /// <summary>
        /// Grava e recupera o status
        /// </summary>
        [XmlElement("STATUS")]
        public string Status { get; set; }

        /// <summary>
        /// Grava e recupera o saldo
        /// </summary>
        [XmlElement("SALDO")]
        public double Saldo { get; set; }

        /// <summary>
        /// Grava e recupera o nome
        /// </summary>
        [XmlElement("NOME")]
        public string Nome { get; set; }

        /// <summary>
        /// Grava e recupera o CPF
        /// </summary>
        [XmlElement("CPF")]
        public string CPF { get; set; }

        /// <summary>
        /// Grava e recupera a conta
        /// </summary>
        [XmlElement("CONTA")]
        public string Conta { get; set; }

        /// <summary>
        /// Grava e recupera o cartão
        /// </summary>
        [XmlElement("CARTAO")]
        public string Cartao { get; set; }

        /// <summary>
        /// Grava e recupera o endereço
        /// </summary>
        [XmlElement("ENDERECO")]
        public string Endereco { get; set; }

        /// <summary>
        /// Grava e recupera o número
        /// </summary>
        [XmlElement("NUMERO")]
        public int Numero { get; set; }

        /// <summary>
        /// Grava e recupera o complemento
        /// </summary>
        [XmlElement("COMPLEMENTO")]
        public string Complemento { get; set; }

        /// <summary>
        /// Grava e recupera o bairro
        /// </summary>
        [XmlElement("BAIRRO")]
        public string Bairro { get; set; }

        /// <summary>
        /// Grava e recupera a cidade
        /// </summary>
        [XmlElement("CIDADE")]
        public string Cidade { get; set; }

        /// <summary>
        /// Grava e recupera o estado
        /// </summary>
        [XmlElement("ESTADO")]
        public string Estado { get; set; }

        /// <summary>
        /// Grava e recupera o CEP
        /// </summary>
        [XmlElement("CEP")]
        public string CEP { get; set; }

        /// <summary>
        /// Grava e recupera o email
        /// </summary>
        [XmlElement("EMAIL")]
        public string Email { get; set; }

        /// <summary>
        /// Grava e recupera o DDD_CELULAR
        /// </summary>
        [XmlElement("DDD_CELULAR")]
        public string DDD_Celular { get; set; }

        /// <summary>
        /// Grava e recupera o CELULAR
        /// </summary>
        [XmlElement("CELULAR")]
        public string Celular { get; set; }

        /// <summary>
        /// Grava e recupera o DDD_RESIDENCIAL
        /// </summary>
        [XmlElement("DDD_RESIDENCIAL")]
        public string DDD_Residencial { get; set; }

        /// <summary>
        /// Grava e recupera o RESIDENCIAL
        /// </summary>
        [XmlElement("RESIDENCIAL")]
        public string Residencial { get; set; }

        #endregion
    }
}
