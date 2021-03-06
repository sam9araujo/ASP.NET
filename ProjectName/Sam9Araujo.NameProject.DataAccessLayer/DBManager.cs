﻿using System;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace Sam9araujo.NameProject.DataAccessLayer
{
    public sealed class DBManager : IDBManager, IDisposable
    {
        #region ATRIBUTOS
        private IDbConnection idbConnection = null;
        private IDataReader idataReader = null;
        private IDbCommand idbCommand = null;
        private DataProvider providerType;
        private IDbTransaction idbTransaction = null;
        private IDbDataParameter[] idbParameters = null;
        private string strConnection = null;

        #endregion

        #region CONSTRUTOR
        public DBManager()
        {
            this.providerType = DataProvider.SqlServer;
        }
        public DBManager(string connectionString)
        {
            this.providerType = DataProvider.SqlServer;
            this.strConnection = connectionString;
        }
        public DBManager(DataProvider providerType)
        {
            this.providerType = providerType;
        }
        public DBManager(DataProvider providerType, string connectionString)
        {
            this.providerType = providerType;
            this.strConnection = connectionString;
        }
        #endregion

        #region PROPRIEDADES
        public IDbConnection Connection
        {
            get
            {
                if (idbConnection == null)
                    idbConnection = DBManagerFactory.GetConnection(this.ProviderType);

                return idbConnection;
            }
        }
        public IDataReader DataReader
        {
            get
            {
                return idataReader;
            }
            set
            {
                idataReader = value;
            }
        }

        public DataProvider ProviderType
        {
            get
            {
                return providerType;
            }
            set
            {
                providerType = value;
            }
        }
        public IDbCommand Command
        {
            get
            {
                return idbCommand;
            }
        }
        public IDbTransaction Transaction
        {
            get
            {
                return idbTransaction;
            }
        }
        public IDbDataParameter[] Parameters
        {
            get
            {
                return idbParameters;
            }
            set
            {
                idbParameters = value;
            }
        }
        #endregion

        public void Open()
        {
            Connection.ConnectionString = this.strConnection;

            if (Connection.State != ConnectionState.Open)
                Connection.Open();

            this.idbCommand = DBManagerFactory.GetCommand(this.ProviderType);
        }
        public void Close()
        {
            if (idbConnection != null)
            {
                if (idbConnection.State != ConnectionState.Closed)
                    idbConnection.Close();
            }
        }

        public void CreateParameters(int paramsCount)
        {
            //idbParameters = new IDbDataParameter[paramsCount];
            idbParameters = DBManagerFactory.GetParameters(this.ProviderType, paramsCount);
        }
        public void AddParameters(int index, string paramName, object objValue)
        {
            if (index < idbParameters.Length)
            {
                idbParameters[index].ParameterName = paramName;
                idbParameters[index].Value = objValue;
            }
        }

        public void BeginTransaction()
        {
            if (this.idbTransaction == null)
                idbTransaction = DBManagerFactory.GetTransaction(this.ProviderType, this.Connection);

            this.idbCommand.Transaction = idbTransaction;
        }
        public void CommitTransaction()
        {
            if (this.idbTransaction != null)
                this.idbTransaction.Commit();
            idbTransaction = null;
        }
        public void RollbackTransaction()
        {
            if (this.idbTransaction != null)
                this.idbTransaction.Rollback();
            idbTransaction = null;
        }

        public int ExecuteNonQuery(CommandType commandType, string commandText)
        {
            this.idbCommand = DBManagerFactory.GetCommand(this.ProviderType);
            PrepareCommand(idbCommand, this.Connection, this.Transaction,
            commandType, commandText, this.Parameters);
            int returnValue = idbCommand.ExecuteNonQuery();
            //idbCommand.Parameters.Clear();
            return returnValue;
        }
        public object ExecuteScalar(CommandType commandType, string commandText)
        {
            this.idbCommand = DBManagerFactory.GetCommand(this.ProviderType);
            PrepareCommand(idbCommand, this.Connection, this.Transaction, commandType, commandText, this.Parameters);
            object returnValue = idbCommand.ExecuteScalar();
            //idbCommand.Parameters.Clear();
            return returnValue;
        }
        public DataSet ExecuteDataSet(CommandType commandType, string commandText)
        {
            this.idbCommand = DBManagerFactory.GetCommand(this.ProviderType);
            PrepareCommand(idbCommand, this.Connection, this.Transaction, commandType, commandText, this.Parameters);
            IDbDataAdapter dataAdapter = DBManagerFactory.GetDataAdapter(this.ProviderType);
            dataAdapter.SelectCommand = idbCommand;
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            //idbCommand.Parameters.Clear();
            return dataSet;
        }
        
        public IDataReader ExecuteReader(CommandType commandType, string commandText)
        {
            this.idbCommand = DBManagerFactory.GetCommand(this.ProviderType);
            idbCommand.Connection = this.Connection;
            PrepareCommand(idbCommand, this.Connection, this.Transaction, commandType, commandText, this.Parameters);
            this.DataReader = idbCommand.ExecuteReader();
            //idbCommand.Parameters.Clear();
            return this.DataReader;
        }
        public void CloseReader()
        {
            if (this.DataReader != null)
                this.DataReader.Close();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            this.Close();

            if (idbCommand != null)
            {
                this.idbCommand.Dispose();
                this.idbCommand = null;

            }

            if (idbTransaction != null)
            {
                this.idbTransaction.Dispose();
                this.idbTransaction = null;
            }

            if (idbConnection != null)
            {
                this.Connection.Dispose();
                this.idbConnection = null;
            }
        }

        private void AttachParameters(IDbCommand command, IDbDataParameter[] commandParameters)
        {
            foreach (IDbDataParameter idbParameter in commandParameters)
            {
                if ((idbParameter.Direction == ParameterDirection.InputOutput) && (idbParameter.Value == null))
                {
                    idbParameter.Value = DBNull.Value;
                }
                command.Parameters.Add(idbParameter);
            }
        }
        private void PrepareCommand(IDbCommand command, IDbConnection connection, IDbTransaction transaction, CommandType commandType, string commandText, IDbDataParameter[] commandParameters)
        {
            command.Connection = connection;
            command.CommandText = commandText;
            command.CommandType = commandType;

            if (transaction != null)
            {
                command.Transaction = transaction;
            }

            if (commandParameters != null)
            {
                AttachParameters(command, commandParameters);
            }
        }

    }
}