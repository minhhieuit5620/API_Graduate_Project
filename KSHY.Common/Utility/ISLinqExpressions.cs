using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using ISCommon.Model;
using System.Linq.Dynamic;
using static ISCommon.Constant.Constant;

namespace ISCommon.Utility
{

    public static class LinqExpressions
    {
        public static IEnumerable<T> ApplyFilter<T>(this IEnumerable<T> dataSource, IList<FillterModel> filters)
        {
            string strquery = "";
            var i = 0;
            var lstValue = new List<object>();
            var parameter = Expression.Parameter(typeof(T), "x");
            foreach (var item in filters)
            {
                var member = Expression.Property(parameter, typeof(T).GetProperty(item.field));
                switch (item._operator)
                {
                    case Operation.EqualTo:
                        if (member.Type == typeof(string))
                            strquery += (i > 0 ? (item.logic == Logic.And ? " && " : " || ") : " ") + String.Format("{0}.ToLower().Equals(@" + i + ")", item.field);
                        else if (member.Type == typeof(double) || member.Type == typeof(decimal) || member.Type == typeof(int) || member.Type == typeof(float) || member.Type == typeof(Boolean))
                            strquery += (i > 0 ? (item.logic == Logic.And ? " && " : " || ") : " ") + String.Format("{0}==@" + i, item.field);
                        i += 1;
                        break;
                    case Operation.NotEqualTo:
                        if (member.Type == typeof(string))
                            strquery += (i > 0 ? (item.logic == Logic.And ? " && " : " || ") : " ") + String.Format("!{0}.ToLower().Equals(@" + i + ")", item.field);
                        else if (member.Type == typeof(double) || member.Type == typeof(decimal) || member.Type == typeof(int) || member.Type == typeof(float) || member.Type == typeof(Boolean))
                            strquery += (i > 0 ? (item.logic == Logic.And ? " && " : " || ") : " ") + String.Format("{0}==@" + i, item.field);
                        i += 1;
                        break;
                    case Operation.GreaterThanOrEqualTo:
                        strquery += (i > 0 ? (item.logic == Logic.And ? " && " : " || ") : " ") + String.Format("{0}>=@" + i, item.field);
                        i += 1;
                        break;
                    case Operation.GreaterThan:
                        strquery += (i > 0 ? (item.logic == Logic.And ? " && " : " || ") : " ") + String.Format("{0}>@" + i, item.field);
                        i += 1;
                        break;
                    case Operation.LessThan:
                        strquery += (i > 0 ? (item.logic == Logic.And ? " && " : " || ") : " ") + String.Format("{0}<@" + i, item.field);
                        i += 1;
                        break;
                    case Operation.LessThanOrEqualTo:
                        strquery += (i > 0 ? (item.logic == Logic.And ? " && " : " || ") : " ") + String.Format("{0}<=@" + i, item.field);
                        i += 1;
                        break;
                    case Operation.EndsWith:
                        if (member.Type == typeof(string))
                            strquery += (i > 0 ? (item.logic == Logic.And ? " && " : " || ") : " ") + String.Format("{0}.ToLower().EndsWith(@" + i + ")", item.field);
                        else if (member.Type == typeof(double) || member.Type == typeof(decimal) || member.Type == typeof(int) || member.Type == typeof(float) || member.Type == typeof(Boolean))
                            strquery += (i > 0 ? (item.logic == Logic.And ? " && " : " || ") : " ") + String.Format("{0}==@" + i, item.field);
                        i += 1;
                        break;
                    case Operation.StartsWith:
                        if (member.Type == typeof(string))
                            strquery += (i > 0 ? (item.logic == Logic.And ? " && " : " || ") : " ") + String.Format("!{0}.ToLower().StartsWith(@" + i + ")", item.field);
                        else if (member.Type == typeof(double) || member.Type == typeof(decimal) || member.Type == typeof(int) || member.Type == typeof(float) || member.Type == typeof(Boolean))
                            strquery += (i > 0 ? (item.logic == Logic.And ? " && " : " || ") : " ") + String.Format("{0}==@" + i, item.field);
                        i += 1;
                        break;
                    case Operation.Contains:
                        if (member.Type == typeof(string))
                            strquery += (i > 0 ? (item.logic == Logic.And ? " && " : " || ") : " ") + String.Format("{0}.ToLower().Contains(@" + i + ")", item.field);
                        else if (member.Type == typeof(double) || member.Type == typeof(decimal) || member.Type == typeof(int) || member.Type == typeof(float) || member.Type == typeof(Boolean))
                            strquery += (i > 0 ? (item.logic == Logic.And ? " && " : " || ") : " ") + String.Format("{0}==@" + i, item.field);
                        i += 1;
                        break;
                    case Operation.NotContains:
                        if (member.Type == typeof(string))
                            strquery += (i > 0 ? (item.logic == Logic.And ? " && " : " || ") : " ") + String.Format("!{0}.ToLower().Contains(@" + i + ")", item.field);
                        else if (member.Type == typeof(double) || member.Type == typeof(decimal) || member.Type == typeof(int) || member.Type == typeof(float) || member.Type == typeof(Boolean))
                            strquery += (i > 0 ? (item.logic == Logic.And ? " && " : " || ") : " ") + String.Format("{0}==@" + i, item.field);
                        i += 1;
                        break;
                    default:
                        strquery += (i > 0 ? (item.logic == Logic.And ? " && " : " || ") : " ") + String.Format("{0}==@" + i, item.field);
                        break;
                }

                if (member.Type == typeof(string))
                {
                    lstValue.Add(item.value.ToString().ToLower());
                }
                else
                {
                    if (member.Type == typeof(double))
                        lstValue.Add(Convert.ToDouble(item.value));
                    else if (member.Type == typeof(decimal) || member.Type == typeof(float))
                        lstValue.Add(Convert.ToDecimal(item.value));
                    else if (member.Type == typeof(int) || member.Type == typeof(short))
                        lstValue.Add(Convert.ToInt32(item.value));
                    else if (member.Type == typeof(DateTime))
                        lstValue.Add(DateTime.ParseExact(item.value.ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
                    else
                        lstValue.Add((bool)item.value);
                }
            }
            try
            {
                if (!string.IsNullOrEmpty(strquery))
                    dataSource = dataSource.Where(strquery, lstValue.ToArray());
            }
            catch
            {
                return dataSource;
            }
            return dataSource;
        }
        public static IQueryable<T> ApplyFilter<T>(this IQueryable<T> dataSource, IList<FillterModel> filters)
        {
            string strquery = "";
            var i = 0;
            var lstValue = new List<object>();
            var parameter = Expression.Parameter(typeof(T), "x");
            foreach (var item in filters)
            {
                var member = Expression.Property(parameter, typeof(T).GetProperty(item.field));
                switch (item._operator)
                {
                    case Operation.EqualTo:
                        if (member.Type == typeof(string))
                            strquery += (i > 0 ? (item.logic == Logic.And ? " && " : " || ") : " ") + String.Format("{0}.ToLower().Equals(@" + i + ")", item.field);
                        else if (member.Type == typeof(double) || member.Type == typeof(decimal) || member.Type == typeof(int) || member.Type == typeof(float) || member.Type == typeof(Boolean))
                            strquery += (i > 0 ? (item.logic == Logic.And ? " && " : " || ") : " ") + String.Format("{0}==@" + i, item.field);
                        i += 1;
                        break;
                    case Operation.NotEqualTo:
                        if (member.Type == typeof(string))
                            strquery += (i > 0 ? (item.logic == Logic.And ? " && " : " || ") : " ") + String.Format("!{0}.ToLower().Equals(@" + i + ")", item.field);
                        else if (member.Type == typeof(double) || member.Type == typeof(decimal) || member.Type == typeof(int) || member.Type == typeof(float) || member.Type == typeof(Boolean))
                            strquery += (i > 0 ? (item.logic == Logic.And ? " && " : " || ") : " ") + String.Format("{0}==@" + i, item.field);
                        i += 1;
                        break;
                    case Operation.GreaterThanOrEqualTo:
                        strquery += (i > 0 ? (item.logic == Logic.And ? " && " : " || ") : " ") + String.Format("{0}>=@" + i, item.field);
                        i += 1;
                        break;
                    case Operation.GreaterThan:
                        strquery += (i > 0 ? (item.logic == Logic.And ? " && " : " || ") : " ") + String.Format("{0}>@" + i, item.field);
                        i += 1;
                        break;
                    case Operation.LessThan:
                        strquery += (i > 0 ? (item.logic == Logic.And ? " && " : " || ") : " ") + String.Format("{0}<@" + i, item.field);
                        i += 1;
                        break;
                    case Operation.LessThanOrEqualTo:
                        strquery += (i > 0 ? (item.logic == Logic.And ? " && " : " || ") : " ") + String.Format("{0}<=@" + i, item.field);
                        i += 1;
                        break;
                    case Operation.EndsWith:
                        if (member.Type == typeof(string))
                            strquery += (i > 0 ? (item.logic == Logic.And ? " && " : " || ") : " ") + String.Format("{0}.ToLower().EndsWith(@" + i + ")", item.field);
                        else if (member.Type == typeof(double) || member.Type == typeof(decimal) || member.Type == typeof(int) || member.Type == typeof(float) || member.Type == typeof(Boolean))
                            strquery += (i > 0 ? (item.logic == Logic.And ? " && " : " || ") : " ") + String.Format("{0}==@" + i, item.field);
                        i += 1;
                        break;
                    case Operation.StartsWith:
                        if (member.Type == typeof(string))
                            strquery += (i > 0 ? (item.logic == Logic.And ? " && " : " || ") : " ") + String.Format("!{0}.ToLower().StartsWith(@" + i + ")", item.field);
                        else if (member.Type == typeof(double) || member.Type == typeof(decimal) || member.Type == typeof(int) || member.Type == typeof(float) || member.Type == typeof(Boolean))
                            strquery += (i > 0 ? (item.logic == Logic.And ? " && " : " || ") : " ") + String.Format("{0}==@" + i, item.field);
                        i += 1;
                        break;
                    case Operation.Contains:
                        if (member.Type == typeof(string))
                            strquery += (i > 0 ? (item.logic == Logic.And ? " && " : " || ") : " ") + String.Format("{0}.ToLower().Contains(@" + i + ")", item.field);
                        else if (member.Type == typeof(double) || member.Type == typeof(decimal) || member.Type == typeof(int) || member.Type == typeof(float) || member.Type == typeof(Boolean))
                            strquery += (i > 0 ? (item.logic == Logic.And ? " && " : " || ") : " ") + String.Format("{0}==@" + i, item.field);
                        i += 1;
                        break;
                    case Operation.NotContains:
                        if (member.Type == typeof(string))
                            strquery += (i > 0 ? (item.logic == Logic.And ? " && " : " || ") : " ") + String.Format("!{0}.ToLower().Contains(@" + i + ")", item.field);
                        else if (member.Type == typeof(double) || member.Type == typeof(decimal) || member.Type == typeof(int) || member.Type == typeof(float) || member.Type == typeof(Boolean))
                            strquery += (i > 0 ? (item.logic == Logic.And ? " && " : " || ") : " ") + String.Format("{0}==@" + i, item.field);
                        i += 1;
                        break;
                    default:
                        strquery += (i > 0 ? (item.logic == Logic.And ? " && " : " || ") : " ") + String.Format("{0}==@" + i, item.field);
                        break;
                }

                if (member.Type == typeof(string))
                {
                    lstValue.Add(item.value.ToString().ToLower());
                }
                else
                {
                    if (member.Type == typeof(double))
                        lstValue.Add(Convert.ToDouble(item.value));
                    else if (member.Type == typeof(decimal) || member.Type == typeof(float))
                        lstValue.Add(Convert.ToDecimal(item.value));
                    else if (member.Type == typeof(int) || member.Type == typeof(short))
                        lstValue.Add(Convert.ToInt32(item.value));
                    else if (member.Type == typeof(DateTime))
                        lstValue.Add(DateTime.ParseExact(item.value.ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
                    else
                        lstValue.Add((bool)item.value);
                }
            }
            try
            {
                if (!string.IsNullOrEmpty(strquery))
                    dataSource = dataSource.Where(strquery, lstValue.ToArray());
            }
            catch
            {
                return dataSource;
            }
            return dataSource;
        }

        public static string ConvertFilterToString<T>(IList<FillterModel> filters)
        {
            string strquery = "";
            var i = 0;
            var parameter = Expression.Parameter(typeof(T), "x");
            foreach (var item in filters)
            {
                var member = Expression.Property(parameter, typeof(T).GetProperty(item.field));
                switch (item._operator)
                {
                    case Operation.EqualTo:
                        if (member.Type == typeof(string))
                            strquery += (i > 0 ? (item.logic == Logic.And ? " AND " : " OR ") : " ") + String.Format("{0} = N'" + item.value.ToString().ToLower() + "'", item.field);
                        else if (member.Type == typeof(double) || member.Type == typeof(decimal) || member.Type == typeof(int) || member.Type == typeof(float) || member.Type == typeof(Boolean))
                            strquery += (i > 0 ? (item.logic == Logic.And ? " AND " : " OR ") : " ") + String.Format("{0} = " + item.value, item.field);
                        else if (member.Type == typeof(DateTime))
                            strquery += (i > 0 ? (item.logic == Logic.And ? " AND " : " OR ") : " ") + String.Format("{0} = " + DateTime.ParseExact(item.value.ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture), item.field);
                        i += 1;
                        break;
                    case Operation.NotEqualTo:
                        if (member.Type == typeof(string))
                            strquery += (i > 0 ? (item.logic == Logic.And ? " AND " : " OR ") : " ") + String.Format("{0} != N'" + item.value.ToString().ToLower() + "'", item.field);
                        else if (member.Type == typeof(double) || member.Type == typeof(decimal) || member.Type == typeof(int) || member.Type == typeof(float) || member.Type == typeof(Boolean))
                            strquery += (i > 0 ? (item.logic == Logic.And ? " AND " : " OR ") : " ") + String.Format("{0} != " + item.value, item.field);
                        else if (member.Type == typeof(DateTime))
                            strquery += (i > 0 ? (item.logic == Logic.And ? " AND " : " OR ") : " ") + String.Format("{0} != " + DateTime.ParseExact(item.value.ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture), item.field);
                        i += 1;
                        break;
                    case Operation.GreaterThanOrEqualTo:
                        if (member.Type == typeof(DateTime))
                            strquery += (i > 0 ? (item.logic == Logic.And ? " AND " : " OR ") : " ") + String.Format("{0} >= " + DateTime.ParseExact(item.value.ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture), item.field);
                        else
                            strquery += (i > 0 ? (item.logic == Logic.And ? " AND " : " OR ") : " ") + String.Format("{0} >= " + item.value, item.field);
                        i += 1;
                        break;
                    case Operation.GreaterThan:
                        if (member.Type == typeof(DateTime))
                            strquery += (i > 0 ? (item.logic == Logic.And ? " AND " : " OR ") : " ") + String.Format("{0} > " + DateTime.ParseExact(item.value.ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture), item.field);
                        else
                            strquery += (i > 0 ? (item.logic == Logic.And ? " AND " : " OR ") : " ") + String.Format("{0} > " + item.value, item.field);
                        i += 1;
                        break;
                    case Operation.LessThan:
                        if (member.Type == typeof(DateTime))
                            strquery += (i > 0 ? (item.logic == Logic.And ? " AND " : " OR ") : " ") + String.Format("{0} < " + DateTime.ParseExact(item.value.ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture), item.field);
                        else
                            strquery += (i > 0 ? (item.logic == Logic.And ? " AND " : " OR ") : " ") + String.Format("{0} < " + item.value, item.field);
                        i += 1;
                        break;
                    case Operation.LessThanOrEqualTo:
                        if (member.Type == typeof(DateTime))
                            strquery += (i > 0 ? (item.logic == Logic.And ? " AND " : " OR ") : " ") + String.Format("{0} <= " + DateTime.ParseExact(item.value.ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture), item.field);
                        else
                            strquery += (i > 0 ? (item.logic == Logic.And ? " AND " : " OR ") : " ") + String.Format("{0} <= " + item.value, item.field);
                        i += 1;
                        break;
                    case Operation.EndsWith:
                        if (member.Type == typeof(string))
                            strquery += (i > 0 ? (item.logic == Logic.And ? " AND " : " OR ") : " ") + String.Format("{0} like N'" + item.value.ToString().ToLower() + "%'", item.field);
                        else if (member.Type == typeof(double) || member.Type == typeof(decimal) || member.Type == typeof(int) || member.Type == typeof(float) || member.Type == typeof(Boolean))
                            strquery += (i > 0 ? (item.logic == Logic.And ? " AND " : " OR ") : " ") + String.Format("{0} = " + item.value, item.field);
                        i += 1;
                        break;
                    case Operation.StartsWith:
                        if (member.Type == typeof(string))
                            strquery += (i > 0 ? (item.logic == Logic.And ? " AND " : " OR ") : " ") + String.Format("{0} like N'%" + item.value.ToString().ToLower() + "'", item.field);
                        else if (member.Type == typeof(double) || member.Type == typeof(decimal) || member.Type == typeof(int) || member.Type == typeof(float) || member.Type == typeof(Boolean))
                            strquery += (i > 0 ? (item.logic == Logic.And ? " OR " : " OR ") : " ") + String.Format("{0} = " + item.value, item.field);
                        i += 1;
                        break;
                    case Operation.Contains:
                        if (member.Type == typeof(string))
                            strquery += (i > 0 ? (item.logic == Logic.And ? " AND " : " OR ") : " ") + String.Format("{0} like N'%" + item.value.ToString().ToLower() + "%'", item.field);
                        else if (member.Type == typeof(double) || member.Type == typeof(decimal) || member.Type == typeof(int) || member.Type == typeof(float) || member.Type == typeof(Boolean))
                            strquery += (i > 0 ? (item.logic == Logic.And ? " AND " : " OR ") : " ") + String.Format("{0} = " + item.value, item.field);
                        i += 1;
                        break;
                    case Operation.NotContains:
                        if (member.Type == typeof(string))
                            strquery += (i > 0 ? (item.logic == Logic.And ? " AND " : " OR ") : " ") + String.Format("{0} not like N'%" + item.value.ToString().ToLower() + "%'", item.field);
                        else if (member.Type == typeof(double) || member.Type == typeof(decimal) || member.Type == typeof(int) || member.Type == typeof(float) || member.Type == typeof(Boolean))
                            strquery += (i > 0 ? (item.logic == Logic.And ? " AND " : " OR ") : " ") + String.Format("{0} != " + item.value, item.field);
                        i += 1;
                        break;
                    default:
                        strquery += (i > 0 ? (item.logic == Logic.And ? " AND " : " OR ") : " ") + String.Format("{0} = " + item.value, item.field);
                        break;
                }
            }
            return strquery;
        }
    }
}
