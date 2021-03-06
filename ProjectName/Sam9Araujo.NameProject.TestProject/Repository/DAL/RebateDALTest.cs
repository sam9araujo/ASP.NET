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
    /// <summary>
    ///This is a test class for ProdutoDALTest and is intended
    ///to contain all ProdutoDALTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RebateDALTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
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
        /// <summary>
        ///A test for Listar
        ///</summary>
        [TestMethod()]
        public void ListarTest()
        {
            RebateDAL target = new RebateDAL();
            IList<Rebate> actual = null;
            target.ProdutoDAL.Include();
            actual = target.Listar();
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for Listar(string where)
        ///</summary>
        [TestMethod()]
        public void ListarWhereTest()
        {
            RebateDAL target = new RebateDAL();
            IList<Rebate> actual = null;
            actual = target.Listar("idParceiro = 1");
            Assert.IsNotNull(actual);
        }
        /*
                /// <summary>
                ///A test for ObterParceiro
                ///</summary>
                [TestMethod()]
                public void ObterParceiroTest()
                {
                    ParceiroDAL target = new ParceiroDAL();
                    Parceiro actual = null;
                    actual = target.ObterParceiro("id = 1");
                    Assert.IsNotNull(actual);
                }
                */
        /// <summary>
        ///A test for ProdutoFactory
        ///</summary>
        //[TestMethod()]
        public void RebateFactoryTest()
        {
            RebateDAL dal = new RebateDAL();
            //dal.
            IDataReader DataReader = null;
            Rebate expected = null; // TODO: Initialize to an appropriate value
            Rebate actual;
            actual = dal.Factory(DataReader);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Insert
        ///</summary>
        [TestMethod()]
        public void InsertTest()
        {
            RebateDAL target = new RebateDAL();
            Rebate rebate = new Rebate();

            rebate.IdProduto = 1;
            rebate.IdParceiro = 1 ;
            rebate.Data = DateTime.Now;
            rebate.Valor = 4;

            target.Insert(rebate);

            Rebate rebateTest = target.Obter("IdProduto = 1 AND IdParceiro = 1");

            Assert.AreEqual(rebate.IdProduto, rebateTest.IdProduto);
            Assert.AreEqual(rebate.IdParceiro, rebateTest.IdParceiro);
            Assert.AreNotEqual(rebate.Data, rebateTest.Data);
            Assert.AreEqual(rebate.Valor, rebateTest.Valor);
        }
        //[TestMethod()]
        public void UpdateTest()
        {
            RebateDAL target = new RebateDAL();
            Rebate rebate = new Rebate();

            rebate.IdProduto = 101;
            rebate.IdParceiro = 1;
            rebate.Data = DateTime.Now;
            rebate.Valor = 4333;

            target.Update(rebate);

            Assert.AreEqual(rebate, target.Obter("IdProduto = 101 AND IdParceiro = 1"));

        }
       //[TestMethod()]
        public void DeleteTest()
        {
            RebateDAL target = new RebateDAL();
            Rebate rebate = new Rebate();

            rebate.IdProduto = 101;
            rebate.IdParceiro = 1;
            rebate.Data = DateTime.Now;
            rebate.Valor = 4333;

            target.Delete(rebate);

            Assert.AreEqual(rebate, target.Obter("IdProduto = 101 AND IdParceiro = 1"));

        }
    }
}
