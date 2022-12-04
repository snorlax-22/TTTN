using System.Collections.Generic;
using System;

namespace TTTN.Models
{
    [Serializable]
    public class Search
    {
        public string StrListManuId { get; set; }

        public string StrOrigin { get; set; }

        public QueryNutri Nutris { get; set; }

    }

    [Serializable]
    public class QueryNutri
    {
        /// <summary>
        /// 1: nhỏ hơn
        /// 2: bằng
        /// 3: lớn hơn
        /// </summary>
        public int compareType { get; set; } 
        public int id { get; set; }
        public float Protein { get; set; }
        public float TotalFat { get; set; }
        public float TotalCarbon { get; set; }
        public float Calcium { get; set; }
        public float Sodium { get; set; }
        public float Magnesium { get; set; }
        public float Iron { get; set; }
        public float Copper { get; set; }
        public float Potassium { get; set; }
        public float VitaminD3 { get; set; }
        public float VitaminB1 { get; set; }
        public float VitaminB2 { get; set; }
        public float Iodine { get; set; }
        public float Zinc { get; set; }

    }
}
