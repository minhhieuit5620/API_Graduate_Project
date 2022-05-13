using System;
using System.Collections.Generic;
using System.Linq.Expressions;
//using System.Linq.Dynamic;
using System.Linq;
using ISCommon.Model;
using static ISCommon.Constant.Constant;

namespace ISCommon.Utility
{

    public static class ConnectionStringBuilder
    {       
        public static string BuilderConnectToSqlServer(string ServerIP,string ServerName, string databaseName,string userId,string passWord)
        {            
            return string.Format("Data Source={0};Initial Catalog={1};User Id={2};Password={3};", (!string.IsNullOrEmpty(ServerIP) ? ServerIP : "") + (string.IsNullOrEmpty(ServerName) ? "" : @"\" + ServerName), databaseName, userId, passWord);
        }

    }
}
