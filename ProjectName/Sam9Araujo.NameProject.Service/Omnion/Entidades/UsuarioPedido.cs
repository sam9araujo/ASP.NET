#region Imports

#endregion

namespace Sam9araujo.NameProject.Service.Omnion
{
    /// <summary>
    /// Classe da entidade OmnionLogin e pedido
    /// </summary>
    public class UsuarioPedido
    {
        #region Fields
        private Pedido _pedido;
        #endregion

        #region Automatic Properties
        /// <summary>
        /// Grava e recupera a OmnionLogin
        /// </summary>
        public Login Usuario { get; set; }
        #endregion

        #region Properties
        /// <summary>
        /// Grava e recupera a pedido
        /// </summary>
        public Pedido Pedido
        {
            get { return this._pedido; }
        }
        #endregion

        #region Public Methods
        public void SetPedido(Pedido pedido)
        {
            this._pedido = pedido;
        }
        #endregion
    }
}
