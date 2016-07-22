using System.Collections.Generic;
using Sam9araujo.NameProject.Domain;

namespace Sam9araujo.NameProject.Service.Omnion
{
    public class ProdutoBag
    {
        #region Fields
        private IList<Produto> _produtos;
        #endregion

        #region Properties
        public IList<Produto> Produtos
        {
            get { return this._produtos; }
        }
        #endregion

        #region Public Methods
        public void SetProdutos(IList<Produto> produtos)
        {
            this._produtos = produtos;
        }
        #endregion
    }
}
