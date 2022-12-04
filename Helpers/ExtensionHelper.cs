
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using TTTN.Models;

namespace TTTN.Helpers
{
    public static class ExtensionHelper
    {

        public static List<int> ToListInt(this string String)
        {
            if (string.IsNullOrEmpty(String)) return new List<int>();
            return String.Split(',')?.Select(Int32.Parse)?.ToList();
        }

        public static bool IsGreaterThan(double v1, double v2)
        {
            return (v1 > v2);
        }

        public static bool IsLowerThan(double v1, double v2)
        {
            return (v1 < v2);
        }

        public static bool IsEquals(double v1, double v2)
        {
            return v1 == v2;
        }

        public static bool CompareWithType(this double v1, double v2, int compareType)
        {
            switch (compareType)
            {
                case 1:
                    return IsLowerThan(v1, v2);
                case 2:
                    return IsEquals(v1, v2);
                case 3:
                    return IsGreaterThan(v1, v2);
                default: 
                    return false;
            }
        }
        public static List<DOCHOI> GetListWithNutris(this List<DOCHOI> list, Search query)
        {
            var cType = query.compareType;

            var listTemp = list.AsQueryable();

            if (query.Protein > 0)
                listTemp = listTemp.Where(x => x.Nutris.Protein.CompareWithType(query.Protein, cType));
            if (query.TotalFat > 0)
                listTemp = listTemp.Where(x => x.Nutris.TotalFat.CompareWithType(query.TotalFat, cType));
            if (query.TotalCarbon > 0)
                listTemp = listTemp.Where(x => x.Nutris.TotalCarbon.CompareWithType(query.TotalCarbon, cType));
            if (query.Calcium > 0)
                listTemp = listTemp.Where(x => x.Nutris.Calcium.CompareWithType(query.Calcium, cType));
            if (query.Sodium > 0)
                listTemp = listTemp.Where(x => x.Nutris.Sodium.CompareWithType(query.Sodium, cType));
            if (query.Magnesium > 0)
                listTemp =   listTemp.Where(x => x.Nutris.Magnesium.CompareWithType(query.Magnesium, cType));
            if (query.Iron > 0)
                listTemp = listTemp.Where(x => x.Nutris.Iron.CompareWithType(query.Iron, cType));
            if (query.Copper > 0)
                listTemp = listTemp.Where(x => x.Nutris.Copper.CompareWithType(query.Copper, cType));
            if (query.Potassium > 0)
                listTemp = listTemp.Where(x => x.Nutris.Potassium.CompareWithType(query.Potassium, cType));
            if (query.VitaminD3 > 0)
                listTemp = listTemp.Where(x => x.Nutris.VitaminD3.CompareWithType(query.VitaminD3, cType));
            if (query.VitaminB1 > 0)
                listTemp = listTemp.Where(x => x.Nutris.VitaminB1.CompareWithType(query.VitaminB1, cType));
            if (query.VitaminB2 > 0)
                listTemp = listTemp.Where(x => x.Nutris.VitaminB2.CompareWithType(query.VitaminB2, cType));
            if (query.Iodine > 0)
                listTemp = listTemp.Where(x => x.Nutris.Iodine.CompareWithType(query.Iodine, cType));
            if (query.Zinc > 0)
                listTemp = listTemp.Where(x => x.Nutris.Zinc.CompareWithType(query.Zinc, cType));


            return list = listTemp.ToList();
        }
        public static bool IsValidList(this List<int> list)
        {
            return list != null && list.Any();
        }

        public static int GetMonthDifference(DateTime startDate, DateTime endDate)
        {
            int monthsApart = 12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month;
            return Math.Abs(monthsApart);
        }

        public static IEnumerable<(string Month, int Year)> MonthsBetween(
        DateTime startDate,
        DateTime endDate)
        {
            DateTime iterator;
            DateTime limit;

            if (endDate > startDate)
            {
                iterator = new DateTime(startDate.Year, startDate.Month, 1);
                limit = endDate;
            }
            else
            {
                iterator = new DateTime(endDate.Year, endDate.Month, 1);
                limit = startDate;
            }

            var dateTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat;
            while (iterator <= limit)
            {
                yield return (
                    dateTimeFormat.GetMonthName(iterator.Month),
                    iterator.Year
                );

                iterator = iterator.AddMonths(1);
            }
        }
        public static string ToVnd(this double giaTri)
        {
            return $"{giaTri:#,##} đ";
        }

        public static string ToVnd(this decimal giaTri)
        {
            return $"{giaTri:#,##} đ";
        }

        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
    }
}
