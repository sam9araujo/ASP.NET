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
    public class AtributoProdutoDALTest
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
            AtributoProdutoDAL target = new AtributoProdutoDAL();
            IList<AtributoProduto> actual = null;
            actual = target.Listar();
            Assert.IsNotNull(actual);
        }

        [TestMethod()]
        public void ObterTest()
        {
            AtributoProdutoDAL target = new AtributoProdutoDAL();
            AtributoProduto actual = null;
            actual = target.Obter("idAtributo = 1");
            Assert.IsNotNull(actual);
        }

        //[TestMethod()]
        public void FactoryTest()
        {
            AtributoProdutoDAL dal = new AtributoProdutoDAL();
            //dal.
            IDataReader DataReader = null;
            AtributoProduto expected = null; // TODO: Initialize to an appropriate value
            AtributoProduto actual;
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
            AtributoProdutoDAL target = new AtributoProdutoDAL();
            AtributoProduto atributo = new AtributoProduto();

            atributo.IdParceiro = 1;
            atributo.IdProduto = 101;
            atributo.Atributo = "Teste";
            atributo.DataCadastro = DateTime.Now;
            atributo.Descricao = "Teste";
            atributo.IsDisponivel = true;

            target.Insert(atributo);
            AtributoProduto atributoTest = target.Obter("IdAtributo = " + atributo.IdAtributo + " AND IdParceiro = " + atributo.IdParceiro + "AND IdProduto = " + atributo.IdProduto);

            Assert.AreEqual(atributo.IdProduto, atributoTest.IdProduto);
            Assert.AreEqual(atributo.IdParceiro, atributoTest.IdParceiro);
            Assert.AreEqual(atributo.Descricao, atributoTest.Descricao);
            Assert.AreEqual(atributo.IsDisponivel, atributoTest.IsDisponivel);

            Assert.AreEqual(atributo.DataCadastro,atributoTest.DataCadastro);
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        //[TestMethod()]
        public void UpdateTest()
        {
            AtributoProdutoDAL target = new AtributoProdutoDAL();
            AtributoProduto atributo = new AtributoProduto();

            atributo.IdAtributo = 1;
            atributo.IdParceiro = 1;
            atributo.IdProduto = 101;
            atributo.Atributo = "Teste3";
            atributo.DataCadastro = DateTime.Now;
            atributo.Descricao = "Teste3";
            atributo.IsDisponivel = true;

            target.Update(atributo);
            AtributoProduto atributoTest = target.Obter("IdAtributo = " + atributo.IdAtributo);

            Assert.AreEqual(atributo.IdProduto, atributoTest.IdProduto);
            Assert.AreEqual(atributo.IdParceiro, atributoTest.IdParceiro);
            Assert.AreEqual(atributo.Descricao, atributoTest.Descricao);
            Assert.AreEqual(atributo.IsDisponivel, atributoTest.IsDisponivel);
            Assert.AreEqual(atributo.IdAtributo, atributoTest.IdAtributo);
            Assert.AreEqual(atributo.DataCadastro, atributoTest.DataCadastro);
        }

        /// <summary>
        ///A test for Delete
        ///</summary>
       [TestMethod()]
        public void DeleteTest()
        {
            AtributoProdutoDAL target = new AtributoProdutoDAL();
            AtributoProduto atributo = new AtributoProduto();

            atributo.IdAtributo = 1;

            target.Delete(atributo);
        }
      
    }
}
