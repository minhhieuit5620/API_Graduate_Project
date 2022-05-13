using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;

namespace KSHYDatabase
{
    public interface IDbContext
    {
        //DbSet<TEntity> Set<TEntity>() where TEntity : ISEntity;
        IDbDataParameter CreateInParameter(string name, DbType type);
        IDbDataParameter CreateInParameter(string name, DbType type, object value);
        IDbDataParameter CreateInParameter(string name, DbType type, object value, int size);
        IDbDataParameter CreateOutParameter(string name, DbType type);
        IDbDataParameter CreateOutParameter(String name, DbType type, int size);
        ISDbList<T> CallToList<T>(string name) where T : new();
        ISDbValue<T> CallToValue<T>(string name);
        ISDbObject<T> CallToFirstOrDefault<T>(string name) where T : new();
        ISDbList<T> CallToList<T>(string name, List<IDbDataParameter> parameters) where T : new();
        ISDbValue<T> CallToValue<T>(string name, List<IDbDataParameter> parameters);
        ISDbObject<T> CallToFirstOrDefault<T>(string name, List<IDbDataParameter> parameters) where T : new();
    }
}
