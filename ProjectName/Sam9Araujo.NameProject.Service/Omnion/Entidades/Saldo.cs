#region Document Header

/******************************************************************************
 * e-Commerce
 * Copyright (C)2010 - Cosan
 * http://www.cosan.com.br/
 * 
 * Desenvolvido por:
 * Thiago Rodolfo - 25/08/2010
 * Laboris Consultoria Ltda.
 * http://www.laboris.com.br
 *
 ******************************************************************************/

#endregion

#region Imports
using System.Xml.Serialization;
#endregion

namespace Laboris.Cosan.Service.Omnion
{
    /// <summary>
    /// Classe da entidade OmnionLogin
    /// </summary>
    [XmlRoot("EXTRATO")]
    public class Saldo
    {
        #region Automatic Properties
        /// <summary>
        /// Grava e recupera o código de erro
        /// </summary>
        [XmlElement("CODIGOERRO")]
        public int CodigoErro { get; set; }

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

        #endregion
    }
}
