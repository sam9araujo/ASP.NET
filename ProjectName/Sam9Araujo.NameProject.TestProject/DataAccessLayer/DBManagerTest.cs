using Sam9araujo.NameProject.DataAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.Configuration;

namespace Sam9araujo.NameProject.TestProject
{
    /// <summary>
    ///This is a test class for IDBManagerTest and is intended
    ///to contain all IDBManagerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DBManagerTest
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
       
        internal virtual IDBManager CreateIDBManager()
        {
            return new DBManager(ConfigurationManager.AppSettings["ConnectionString"].ToString());
        }

        /// <summary>
        ///A test for AddParameters
        ///</summary>
        [TestMethod()]
        public void AddParametersTest()
        {
            IDBManager target = CreateIDBManager();
            Assert.IsNotNull(target);

            int totalParameter = 1;

            target.CreateParameters(totalParameter);
            Assert.IsNotNull(target.Parameters);
            Assert.AreEqual(target.Parameters.Length, totalParameter);

            int index = 0;
            string paramName = "TESTE";
            object objValue = 1;
            target.AddParameters(index, paramName, objValue);

            Assert.IsNotNull(target.Parameters[index]);
        }

        /// <summary>
        ///A test for BeginTransaction
        ///</summary>
        [TestMethod()]
        public void BeginTransactionTest()
        {
            IDBManager target = CreateIDBManager();
            target.Open();            
            
            target.CreateParameters(1);
            target.AddParameters(0, "teste", 1);
            target.BeginTransaction();

            target.Close();
        }

        /// <summary>
        ///A test for Close
        ///</summary>        
        public void CloseTest()
        {
            IDBManager target = CreateIDBManager(); // TODO: Initialize to an appropriate value
            target.Close();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for CloseReader
        ///</summary>        
        public void CloseReaderTest()
        {
            IDBManager target = CreateIDBManager(); // TODO: Initialize to an appropriate value
            target.CloseReader();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for CommitTransaction
        ///</summary>        
        public void CommitTransactionTest()
        {
            IDBManager target = CreateIDBManager(); // TODO: Initialize to an appropriate value
            target.CommitTransaction();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for CreateParameters
        ///</summary>        
        public void CreateParametersTest()
        {
            IDBManager target = CreateIDBManager(); // TODO: Initialize to an appropriate value
            int paramsCount = 1; // TODO: Initialize to an appropriate value
            target.CreateParameters(paramsCount);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ExecuteDataSet
        ///</summary>        
        public void ExecuteDataSetTest()
        {
            IDBManager target = CreateIDBManager(); // TODO: Initialize to an appropriate value
            CommandType commandType = new CommandType(); // TODO: Initialize to an appropriate value
            string commandText = string.Empty; // TODO: Initialize to an appropriate value
            DataSet expected = null; // TODO: Initialize to an appropriate value
            DataSet actual;
            actual = target.ExecuteDataSet(commandType, commandText);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ExecuteNonQuery
        ///</summary>        
        public void ExecuteNonQueryTest()
        {
            IDBManager target = CreateIDBManager(); // TODO: Initialize to an appropriate value
            CommandType commandType = new CommandType(); // TODO: Initialize to an appropriate value
            string commandText = string.Empty; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.ExecuteNonQuery(commandType, commandText);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ExecuteReader
        ///</summary>        
        public void ExecuteReaderTest()
        {
            IDBManager target = CreateIDBManager(); // TODO: Initialize to an appropriate value
            CommandType commandType = new CommandType(); // TODO: Initialize to an appropriate value
            string commandText = string.Empty; // TODO: Initialize to an appropriate value
            IDataReader expected = null; // TODO: Initialize to an appropriate value
            IDataReader actual;
            actual = target.ExecuteReader(commandType, commandText);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ExecuteScalar
        ///</summary>        
        [TestMethod()]
        public void ExecuteScalarTest()
        {
            using (IDBManager target = CreateIDBManager())
            {
                CommandType commandType = CommandType.Text;
                string commandText = "Select count(*) from produto ";
                object actual = null;
                target.Open();
                actual = target.ExecuteScalar(commandType, commandText);
                target.Close();
                Assert.IsNotNull(actual);
            }
        }

        /// <summary>
        ///A test for Open
        ///</summary>        
        public void OpenTest()
        {
            IDBManager target = CreateIDBManager(); // TODO: Initialize to an appropriate value
            target.Open();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for RollbackTransaction
        ///</summary>        
        public void RollbackTransactionTest()
        {
            IDBManager target = CreateIDBManager(); // TODO: Initialize to an appropriate value
            target.RollbackTransaction();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Command
        ///</summary>        
        public void CommandTest()
        {
            IDBManager target = CreateIDBManager(); // TODO: Initialize to an appropriate value
            IDbCommand actual;
            actual = target.Command;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Connection
        ///</summary>        
        public void ConnectionTest()
        {
            IDBManager target = CreateIDBManager(); // TODO: Initialize to an appropriate value
            IDbConnection actual;
            actual = target.Connection;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ConnectionString
        ///</summary>        
        public void ConnectionStringTest()
        {
            IDBManager target = CreateIDBManager(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Connection.ConnectionString = expected;
            actual = target.Connection.ConnectionString;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DataReader
        ///</summary>        
        public void DataReaderTest()
        {
            IDBManager target = CreateIDBManager(); // TODO: Initialize to an appropriate value
            IDataReader actual;
            actual = target.DataReader;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Parameters
        ///</summary>        
        public void ParametersTest()
        {
            IDBManager target = CreateIDBManager(); // TODO: Initialize to an appropriate value
            IDbDataParameter[] actual;
            actual = target.Parameters;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ProviderType
        ///</summary>        
        public void ProviderTypeTest()
        {
            IDBManager target = CreateIDBManager(); // TODO: Initialize to an appropriate value
            DataProvider expected = new DataProvider(); // TODO: Initialize to an appropriate value
            DataProvider actual;
            target.ProviderType = expected;
            actual = target.ProviderType;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Transaction
        ///</summary>        
        public void TransactionTest()
        {
            IDBManager target = CreateIDBManager(); // TODO: Initialize to an appropriate value
            IDbTransaction actual;
            actual = target.Transaction;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
