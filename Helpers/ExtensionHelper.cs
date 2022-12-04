
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

        public static bool IsGreaterThan(float v1, float v2)
        {
            return (v1 > v2);
        }

        public static bool IsLowerThan(float v1, float v2)
        {
            return (v1 < v2);
        }

        public static bool IsEquals(float v1, float v2)
        {
            return v1 == v2;
        }

        public static bool CompareWithType(this float v1, float v2, int compareType)
        {
            switch (compareType)
            {
                case 1:
                    IsLowerThan(v1, v2);
                    break;
                case 2:
                    IsEquals(v1, v2);
                    break;
                case 3:
                    IsGreaterThan(v1, v2);
                    break;
            }
            return false;
        }
        public static List<DOCHOI> GetListWithNutris(this List<DOCHOI> list, Search query)
        {
            var cType = query.Nutris.compareType;

            var listTemp = list.AsQueryable();

            if (query.Nutris.Protein > -1)
                listTemp = listTemp.Where(x => x.Nutris.Protein.CompareWithType(query.Nutris.Protein, cType));
            if (query.Nutris.TotalFat > -1)
                listTemp = listTemp.Where(x => x.Nutris.TotalFat.CompareWithType(query.Nutris.TotalFat, cType));
            if (query.Nutris.TotalCarbon > -1)
                listTemp = listTemp.Where(x => x.Nutris.TotalCarbon.CompareWithType(query.Nutris.TotalCarbon, cType));
            if (query.Nutris.Calcium > -1)
                listTemp = listTemp.Where(x => x.Nutris.Calcium.CompareWithType(query.Nutris.Calcium, cType));
            if (query.Nutris.Sodium > -1)
                listTemp = listTemp.Where(x => x.Nutris.Sodium.CompareWithType(query.Nutris.Sodium, cType));
            if (query.Nutris.Magnesium > -1)
                listTemp = listTemp.Where(x => x.Nutris.Magnesium.CompareWithType(query.Nutris.Magnesium, cType));
            if (query.Nutris.Iron > -1)
                listTemp = listTemp.Where(x => x.Nutris.Iron.CompareWithType(query.Nutris.Iron, cType));
            if (query.Nutris.Copper > -1)
                listTemp = listTemp.Where(x => x.Nutris.Copper.CompareWithType(query.Nutris.Copper, cType));
            if (query.Nutris.Potassium > -1)
                listTemp = listTemp.Where(x => x.Nutris.Potassium.CompareWithType(query.Nutris.Potassium, cType));
            if (query.Nutris.VitaminD3 > -1)
                listTemp = listTemp.Where(x => x.Nutris.VitaminD3.CompareWithType(query.Nutris.VitaminD3, cType));
            if (query.Nutris.VitaminB1 > -1)
                listTemp = listTemp.Where(x => x.Nutris.VitaminB1.CompareWithType(query.Nutris.VitaminB1, cType));
            if (query.Nutris.VitaminB2 > -1)
                listTemp = listTemp.Where(x => x.Nutris.VitaminB2.CompareWithType(query.Nutris.VitaminB2, cType));
            if (query.Nutris.Iodine > -1)
                listTemp = listTemp.Where(x => x.Nutris.Iodine.CompareWithType(query.Nutris.Iodine, cType));
            if (query.Nutris.Zinc > -1)
                listTemp = listTemp.Where(x => x.Nutris.Zinc.CompareWithType(query.Nutris.Zinc, cType));


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
