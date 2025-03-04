﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DataLibrary1.Models;

namespace DataLibrary1.DataAccess
{
    public static class SqlDataAccess
    {
        public static string GetConnectionString(string connectionName = "E-CommerceDB1")
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql).ToList();
            }
        }

        public static T LoadData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                    return cnn.Query<T>(sql, data).First();            
            }
        }

        //public static List<T> LoadCartData<T>(string sql, T data)
        //{
        //    using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
        //    {
        //        return cnn.Query<T>(sql, data).ToList();
        //    }
        //}

        //public static List<T> LoadOrderData<T>(string sql, T data)
        //{
        //    using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
        //    {
        //        return cnn.Query<T>(sql, data).ToList();
        //    }
        //}

        public static List<T> LoadListData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql, data).ToList();
            }
        }

        public static bool CheckData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql, data).Any();
            }
        }

        public static int SaveData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Execute(sql, data);
            }
        }
    }
}
