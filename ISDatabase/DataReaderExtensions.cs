using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;

namespace KSHYDatabase
{
    public static class DataReaderExtentions
    {
		public static List<TData> MapToList<TData>(this DbDataReader dr) where TData : new()
		{
			if (dr != null && dr.HasRows)
			{
				var entity = typeof(TData);
				var entities = new List<TData>();
				var propDict = new Dictionary<string, PropertyInfo>();
				var props = entity.GetProperties();
				propDict = props.ToDictionary(p => p.Name.ToUpper(), p => p);
				while (dr.Read())
				{
					var newObj = new TData();
					for (int i = 0; i < dr.FieldCount; i++)
					{
						if (propDict.ContainsKey(dr.GetName(i).ToUpper()))
						{
							var info = propDict[dr.GetName(i).ToUpper()];
							if (info != null && info.CanWrite)
							{
								var val = dr.GetValue(i);
								info.SetValue(newObj, (val == DBNull.Value) ? null : val, null);
							}
						}
					}
					entities.Add(newObj);
				}
				return entities;
			}
			return new List<TData>();
		}

        public static TData MapToFirstOrDefault<TData>(this DbDataReader dr) where TData : new()
        {
            TData result = default(TData);
            if (dr != null && dr.HasRows)
            {
                var entity = typeof(TData);
                var propDict = new Dictionary<string, PropertyInfo>();
                var props = entity.GetProperties();
                propDict = props.ToDictionary(p => p.Name.ToUpper(), p => p);
                if (dr.Read())
                {
                    var newObj = new TData();
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        if (propDict.ContainsKey(dr.GetName(i).ToUpper()))
                        {
                            var info = propDict[dr.GetName(i).ToUpper()];
                            if (info != null && info.CanWrite)
                            {
                                var val = dr.GetValue(i);
                                info.SetValue(newObj, (val == DBNull.Value) ? null : val, null);
                            }
                        }
                    }
                    result = newObj;
                }
            }
            return result;
        }
    }
}
