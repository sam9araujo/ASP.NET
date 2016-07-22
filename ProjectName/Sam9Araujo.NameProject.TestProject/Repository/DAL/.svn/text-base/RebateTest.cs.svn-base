using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Laboris.Cosan.Repository.DAL;
using Laboris.Cosan.Domain;
using System.Data;

namespace Laboris.Cosan.TestProject.Repository.DAL
{
    /// <summary>
    ///This is a test class for ParceiroDALTest and is intended
    ///to contain all ParceiroDALTest Unit Tests
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

        [TestMethod()]
        public void ListarTodosTest()
        {
            RebateDAL target = new RebateDAL();
            IList<Rebate> actual = null;
            actual = target.Listar();
            Assert.IsNotNull(actual);
        }

        [TestMethod()]
        public void ObterTest()
        {
            RebateDAL target = new RebateDAL();
            Rebate actual = null;
            actual = target.Obter("idProduto=1");
            Assert.IsNotNull(actual);
        }

        //[TestMethod()]
        public void FactoryTest()
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
    }
}
