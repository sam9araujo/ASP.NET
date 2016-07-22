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
    [XmlRoot("PEDIDO")]
    public class Pedido
    {
        #region Automatic Properties
        /// <summary>
        /// Grava e recupera o status
        /// </summary>
        [XmlElement("STATUS")]
        public string Status { get; set; }

        /// <summary>
        /// Grava e recupera o codigo de erro
        /// </summary>
        [XmlElement("CODIGOERRO")]
        public double CodigoErro { get; set; }
        #endregion
    }
}
