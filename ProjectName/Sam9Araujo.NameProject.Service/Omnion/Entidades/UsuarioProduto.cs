using Sam9araujo.NameProject.Domain;
namespace Sam9araujo.NameProject.Service.Omnion
{
    /// <summary>
    /// Classe da entidade OmnionLogin e Produto
    /// </summary>
    public class UsuarioProduto
    {
        #region Fields
        private Produto _produto;
        #endregion

        #region Automatic Properties
        /// <summary>
        /// Grava e recupera a OmnionLogin
        /// </summary>
        public Login Usuario { get; set; }
        #endregion

        #region Properties
        /// <summary>
        /// Grava e recupera a Produto
        /// </summary>
        public Produto Produto
        {
            get { return this._produto; }
        }
        #endregion

        #region Public Methods
        public void SetProduto(Produto produto)
        {
            this._produto = produto;
        }
        #endregion
    }
}
