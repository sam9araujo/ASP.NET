﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sam9araujo.NameProject.Repository.DAL;
using Sam9araujo.NameProject.Domain;
using System.Data;

namespace Sam9araujo.NameProject.TestProject.Repository.DAL
{
    [TestClass]
    public class ImagemProdutoDALTest
    {
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod()]
        public void ListarTodosTest()
        {
            ImagemProdutoDAL target = new ImagemProdutoDAL();
            IList<ImagemProduto> actual = null;
            actual = target.Listar();
            Assert.IsNotNull(actual);
        }

        [TestMethod()]
        public void ObterTest()
        {
            ImagemProdutoDAL target = new ImagemProdutoDAL();
            ImagemProduto actual = null;
            actual = target.Obter("idCategoria = 1");
            Assert.IsNotNull(actual);
        }

        //[TestMethod()]
        public void FactoryTest()
        {
            ImagemProdutoDAL dal = new ImagemProdutoDAL();
            //dal.
            IDataReader DataReader = null;
            ImagemProduto expected = null; // TODO: Initialize to an appropriate value
            ImagemProduto actual;
            actual = dal.Factory(DataReader);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
        /// <summary>
        ///A test for Insert
        ///</summary>
        //[TestMethod()]
        public void InsertTest()
        {
            ImagemProdutoDAL target = new ImagemProdutoDAL();
            ImagemProduto imagemProduto = new ImagemProduto();

            imagemProduto.IdParceiro = 1;
            imagemProduto.IdProduto= 101;
            imagemProduto.Imagem = "teste2.jpg";
            imagemProduto.DataCadastro = DateTime.Now;
           
            target.Insert(imagemProduto);
            ImagemProduto imagemProdutoTest = target.Obter("IdParceiro = " + imagemProduto.IdParceiro + " AND IdProduto = " + imagemProduto.IdProduto);

            Assert.AreEqual(imagemProduto.IdParceiro, imagemProdutoTest.IdParceiro);
            Assert.AreEqual(imagemProduto.Imagem, imagemProdutoTest.Imagem);
            Assert.AreEqual(imagemProduto.DataCadastro, imagemProdutoTest.DataCadastro);
            Assert.AreEqual(imagemProduto.IdProduto, imagemProdutoTest.IdProduto);
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            ImagemProdutoDAL target = new ImagemProdutoDAL();
            ImagemProduto imagemProduto = new ImagemProduto();

            imagemProduto.IdImagem = 1;
            imagemProduto.IdParceiro = 1;
            imagemProduto.IdProduto = 101;
            imagemProduto.Imagem = "teste4.jpg";
            imagemProduto.DataCadastro = DateTime.Now;

            target.Update(imagemProduto);
            ImagemProduto imagemProdutoTest = target.Obter("IdParceiro = " + imagemProduto.IdParceiro + " AND IdProduto = " + imagemProduto.IdProduto);

            Assert.AreEqual(imagemProduto.IdParceiro, imagemProdutoTest.IdParceiro);
            Assert.AreEqual(imagemProduto.Imagem, imagemProdutoTest.Imagem);
            Assert.AreEqual(imagemProduto.DataCadastro, imagemProdutoTest.DataCadastro);
            Assert.AreEqual(imagemProduto.IdProduto, imagemProdutoTest.IdProduto);
        }

        /// <summary>
        ///A test for Delete
        ///</summary>
        [TestMethod()]
        public void DeleteTest()
        {
            ImagemProdutoDAL target = new ImagemProdutoDAL();
            ImagemProduto imagemProduto = new ImagemProduto();

            imagemProduto.IdImagem = 2;
            imagemProduto.IdParceiro = 1;
            imagemProduto.IdProduto = 101;

            target.Delete(imagemProduto);

            //Assert.(ambiente, target.Obter("IdAmbiente = 101"));
        }
    }
}