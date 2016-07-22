#region Document Header

/******************************************************************************
 * e-Commerce - Versão 2
 * Copyright (C)2011 - NameProject
 * http://www.NameProject.com.br/
 * 
 * Desenvolvido por:
 * Bruno D'Alessio - 01/02/2011
 * Sam9araujo Consultoria Ltda.
 * http://www.Sam9araujo.com.br
 *
 ******************************************************************************/

#endregion

using System.Xml.Serialization;
using System.Collections.Generic;

namespace Sam9araujo.NameProject.Domain
{
    [XmlRoot("PRODUCT"),System.Serializable()]
    public class ImportacaoProdutoXML
    {
        #region Automatic Properties
        [XmlElement("ID")]
        public string Id { get; set; }

        [XmlElement("NAME")]
        public string Name { get; set; }

        [XmlElement("PRICE")]
        public float Price { get; set; }

        [XmlElement("FREIGHT")]
        public float Freight { get; set; }

        [XmlElement("DESCRIPTION")]
        public string Description { get; set; }

        [XmlElement("PARTNER")]
        public int Partner { get; set; }

        //private List<string> lstCategory = new List<string>();
        [XmlArray("CATEGORY")]
        public List<string> Category { get; set; }

        //private List<int> lstCategoryId = new List<int>();
        [XmlArray("CATEGORY_ID")]
        public List<int> CategoryId { get; set; }

        [XmlArray("IMAGE")]
        public List<string> Image { get; set; }
        
        //[XmlElement("IMAGE")]
        //public string Image { get; set; }
        #endregion

        #region Properties
        public Produto Produto
        {
            get
            {
                Produto produto = new Produto { IdProduto = this.Id, Nome = this.Name, PrecoCheio = this.Price, Imagem = GetListImage(), IdCategoria = this.CategoryId[1], Frete = this.Freight, Descricao = this.Description, IdParceiro = this.Partner, ImagemThumbnail = GetImagemThumbnail() };
                return produto;
            }
        }

        private string GetImagemThumbnail()
        {
            if (this.Image != null)
            {
                if (this.Image.Count > 0)
                    return this.Image[0];
                else
                    return string.Empty;
            }
            else
                return string.Empty;

        }

        private List<string> GetListImage()
        {
            if (this.Image == null)
                this.Image = new List<string>();

            return this.Image;
        }

        //public Categoria Categoria
        //{
        //    get
        //    {
        //        Categoria categoria = new Categoria { Descricao = this.Category[this.Category.Count-1], Codigo = this.CategoryId[1] };
        //        return categoria;
        //    }
        //}
        #endregion
    }
}
