using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;
using System.Collections.Generic;

namespace Sam9araujo.NameProject.Service
{
    /// <summary>
    /// Classe para conversão de XML em um objeto
    /// </summary>
    /// <typeparam name="T">Tipo do objeto para conversão</typeparam>
    public static class XmlToObject<T>
    {
        /// <summary>
        /// Converte um XML em um objeto de tipo determinado
        /// </summary>
        /// <param name="xmlReader">Stream de leitura do XML</param>
        /// <returns>Instância do objeto de tipo determinado</returns>
        public static T Convert(XmlReader xmlReader)
        {
            object genericEntity = null;

            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                genericEntity = xmlSerializer.Deserialize(xmlReader);
            }
            catch{}

            return (T)genericEntity;
        }

        public static void ListEntityToXml(List<T> parameters, string rootElementName, string pathFile)
        {
            XmlAttributeOverrides overrides = new XmlAttributeOverrides();
            XmlAttributes attr = new XmlAttributes();
            attr.XmlRoot = new XmlRootAttribute(rootElementName);
            overrides.Add(typeof(List<T>), attr);

            XmlDocument xmlDoc = new XmlDocument();
            XPathNavigator nav = xmlDoc.CreateNavigator();
            using (XmlWriter writer = nav.AppendChild())
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<T>), overrides);
                ser.Serialize(writer, parameters);
            }

            File.WriteAllText(pathFile, xmlDoc.InnerXml);
        }

        public static List<T> XmlToListEntity(string rootElementName, string pathFile)
        {
            List<T> lstReturn = null;
            
            XmlAttributeOverrides overrides = new XmlAttributeOverrides();
            XmlAttributes attr = new XmlAttributes();
            attr.XmlRoot = new XmlRootAttribute(rootElementName);
            overrides.Add(typeof(List<T>), attr);

            using (XmlTextReader reader = new XmlTextReader(pathFile))
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<T>), overrides);
                lstReturn = ser.Deserialize(reader) as List<T>;   
            }
            return lstReturn;
        }


        /// <summary>
        /// Converte um XML em um objeto de tipo determinado
        /// </summary>
        /// <param name="xml">String do XML</param>
        /// <returns>Instância do objeto de tipo determinado</returns>
        public static T Convert(string xml)
        {
            StringReader stringReader = new StringReader(xml);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            return (T)xmlSerializer.Deserialize(stringReader);
        }
    }
}
