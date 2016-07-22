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
using System.Xml.Serialization;
#endregion

namespace Sam9araujo.NameProject.Service.Omnion
{
    /// <summary>
    /// Classe da entidade OmnionTroca
    /// </summary>
    [XmlRoot("TROCA")]
    public class Troca
    {
        #region Automatic Properties
        /// <summary>
        /// Grava e recupera o status
        /// </summary>
        [XmlElement("STATUS")]
        public string Status { get; set; }

        /// <summary>
        /// Grava e recupera o saldo
        /// </summary>
        [XmlElement("MENSAGEM")]
        public double Saldo { get; set; }
        #endregion
    }
}
