using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace KSHYWeb.Extensions
{
    public static class ToObjectExtensions
    {
       
        public static T Cast<T>(this Object myobj)
        {
            Type objectType = myobj.GetType();
            Type target = typeof(T);
            var Newobj = Activator.CreateInstance(target, false);         
            var d = from source in target.GetMembers().ToList()
                    where source.MemberType == MemberTypes.Property
                    select source;
            List<MemberInfo> members = d.Where(memberInfo => d.Select(c => c.Name)
               .ToList().Contains(memberInfo.Name)).ToList();
            PropertyInfo propertyInfo;
            object value;
            foreach (var memberInfo in members)
            {
                propertyInfo = target.GetProperty(memberInfo.Name);
                value = objectType.GetProperty(memberInfo.Name).GetValue(myobj, null);
                propertyInfo.SetValue(Newobj, (value == DBNull.Value) ? null : value, null);
            }
            return (T)Newobj;
        }
        public static IList<T> Cast<T>(this IList<Object> myobj)
        {
            var lst = new List<T>();
            if (myobj!=null && myobj.Any())
            {
                Type target = typeof(T);
                var d = from source in target.GetMembers().ToList()
                        where source.MemberType == MemberTypes.Property
                        select source;
                List<MemberInfo> members = d.Where(memberInfo => d.Select(c => c.Name)
                   .ToList().Contains(memberInfo.Name)).ToList();
                foreach (var item in myobj)
                {
                    Type objectType = item.GetType();                   
                    var Newobj = Activator.CreateInstance(target, false);                               
                    PropertyInfo propertyInfo;
                    object value;
                    foreach (var memberInfo in members)
                    {
                        propertyInfo = target.GetProperty(memberInfo.Name);
                        value = objectType.GetProperty(memberInfo.Name).GetValue(item, null);
                        propertyInfo.SetValue(Newobj, (value == DBNull.Value) ? null : value, null);
                    }
                    lst.Add((T)Newobj);
                }
            }
            
            return lst;
        }
    }
}
