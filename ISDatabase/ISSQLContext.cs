using System.Collections.Generic;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;
using System.Data.SqlClient;
using KSHYDatabase;

namespace KSHYDatabase
{
    public class ISSQLContext
    {
        private string _connectionString;
        public ISSQLContext(string connectionString)
        {
            _connectionString = connectionString;
        }    
        protected static void RegisterConvention(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                if (entity.ClrType.Namespace != null)
                {
                    var nameParts = entity.ClrType.Namespace.Split('.');
                    var tableName = string.Concat(nameParts[2], "_", entity.ClrType.Name);
                    modelBuilder.Entity(entity.Name).ToTable(tableName);
                }
            }
        }

        //protected static void RegisterEntities(ModelBuilder modelBuilder, IEnumerable<Type> typeToRegisters)
        //{
        //    var entityTypes = typeToRegisters.Where(x => x.GetTypeInfo().IsSubclassOf(typeof(ISEntity)) && !x.GetTypeInfo().IsAbstract);
        //    foreach (var type in entityTypes)
        //    {
        //        modelBuilder.Entity(type);
        //    }
        //}

        protected static void RegisterCustomMappings(ModelBuilder modelBuilder, IEnumerable<Type> typeToRegisters)
        {
            var customModelBuilderTypes = typeToRegisters.Where(x => typeof(ICustomModelBuilder).IsAssignableFrom(x));
            foreach (var builderType in customModelBuilderTypes)
            {
                if (builderType != null && builderType != typeof(ICustomModelBuilder))
                {
                    var builder = (ICustomModelBuilder)Activator.CreateInstance(builderType);
                    builder.Build(modelBuilder);
                }
            }
        }

      

        public IDbDataParameter CreateInParameter(string name, DbType type)
        {
            return CreateParameter(name, type, ParameterDirection.Input, null);
        }

        public IDbDataParameter CreateInParameter(string name, DbType type, object value)
        {
            return CreateParameter(name, type, ParameterDirection.Input, value);
        }

        public IDbDataParameter CreateInParameter(string name, DbType type, object value, int size)
        {
            IDbDataParameter param = CreateParameter(name, type, ParameterDirection.Input, value);
            param.Size = size;
            return param;
        }

        public IDbDataParameter CreateOutParameter(string name, DbType type)
        {
            return CreateParameter(name, type, ParameterDirection.Output, DBNull.Value);
        }

        public IDbDataParameter CreateOutParameter(String name, DbType type, int size)
        {
            IDbDataParameter param = CreateParameter(name, type, ParameterDirection.Output, DBNull.Value);
            param.Size = size;
            return param;
        }

        private IDbDataParameter CreateParameter(string name, DbType type, ParameterDirection direction, Object value)
        {
            SqlParameter param2 = new SqlParameter();
            if (type == DbType.Object)
            {
                param2.SqlDbType = SqlDbType.Structured;
            }
            else if (type == DbType.Double)
            {
                param2.SqlDbType = SqlDbType.Float;
            }
            IDbDataParameter param = param2;
            param.ParameterName = "@" + name;
            param.DbType = type;
            param.Value = value ?? DBNull.Value;
            param.Direction = direction;
            return param;
        }
      
        public ISDbValue<T> CallToValue<T>(string name)
        {
            ISDbValue<T> result = new ISDbValue<T>();
            var sqlConnection = new SqlConnection(_connectionString);
            var command = new SqlCommand();
            try
            {               
                command.CommandText = name;
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = sqlConnection;
                sqlConnection.Open();
                result.Value = (T)command.ExecuteScalar();
                result.ErrorCode = 0;
                result.Output = new Dictionary<string, object>();
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            finally
            {
                command.Dispose();
                sqlConnection.Close();
            }
            return result;
        }

        public ISDbValue CallToValue(string name)
        {
            ISDbValue result = new ISDbValue();
            var sqlConnection = new SqlConnection(_connectionString);
            var command = new SqlCommand();
            try
            {               
                command.CommandText = name;
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = sqlConnection;
                sqlConnection.Open();
                result.Value = command.ExecuteScalar();
                result.ErrorCode = 0;
                result.Output = new Dictionary<string, object>();
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            finally
            {
                command.Dispose();
                sqlConnection.Close();
            }
            return result;
        }

        public ISDbObject<T> CallToFirstOrDefault<T>(string name) where T : new()
        {
            ISDbObject<T> result = new ISDbObject<T>();
            var command = new SqlCommand();
            var sqlConnection = new SqlConnection(_connectionString);
            try
            {
                command.CommandText = name;
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = sqlConnection;
                sqlConnection.Open();
                using (var rd = command.ExecuteReader())
                {
                    result.Value = rd.MapToFirstOrDefault<T>();
                }
                result.ErrorCode = 0;
                result.Output = new Dictionary<string, object>();
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            finally
            {
                command.Dispose();
                sqlConnection.Close();
            }
            return result;
        }

        public ISDbList<T> CallToList<T>(string name, List<IDbDataParameter> parameters) where T : new()
        {
            ISDbList<T> result = new ISDbList<T>();
            var sqlConnection = new SqlConnection(_connectionString);
            var command = new SqlCommand();
            try
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = sqlConnection;

                if (parameters != null && parameters.Count > 0)
                {
                    command.Parameters.AddRange(parameters.ToArray());
                }
                command.CommandText = name;
                command.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                using (var rd = command.ExecuteReader())
                {
                    result.Value = rd.MapToList<T>();
                }              
                result.Output = new Dictionary<string, object>();
                foreach (var parameter in parameters)
                {
                    if (parameter.Direction == ParameterDirection.Output || parameter.Direction == ParameterDirection.InputOutput)
                    {
                        string parameterName = parameter.ParameterName.Replace("@", "");
                        if (parameterName == "OUT_ERR_CD")
                            result.ErrorCode = (int)parameter.Value;
                        else if (parameterName == "OUT_ERR_MSG")
                            result.ErrorMessage = parameter.Value.ToString();
                        else
                            result.Output.Add(parameter.ParameterName.Replace("@", ""), parameter.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            finally
            {
                command.Dispose();
                sqlConnection.Close();
            }
            return result;
        }

        public ISDbDynamic CallToMultipleList(string name, List<IDbDataParameter> parameters)
        {
            ISDbDynamic result = new ISDbDynamic();
            var sqlConnection = new SqlConnection(_connectionString);
            var command = new SqlCommand();
            try
            {
                var tables = new List<List<Dictionary<string, object>>>();
                command.CommandText = name;
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = sqlConnection;
                if (parameters != null && parameters.Any())
                {
                    command.Parameters.AddRange(parameters.ToArray());
                }          
                sqlConnection.Open();
                using (var rd = command.ExecuteReader())
                {
                    do
                    {
                        var table = new List<Dictionary<string, object>>();
                        while (rd.Read())
                            table.Add(Read(rd));
                        tables.Add(table);
                    } while (rd.NextResult());

                    result.Value = tables;
                }
                result.Output = new Dictionary<string, object>();
                foreach (var parameter in parameters)
                {
                    if (parameter.Direction == ParameterDirection.Output || parameter.Direction == ParameterDirection.InputOutput)
                    {
                        string parameterName = parameter.ParameterName.Replace("@", "");
                        if (parameterName == "OUT_ERR_CD")
                            result.ErrorCode = (int)parameter.Value;
                        else if (parameterName == "OUT_ERR_MSG")
                            result.ErrorMessage = parameter.Value.ToString();
                        else
                            result.Output.Add(parameter.ParameterName.Replace("@", ""), parameter.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            finally
            {
                command.Dispose();
                sqlConnection.Close();
            }
            return result;
        }

        private Dictionary<string, object> Read(IDataRecord reader)
        {
            var row = new Dictionary<string, object>();
            for (var i = 0; i < reader.FieldCount; i++)
            {
                var val = reader[i];
                row[reader.GetName(i)] = val == DBNull.Value ? null : val;
            }
            return row;
        }
        public ISDbValue<T> CallToValue<T>(string name, List<IDbDataParameter> parameters)
        {
            ISDbValue<T> result = new ISDbValue<T>();
            var sqlConnection = new SqlConnection(_connectionString);
            var command = new SqlCommand();
            try
            {
                command.CommandText = name;
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = sqlConnection;
                if (parameters != null && parameters.Any())
                {
                    command.Parameters.AddRange(parameters.ToArray());
                }
                sqlConnection.Open();
                result.Value = (T)command.ExecuteScalar();

                result.Output = new Dictionary<string, object>();
                foreach (var parameter in parameters)
                {
                    if (parameter.Direction == ParameterDirection.Output || parameter.Direction == ParameterDirection.InputOutput)
                    {
                        string parameterName = parameter.ParameterName.Replace("@", "");
                        if (parameterName == "OUT_ERR_CD")
                            result.ErrorCode = (int)parameter.Value;
                        else if (parameterName == "OUT_ERR_MSG")
                            result.ErrorMessage = parameter.Value.ToString();
                        else
                            result.Output.Add(parameter.ParameterName.Replace("@", ""), parameter.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            finally
            {
                command.Dispose();
                sqlConnection.Close();
            }
            return result;
        }


        public ISDbValue CallToValue(string name, List<IDbDataParameter> parameters)
        {
            ISDbValue result = new ISDbValue();
            var sqlConnection = new SqlConnection(_connectionString);
            var command = new SqlCommand();
            try
            {
                command.CommandText = name;
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = sqlConnection;
                if (parameters != null && parameters.Any())
                {
                    command.Parameters.AddRange(parameters.ToArray());
                }

                sqlConnection.Open();
                result.Value = command.ExecuteScalar();
                result.Output = new Dictionary<string, object>();
                foreach (var parameter in parameters)
                {
                    if (parameter.Direction == ParameterDirection.Output || parameter.Direction == ParameterDirection.InputOutput)
                    {
                        string parameterName = parameter.ParameterName.Replace("@", "");
                        if (parameterName == "OUT_ERR_CD")
                            result.ErrorCode = (int)parameter.Value;
                        else if (parameterName == "OUT_ERR_MSG")
                            result.ErrorMessage = parameter.Value.ToString();
                        else
                            result.Output.Add(parameter.ParameterName.Replace("@", ""), parameter.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            finally
            {
                command.Dispose();
                sqlConnection.Close();
            }
            return result;
        }


        public ISDbObject<T> CallToFirstOrDefault<T>(string name, List<IDbDataParameter> parameters) where T : new()
        {
            ISDbObject<T> result = new ISDbObject<T>();
            var sqlConnection = new SqlConnection(_connectionString);
            var command = new SqlCommand();
            try
            {
                command.CommandText = name;
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = sqlConnection;
                if (parameters != null && parameters.Any())
                {
                    command.Parameters.AddRange(parameters.ToArray());
                }
                sqlConnection.Open();
                using (var rd = command.ExecuteReader())
                {
                    result.Value = rd.MapToFirstOrDefault<T>();
                }
                result.Output = new Dictionary<string, object>();
                foreach (var parameter in parameters)
                {
                    if (parameter.Direction == ParameterDirection.Output || parameter.Direction == ParameterDirection.InputOutput)
                    {
                        string parameterName = parameter.ParameterName.Replace("@", "");
                        if (parameterName == "OUT_ERR_CD")
                            result.ErrorCode = (int)parameter.Value;
                        else if (parameterName == "OUT_ERR_MSG")
                            result.ErrorMessage = parameter.Value.ToString();
                        else
                            result.Output.Add(parameterName.Replace("@", ""), parameter.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            finally
            {
                command.Dispose();
                sqlConnection.Close();
            }
            return result;
        }
    }
}