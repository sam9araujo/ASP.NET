using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sam9araujo.NameProject.Domain;
using System.Configuration;
using System.IO;
using Sam9araujo.NameProject.Repository;
using Sam9araujo.NameProject.DataAccessLayer;
using Sam9araujo.NameProject.Repository.DAL;

namespace Sam9araujo.NameProject.UI.Importacao
{
    public partial class FrmMain : Form
    {
        #region Atributos
        private Controller.ucNossosParceirosController Controller = null;
        private IList<Parceiro> lstParceiros = null;
        private IList<Produto> lstProdutos = null;
        private IList<Categoria> lstCategorias = null;
        private IList<int> lstIdCategoria = null;
        private DataSet ds = null;
        private BackgroundWorker bgWorker = null;
        private string[] _args = null;

        CategoriaRepository categoriaRepository = null;
        ProdutoRepository produtoRepository = null;


        #endregion

        public FrmMain(string[] args)
        {
            InitializeComponent();

            dg.Visible = false;

            Controller = new UI.Controller.ucNossosParceirosController();

            categoriaRepository = new CategoriaRepository();
            produtoRepository = new ProdutoRepository();

            LoadParceiro();

            bgWorker = new BackgroundWorker();
            bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);

            _args = args;            
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Engine(_args);
        }

        private void Engine(string[] args)
        {
            LoadProgressBar();

            if (lstParceiros != null)
            {
                if (args.Length == 0)
                {
                    string key = string.Empty;
                    string pathXML = string.Empty;
                    int idCategoria = 0;

                    foreach (Parceiro tParceiro in lstParceiros)
                    {
                        key = "arquivoProduto" + tParceiro.Nome;
                        pathXML = ConfigurationManager.AppSettings[key];
                        pathXML += ConfigurationManager.AppSettings["nomeArquivoProduto"];

                        if (File.Exists(pathXML))
                        {
                            LoadDataSet(pathXML);

                            lstCategorias = new List<Categoria>();
                            lstProdutos = new List<Produto>();
                            lstIdCategoria = new List<int>();
                            idCategoria = 0;

                            DesativarTodosProdutosDoParceiro(tParceiro.IdParceiro);

                            foreach (DataRow tProduto in ds.Tables[0].Rows)
                            {
                                idCategoria = ImportarCategorias(idCategoria, tParceiro, tProduto);
                                ImportarProdutos(idCategoria, tParceiro, tProduto);
                            }

                            LOG(tParceiro);
                        }
                    }

                    LimparListas();
                    LoadProgressBar();

                }
                else
                {
                    //se lista de parceiros for nula...
                }
            }

            this.Invoke((MethodInvoker)delegate {
                txtLOG.AppendText("-----------------------------");
                txtLOG.AppendText("Fim!");
                progressBar.Value = 100;
            });

            
        }

        private void LoadProgressBar()
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtLOG.AppendText("-----------------------------");
                txtLOG.AppendText(DateTime.Now.ToString());
                txtLOG.AppendText("-----------------------------");
                progressBar.PerformStep();
            });            
        }

        private void LimparListas()
        {
            if (ds != null)
            {
                ds.Clear();
                ds.Dispose();
            }
            ds = null;

            if (lstProdutos != null)
                lstProdutos.Clear();

            if (lstCategorias != null)
                lstCategorias.Clear();

            lstProdutos = null;
            lstCategorias = null;
        }

        private void LOG(Parceiro tParceiro)
        {
            this.Invoke((MethodInvoker)delegate
            {

                txtLOG.AppendText("Parceiro: " + tParceiro.Nome);
                txtLOG.AppendText(Environment.NewLine);

                txtLOG.AppendText("Categorias: " + lstIdCategoria.Count);
                txtLOG.AppendText(Environment.NewLine);

                txtLOG.AppendText("Produtos: " + ds.Tables[0].Rows.Count);
                txtLOG.AppendText(Environment.NewLine);

                txtLOG.AppendText("------------------------------");
                txtLOG.AppendText(Environment.NewLine);
            });
        }

        private void ImportarProdutos(int idCategoria, Parceiro tParceiro, DataRow tProduto)
        {
            try
            {
                //Produto Produto = null;

                Produto Produto = new Produto
                {
                    IdProduto = tProduto["ID"].ToString(),
                    IdParceiro = tParceiro.IdParceiro,
                    IdCategoria = idCategoria,                    
                    DataAlteracao = DateTime.Now,
                    Nome = tProduto["NAME"].ToString(),
                    Titulo = string.Empty,
                    Observacao = string.Empty,
                    Link = tProduto["URL"].ToString() + "&Login=generico&token=f78be9eb051a8a009121dd79c16b655e",
                    Descricao = tProduto["DESCRIPTION"].ToString(),
                    Usuario = "NameProject",
                    Nivel = 1,
                    IsAtivo = true,
                    IsDisponivel = true,
                    OrdemDestaque = 1
                };

                Produto.Preco = float.Parse(tProduto["PRICEPROMO"].ToString().Replace('.',','));
                Produto.PrecoCheio = float.Parse(tProduto["PRICE"].ToString().Replace('.', ','));

                Produto.Pontos = CarregarPontos(tProduto, Produto, tParceiro);

                Produto.ImagemThumbnail = CarregarImagemProduto(tProduto);

                string strSQL = "SELECT totalUpdate FROM PRODUTO WHERE idProduto = '" + Produto.IdProduto + "' AND idParceiro = " + tParceiro.IdParceiro;
                int totalUpdate = int.Parse(ExecuteScalar(strSQL).ToString());

                Produto.DataCadastro = DateTime.Now;
                if (totalUpdate == 0)
                {
                    totalUpdate = 1;                    
                    Produto.TotalUpdate = totalUpdate;
                    produtoRepository.Insert(Produto);
                }
                else
                {
                    totalUpdate++;
                    Produto.TotalUpdate = totalUpdate;
                    produtoRepository.Update(Produto);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private object ExecuteScalar(string strSQL)
        {
            object retorno = 0;

            DBManager dbManager = new DBManager(ConfigurationManager.AppSettings["ConnectionString"]);

            try
            {
                dbManager.Open();
                retorno = dbManager.ExecuteScalar(CommandType.Text, strSQL).ToString();
            }
            catch { }

            finally {
                dbManager.Close();
                dbManager.Dispose();
            }

            return retorno;
        }
        private int DesativarTodosProdutosDoParceiro(int idParceiro)
        {
            int retorno = 0;

            DBManager dbManager = new DBManager(ConfigurationManager.AppSettings["ConnectionString"]);

            string strSQL = "UPDATE produto SET isAtivo=0, isDisponivel=0 WHERE idParceiro = " + idParceiro;

            try
            {
                dbManager.Open();
                retorno = dbManager.ExecuteNonQuery(CommandType.Text, strSQL);
            }
            catch { }

            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }

            return retorno;
        }

        private int CarregarPontos(DataRow tProduto, Produto produto, Parceiro parceiro)
        {
            int retorno = 0;

            try
            {
                retorno = int.Parse(tProduto["POINTS"].ToString());
            }
            catch            
            {
                try
                {
                    retorno = (int)Math.Round((((produto.PrecoCheio * parceiro.PercentualPreco) / 100) * parceiro.PercentualPontos));
                }
                catch
                {
                    retorno = 0;
                }
            }

            return retorno;
        }

        private string CarregarImagemProduto(DataRow tProduto)
        {
            string retorno = "";
            try
            {
                foreach (DataRow tImagemList in tProduto.GetChildRows(ds.Tables[0].ChildRelations[0]))
                {
                    foreach (DataRow tImagem in tImagemList.GetChildRows(ds.Tables[1].ChildRelations[0]))
                    {
                        if (tImagem["TYPE"].ToString().ToLower() == "thumbnail")
                            retorno = tImagem["URL"].ToString();
                    }
                }
            }
            catch { }

            return retorno;
        }

        private int ImportarCategorias(int idCategoria, Parceiro tParceiro, DataRow tProduto)
        {
            idCategoria = int.Parse(tProduto["CATEGORY_ID"].ToString().Split(':')[tProduto["CATEGORY_ID"].ToString().Split(':').Length - 1]);

            if (!lstIdCategoria.Contains(idCategoria))
            {
                lstIdCategoria.Add(idCategoria);
                try
                {
                    Categoria Categoria = new Categoria
                    {
                        IdCategoria = idCategoria,
                        IdParceiro = tParceiro.IdParceiro,
                        DataCadastro = DateTime.Now,
                        Descricao = tProduto["CATEGORY"].ToString().Split(':')[tProduto["CATEGORY"].ToString().Split(':').Length - 1]
                    };

                    string strSQL = "SELECT idCategoria FROM CATEGORIA WHERE idCategoria = " + Categoria.IdCategoria + " AND idParceiro = " + tParceiro.IdParceiro;                    
                    int idCategoriaTmp = int.Parse(ExecuteScalar(strSQL).ToString());

                    if (idCategoriaTmp == 0)
                    {
                        categoriaRepository.Insert(Categoria);
                    }
                    else
                    {
                        categoriaRepository.Update(Categoria);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return idCategoria;
        }

        private void LoadDataSet(string pathXML)
        {
            ds = new DataSet();
            ds.ReadXml(pathXML, XmlReadMode.Auto);
        }

        private void LoadParceiro()
        {
            Controller.CarregarListaParceiros();
            lstParceiros = Controller.View.Parceiros;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            bgWorker.RunWorkerAsync();
        }
    }
}
