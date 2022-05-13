using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace KSHYDatabase
{
    public class ISDbDynamic
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public List<List<Dictionary<string, object>>> Value { get; set; }
        public Dictionary<string, object> Output { get; set; }

        public List<TData> MapToList<TData>(int index) where TData : new()
        {
            try { 
            
                var entities = new List<TData>();
                if (Value[index].Count > 0)
                {
                    var entity = typeof(TData);
                    var propDict = new Dictionary<string, PropertyInfo>();
                    var props = entity.GetProperties();
                    propDict = props.ToDictionary(p => p.Name.ToUpper(), p => p);
                    List<Dictionary<string, object>> items = Value[index];
                    foreach (var item in items)
                    {
                        var newObj = new TData();
                        foreach (string key in item.Keys)
                        {
                            if (propDict.ContainsKey(key.ToUpper()))
                            {
                                var info = propDict[key.ToUpper()];
                                if (info != null && info.CanWrite)
                                {
                                    var val = item[key];
                                    info.SetValue(newObj, (val == DBNull.Value) ? null : val, null);
                                }
                            }
                        }
                        entities.Add(newObj);
                    }
                }
                return entities;
            }
            catch (Exception ex){ 
            
            }
            return new List<TData>();
        }

        public TData MapToFirstOrDefault<TData>(int index) where TData : new()
        {
            TData result = default(TData);
            try
            {
                if (Value[index].Count > 0)
                {
                    var entity = typeof(TData);
                    var propDict = new Dictionary<string, PropertyInfo>();
                    var props = entity.GetProperties();
                    propDict = props.ToDictionary(p => p.Name.ToUpper(), p => p);
                    Dictionary<string, object> item = Value[index][0];
                    if (item != null && item.Count > 0)
                    {
                        var newObj = new TData();
                        foreach (string key in item.Keys)
                        {
                            if (propDict.ContainsKey(key.ToUpper()))
                            {
                                var info = propDict[key.ToUpper()];
                                if (info != null && info.CanWrite)
                                {
                                    var val = item[key];
                                    info.SetValue(newObj, (val == DBNull.Value) ? null : val, null);
                                }
                            }
                        }
                        result = newObj;
                    }
                }
            }
            catch(Exception ex) {
                throw ex;
            }
            return result;
        }
    }
}
