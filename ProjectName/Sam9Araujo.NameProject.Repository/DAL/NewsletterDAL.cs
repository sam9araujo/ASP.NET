﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sam9araujo.NameProject.Domain;
using Sam9araujo.NameProject.DataAccessLayer;
using System.Configuration;
using System.Data;

namespace Sam9araujo.NameProject.Repository.DAL
{
    public class NewsletterDAL : BaseDAL<Newsletter>
    {
        public override string SqlSELECT
        {
            get { return QuerysSQL.selectNewsletter; }

        }
        public override string SqlINSERT
        {
            get { return QuerysSQL.insertNewsletter; }
        }

        public override string SqlUPDATE
        {
            get { return QuerysSQL.updateNewsletter; }
        }

        public override string SqlDELETE
        {
            get { return QuerysSQL.deleteNewsletter; }
        }

        public override string SqlWhereKey
        {
            get { return QuerysSQL.whereKeyNewsletter; }
        }

        internal override void ExecuteIncludes(List<Newsletter> newsletter)
        {
        }

        internal override IDbDataParameter[] PrepareParametersFactory(Newsletter newsletter, bool includeKeys = false)
        {
            IDbDataParameter[] dataParameters;

            if (includeKeys)
                dataParameters = DBManagerFactory.GetParameters(DataProvider.SqlServer, 4);
            else
                dataParameters = DBManagerFactory.GetParameters(DataProvider.SqlServer, 3);
           
            dataParameters[0].ParameterName = "idNewsletter";
            dataParameters[0].DbType = DbType.Int32;
            dataParameters[0].Value = newsletter.IdNewsletter;

            dataParameters[1].ParameterName = "email";
            dataParameters[1].DbType = DbType.String;
            dataParameters[1].Value = newsletter.Email;

            dataParameters[2].ParameterName = "data";
            dataParameters[2].DbType = DbType.DateTime;
            dataParameters[2].Value = newsletter.Data;

            if (includeKeys)
            {
                keyMethod(newsletter, dataParameters, 3);
            }
            
            return dataParameters;
        }

        private static void keyMethod(Newsletter newsletter, IDbDataParameter[] dataParameters, int i)
        {
            dataParameters[i].ParameterName = "idNewsletterKey";
            dataParameters[i].DbType = DbType.Int32;
            dataParameters[i].Value = newsletter.IdNewsletter;
        }

        internal override IDbDataParameter[] PrepareParametersKeyFactory(Newsletter newsletter)
        {
            IDbDataParameter[] dataParameters = DBManagerFactory.GetParameters(DataProvider.SqlServer, 1);

            keyMethod(newsletter, dataParameters, 0);

            return dataParameters;
        }

        public NewsletterDAL()
        {

        }

        public override Newsletter Factory(IDataReader DataReader)
        {
            Newsletter newsletter = new Newsletter();
            {
                newsletter.IdNewsletter = int.Parse(DataReader["idNewsletter"].ToString());
                newsletter.Email = DataReader["email"].ToString();
                newsletter.Data = DateTime.Parse(DataReader["data"].ToString());
            }
            return newsletter;
        }

    }
}