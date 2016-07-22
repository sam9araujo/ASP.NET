using Sam9araujo.NameProject.DataAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.Configuration;
using Laboris.Cosan.DataAccessLayer;

namespace Sam9araujo.NameProject.TestProject
{ 
    /// <summary>
    ///This is a test class for DBManagerFactoryTest and is intended
    ///to contain all DBManagerFactoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DBManagerFactoryTest
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
        ///A test for DBManagerFactory Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Sam9araujo.NameProject.DataAccessLayer.dll")]
        public void DBManagerFactoryConstructorTest()
        {
            DBManagerFactory_Accessor target = new DBManagerFactory_Accessor();

            Assert.IsNotNull(target.Target);
            Assert.AreEqual(target.Target.ToString(), "Sam9araujo.NameProject.DataAccessLayer.DBManagerFactory");
        }

        /// <summary>
        ///A test for GetCommand
        ///</summary>
        [TestMethod()]
        public void GetCommandTest()
        {
            DataProvider providerType = DataProvider.SqlServer;
            IDbCommand actual;
            actual = DBManagerFactory.GetCommand(providerType);
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for GetConnection
        ///</summary>
        [TestMethod()]
        public void GetConnectionTest()
        {
            DataProvider providerType = DataProvider.SqlServer;
            IDbConnection actual;
            actual = DBManagerFactory.GetConnection(providerType);
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for GetDataAdapter
        ///</summary>
        [TestMethod()]
        public void GetDataAdapterTest()
        {
            DataProvider providerType = DataProvider.SqlServer;
            IDbDataAdapter actual;
            actual = DBManagerFactory.GetDataAdapter(providerType);
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for GetParameter
        ///</summary>
        [TestMethod()]
        public void GetParameterTest()
        {
            DataProvider providerType = DataProvider.SqlServer;
            IDataParameter actual;
            actual = DBManagerFactory.GetParameter(providerType);
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for GetParameters
        ///</summary>
        [TestMethod()]
        public void GetParametersTest()
        {
            DataProvider providerType = DataProvider.SqlServer;
            int paramsCount = 100;
            IDbDataParameter[] actual;
            actual = DBManagerFactory.GetParameters(providerType, paramsCount);
            Assert.IsNotNull(actual);
            Assert.AreEqual(paramsCount, actual.Length);
        }

        /// <summary>
        ///A test for GetTransaction
        ///</summary>
        [TestMethod()]
        public void GetTransactionTest()
        {
            DataProvider providerType = DataProvider.SqlServer;
            IDbTransaction actual;
            using (IDBManager manager = new DBManager(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                manager.Open();
                actual = DBManagerFactory.GetTransaction(providerType, manager.Connection);
                Assert.IsNotNull(actual);
                manager.Close();
            }
        }
    }
}
