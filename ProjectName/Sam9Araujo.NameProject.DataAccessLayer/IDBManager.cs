﻿using System;
using System.Data;
using System.Data.SqlClient;
 
namespace Sam9araujo.NameProject.DataAccessLayer
{
    public enum DataProvider
    {
        SqlServer, Oracle, OleDb, Odbc
    }

    public interface IDBManager : IDisposable
    {
        DataProvider ProviderType
        {
            get;
            set;
        }

        //string ConnectionString
        //{
        //    get;
        //    set;
        //}

        IDbConnection Connection
        {
            get;
        }
        IDbTransaction Transaction
        {
            get;
        }

        IDataReader DataReader
        {
            get;
        }
        IDbCommand Command
        {
            get;
        }

        IDbDataParameter[] Parameters
        {
            get;
            set;
        }

        void Open();
        void Close();

        void CreateParameters(int paramsCount);
        void AddParameters(int index, string paramName, object objValue);

        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();

        IDataReader ExecuteReader(CommandType commandType, string commandText);
        void CloseReader();

        object ExecuteScalar(CommandType commandType, string commandText);
        
        int ExecuteNonQuery(CommandType commandType, string commandText);

        DataSet ExecuteDataSet(CommandType commandType, string commandText);
        
        
    }
}